using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjetoFinal.Services;
using ProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;

namespace ProjetoFinal.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ErroController : ControllerBase
    {
        private readonly IErroService _erroService;
        private readonly IMapper _mapper;
        public ErroController(IErroService service, IMapper mapper)
        {
            _erroService = service;
            _mapper = mapper;
        }

        // GET api/erro/detalhes/{id}
        [HttpGet("detalhes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ErroDTO> Get(int id)
        {
            var erroId = _erroService.ProcurarPorId(id);

            if (erroId != null)
            {
                var retorno = _mapper.Map<ErroDTO>(erroId);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

        // GET api/erro/
        [HttpGet("{nomeAmbiente}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetAll(string nomeAmbiente = "producao", string ordNivel = default(string), string ordFrequencia = default(string))
        {
            var erroLista = _erroService.ProcurarPorAmbiente(nomeAmbiente).ToList();

            if (erroLista != null)
            {
                if (ordNivel != null)
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroLista);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ordFrequencia != null)
                {
                    var ordenacao = _erroService.OrdenarPorFrequencia(erroLista);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else
                {
                    var retorno = _mapper.Map<List<ErroDTO>>(erroLista);
                    return Ok(retorno);
                }
            }
            else
                return NotFound();
        }

<<<<<<< Updated upstream
        [HttpGet("ambiente/{nomeAmbiente}/nivel/{nomeNivel}")]
        public ActionResult<IEnumerable<ErroDTO>> GetNivel(string nomeAmbiente, string nomeNivel)
=======
        [HttpGet("ambiente/{nomeAmbiente}/{nomeNivel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetNivel(string nomeAmbiente, string nomeNivel, string ordNivel = default(string), string ordFrequencia = default(string))
>>>>>>> Stashed changes
        {
            var erroNivel = _erroService.ProcurarPorNivel(nomeAmbiente, nomeNivel).ToList();

            if (erroNivel != null)
            {
                var retorno = _mapper.Map<List<ErroDTO>>(erroNivel);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

<<<<<<< Updated upstream
        [HttpGet("ambiente/{nomeAmbiente}/descricao/{descricao}")]
        public ActionResult<IEnumerable<ErroDTO>> GetDescricao(string nomeAmbiente, string descricao, string orde)
=======
        [HttpGet("descricao/{nomeAmbiente}/{descricao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetDescricao(string nomeAmbiente, string descricao, string ordNivel = default(string), string ordFrequencia = default(string))
>>>>>>> Stashed changes
        {
            var erroDesc = _erroService.ProcurarPorDescricao(nomeAmbiente, descricao).ToList();

            if (erroDesc != null)
            {
                var retorno = _mapper.Map<List<ErroDTO>>(erroDesc);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

<<<<<<< Updated upstream
        [HttpGet("ambiente/{nomeAmbiente}/origem/{origem}")]
        public ActionResult<IEnumerable<ErroDTO>> GetOrigem(string nomeAmbiente, string origem)
=======
        [HttpGet("origem/{nomeAmbiente}/{origem}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetOrigem(string nomeAmbiente, string origem, string ordNivel = default(string), string ordFrequencia = default(string))
>>>>>>> Stashed changes
        {
            var erroOrigem = _erroService.ProcurarPorOrigem(nomeAmbiente, origem).ToList();

            if (erroOrigem != null)
            {
                var retorno = _mapper.Map<List<ErroDTO>>(erroOrigem);
                return Ok(retorno);
            }
            else
                return NotFound();
        }

<<<<<<< Updated upstream

        // POST api/erro
        [HttpPost]
        public ActionResult<ErroDTO> Post([FromBody] ErroDTO value)
=======
        // POST api/salvar
        [HttpPost("salvar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ErroDTO>> Post([FromBody]List<ErroDTO> value)
>>>>>>> Stashed changes
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var evento = _mapper.Map<Erro>(value);
            var retorno = _erroService.Salvar(evento);

            return Ok(_mapper.Map<ErroDTO>(retorno));
        }

    }

}
