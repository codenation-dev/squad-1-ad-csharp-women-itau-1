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

namespace ProjetoFinal.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/{controller}")]
    [ApiController]
 
    public class IdentityAuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IdentityAuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]

        public IEnumerable<string> Get()
        {
            return new string[] { "valor1", "valor2 " };
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar(IdentityAuthDTO cadastraUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new IdentityUser
            {
                UserName = cadastraUsuario.Nome,
                Email = cadastraUsuario.Email,
                EmailConfirmed = true
            };

            //CRIA USUARIO COM CRIPTOGRAFIA
            var resultado = await _userManager.CreateAsync(usuario, cadastraUsuario.Senha);

            if(resultado.Succeeded)
            {
                return Ok();
            }

            return BadRequest(ErrorResponse.FromIdentity(resultado.Errors.ToList
                ()));
                
        }
    }
}