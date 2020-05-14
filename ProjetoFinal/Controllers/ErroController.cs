using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjetoFinal.Services;
using ProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ErroController : ControllerBase
    {
        private readonly IErroService _erroService;
        private readonly IMapper _mapper;
        public ErroController(IErroService service, IMapper mapper)
        {
            _erroService = service;
            _mapper = mapper;
        }

        // GET api/v1/erro/detalhes/{id}
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
                return NotFound("Erro não encontrado");
        }

        // GET api/v1/erro/{nomeAmbiente}
        [HttpGet("{nomeAmbiente}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetAll(string nomeAmbiente = "producao", string ord = default)
        {
            var erroLista = _erroService.ProcurarPorAmbiente(nomeAmbiente).ToList();

            if (erroLista != null)
            {
                if (ord == "nivel")
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroLista);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ord == "frequencia")
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
                return NotFound("Erro não encontrado");
        }

        // GET api/v1/erro/ambiente/{nomeAmbiente}/{nomeNivel}
        [HttpGet("ambiente/{nomeAmbiente}/{nomeNivel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetNivel(string nomeAmbiente, string nomeNivel, string ord = default)

        {
            var erroNivel = _erroService.ProcurarPorNivel(nomeAmbiente, nomeNivel).ToList();

            if (erroNivel != null)
            {
                if (ord == "nivel")
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroNivel);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ord == "frequencia")
                {
                    var ordenacao = _erroService.OrdenarPorFrequencia(erroNivel);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else
                {
                    var retorno = _mapper.Map<List<ErroDTO>>(erroNivel);
                    return Ok(retorno);
                }
            }
            else
                return NotFound("Erro não encontrado");
        }

        // GET api/v1/erro/descricao/{nomeAmbiente}/{descricao}
        [HttpGet("descricao/{nomeAmbiente}/{descricao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetDescricao(string nomeAmbiente, string descricao, string ord = default)

        {
            var erroDesc = _erroService.ProcurarPorDescricao(nomeAmbiente, descricao).ToList();

            if (erroDesc != null)
            {
                if (ord == "nivel")
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroDesc);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ord == "frequencia")
                {
                    var ordenacao = _erroService.OrdenarPorFrequencia(erroDesc);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else
                {
                    var retorno = _mapper.Map<List<ErroDTO>>(erroDesc);
                    return Ok(retorno);
                }
            }
            else
                return NotFound("Erro não encontrado");
        }

        // GET api/v1/erro/origem/{nomeAmbiente}/{origem}
        [HttpGet("origem/{nomeAmbiente}/{origem}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetOrigem(string nomeAmbiente, string origem, string ord = default)

        {
            var erroOrigem = _erroService.ProcurarPorOrigem(nomeAmbiente, origem).ToList();

            if (erroOrigem != null)
            {
                if (ord == "nivel")
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroOrigem);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ord == "frequencia")
                {
                    var ordenacao = _erroService.OrdenarPorFrequencia(erroOrigem);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else
                {
                    var retorno = _mapper.Map<List<ErroDTO>>(erroOrigem);
                    return Ok(retorno);
                }
            }
            else
                return NotFound("Erro não encontrado");
        }

        // POST api/salvar
        [HttpPost("salvar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ErroDTO> Post([FromBody]ErroDTO value)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoErro = new Erro()
            {
                NivelId = value.NivelId,
                AmbienteId = value.AmbienteId,
                EventoId = value.EventoId,
                Ip = value.Ip,
                Titulo = value.Titulo,
                Descricoes = value.Descricoes,
                Data = value.Data,
                Coletado = value.Coletado,
                Arquivado = value.Arquivado
            };

            var retorno = _erroService.Salvar(novoErro);
            return Ok(_mapper.Map<ErroDTO>(retorno));
        }

        // PUT api/arquivar
        [HttpPut("arquivar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Arquivar(int erroId)
        {
            var erroArquivado = _erroService.ProcurarPorId(erroId);

            if (erroArquivado != null)
            {
                _erroService.Arquivar(erroArquivado);
                return Ok("Erro removido com sucesso!");
            }
            else
                return NotFound("Não foi possível encontrar o Erro");
        }

        // PUT api/desarquivar
        [HttpPut("desarquivar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Desarquivar(int erroId)
        {

            var erroDesarquivado = _erroService.ProcurarPorId(erroId);

            if (erroDesarquivado != null)
            {
                _erroService.Desarquivar(erroDesarquivado);
                return Ok("Erro removido com sucesso!");
            }
            else
                return NotFound("Não foi possível encontrar o Erro");
        }


        // DELETE api/erro/remover/{erroId}
        [HttpDelete("remover/{erroId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Deletar(int erroId)
        {
            var erroEncontrado = _erroService.ProcurarPorId(erroId);

            if (erroEncontrado != null)
            {
                _erroService.Remover(erroEncontrado);
                return Ok("Erro removido com sucesso");
            }
            else
                return NotFound("Não foi possível encontrar o Erro");
        }
    }
}
