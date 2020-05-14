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
    public class AmbienteController : ControllerBase
    {
        private readonly IAmbienteService _ambienteService;
        private readonly IMapper _mapper;
        public AmbienteController(IAmbienteService ambienteService, IMapper mapper)
        {
            _ambienteService = ambienteService;
            _mapper = mapper;
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AmbienteDTO> GetId(int id)
        {
            var ambienteEncontrado = _ambienteService.ProcurarPorId(id);
            if (ambienteEncontrado != null)
            {
                var retorno = _mapper.Map<AmbienteDTO>(ambienteEncontrado);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

        [HttpGet("nome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AmbienteDTO> GetNome(string nome)
        {
            var ambienteEncontrado = _ambienteService.ProcurarPorNome(nome);
            if (ambienteEncontrado != null)
            {
                var retorno = _mapper.Map<AmbienteDTO>(ambienteEncontrado);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<AmbienteDTO>> GetAll()
        {
            var listaAmbientes = _ambienteService.ListarAmbientes();
            if (listaAmbientes == null)
            {
                return NoContent();
            }
            return Ok(listaAmbientes);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AmbienteDTO> Post([FromBody] AmbienteDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ambiente = new Ambiente()
            {
                NomeAmbiente = value.NomeAmbiente
            };

            var retorno = _ambienteService.Salvar(ambiente);
            return Ok(_mapper.Map<AmbienteDTO>(retorno));
        }
    }
}
