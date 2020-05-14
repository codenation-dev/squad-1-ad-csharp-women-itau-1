using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;
using ProjetoFinal.Models;
using ProjetoFinal.Services;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class NivelController : ControllerBase
    {
        private readonly INivelService _nivelService;
        private readonly IMapper _mapper;
        public NivelController(INivelService nivelService, IMapper mapper)
        {
            _nivelService = nivelService;
            _mapper = mapper;
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<NivelDTO> GetId(int id)
        {
            var nivelEncontrado = _nivelService.ProcurarPorId(id);
            if (nivelEncontrado != null)
            {
                var retorno = _mapper.Map<NivelDTO>(nivelEncontrado);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

        [HttpGet("nome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<NivelDTO> GetNome(string nome)
        {
            var nivelEncontrado = _nivelService.ProcurarPorNome(nome);
            if (nivelEncontrado != null)
            {
                var retorno = _mapper.Map<NivelDTO>(nivelEncontrado);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<NivelDTO>> GetAll()
        {
            var listaNiveis = _nivelService.ListarNiveis();
            if (listaNiveis == null)
            {
                return NoContent();
            }
            return Ok(listaNiveis);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<NivelDTO> Post([FromBody] NivelDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nivel = new Nivel()
            {
                NomeNivel = value.NomeNivel
            };

            var retorno = _nivelService.Salvar(nivel);
            return Ok(_mapper.Map<NivelDTO>(retorno));
        }
    }
}
