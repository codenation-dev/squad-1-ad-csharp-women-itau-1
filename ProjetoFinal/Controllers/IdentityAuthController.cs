using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjetoFinal.DTOs;
using ProjetoFinal.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjetoFinal.Services;
using Microsoft.Extensions.Options;
using ProjetoFinal.Extensions;
using System.Web;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityAuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppSettings _appSettings;
        private readonly IEmailServices _emailServices;
        
        public IdentityAuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AppSettings> appSettings, IEmailServices emailServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _emailServices = emailServices;
            
            
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar(IdentityAuthDTO cadastrarUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new IdentityUser
            {
                UserName = cadastrarUsuario.Email,
                Email = cadastrarUsuario.Email,
                EmailConfirmed = true
            };

            var resultado = await _userManager.CreateAsync(usuario, cadastrarUsuario.Senha);

            if(resultado.Succeeded)
            {
                return Ok(resultado.Succeeded);
            }

            return BadRequest(ErrorResponse.FromIdentity(resultado.Errors.ToList
                ()));                
        }

        [HttpPost("login")]
        [AllowAnonymous]

        public async Task<ActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(await GerarJwt(loginUser.Email));
            }
            if (result.IsLockedOut)
            {
                return BadRequest(loginUser);
            }

            return NotFound(loginUser);
        }

        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost("esqueciSenha")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(EsqueciSenhaDTO esqueciSenha)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _userManager.FindByEmailAsync(esqueciSenha.Email);
            if(usuario == null)
            {
                return NotFound($"Usuario '{esqueciSenha}' nao encontrado.");
            }
            else
            {
                var esqueciMail = await ForgotMainPassword(usuario);
                if(esqueciMail.Enviado)
                    return Ok();

                return Unauthorized(esqueciMail.error);
            }
        }
        [HttpGet("resetSenha")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            if(userId == null || code == null)
            {
                return BadRequest("Não foi possivel resetar a senha");
            }

            var resetSenha = new ResetSenhaDTO();
            var usuario = await  _userManager.FindByIdAsync(userId);
            if(usuario == null)
            {
                return NotFound($"Usuario ID '{userId}' não encontrado");
            }
            else
            {
                resetSenha.Code = code;
                resetSenha.Email = usuario.Email;
                resetSenha.UserId = userId;
                return Ok(resetSenha);
            }
        }

        [HttpPost("resetSenhaConfirma")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordConfirm(ResetSenhaConfirmaDTO resetSenha)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _userManager.FindByEmailAsync(resetSenha.Email);
            if( usuario == null)
            {
                return NotFound($"Usuario ID não encontrado");
            }
            else
            {
                var codigoFormatado = HttpUtility.UrlDecode(resetSenha.Code);
                return Ok(await _userManager.ResetPasswordAsync(usuario, codigoFormatado, resetSenha.Password));
            }
        }


        private async Task<LoginResponseDTO> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            // nova instancia de claims

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            // gerar código
            var encodedToken = tokenHandler.WriteToken(token);

            // add obj resposta
            var response = new LoginResponseDTO
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimDTO { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private async Task<EmailResponse> ForgotMainPassword(IdentityUser user)
        {
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);

        var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, HttpUtility.UrlEncode(code), Request.Scheme);
            
        return await _emailServices.SendEmailResetPasswordAsync(user.Email, callbackUrl);
        }
    }
}