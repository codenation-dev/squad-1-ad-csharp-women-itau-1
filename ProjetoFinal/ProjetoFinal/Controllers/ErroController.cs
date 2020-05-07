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


        [HttpGet("ambiente/{nomeAmbiente}/{nomeNivel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetNivel(string nomeAmbiente, string nomeNivel, string ordNivel = default(string), string ordFrequencia = default(string))

        {
            var erroNivel = _erroService.ProcurarPorNivel(nomeAmbiente, nomeNivel).ToList();

            if (erroNivel != null)
            {
                if (ordNivel != null)
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroNivel);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ordFrequencia != null)
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
                return NotFound();
        }


        [HttpGet("descricao/{nomeAmbiente}/{descricao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetDescricao(string nomeAmbiente, string descricao, string ordNivel = default(string), string ordFrequencia = default(string))

        {
            var erroDesc = _erroService.ProcurarPorDescricao(nomeAmbiente, descricao).ToList();

            if (erroDesc != null)
            {
                if (ordNivel != null)
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroDesc);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ordFrequencia != null)
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
                return NotFound();
        }

        [HttpGet("origem/{nomeAmbiente}/{origem}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ErroDTO>> GetOrigem(string nomeAmbiente, string origem, string ordNivel = default(string), string ordFrequencia = default(string))

        {
            var erroOrigem = _erroService.ProcurarPorOrigem(nomeAmbiente, origem).ToList();

            if (erroOrigem != null)
            {
                if (ordNivel != null)
                {
                    var ordenacao = _erroService.OrdenarPorNivel(erroOrigem);
                    var retorno = _mapper.Map<List<ErroDTO>>(ordenacao);
                    return Ok(retorno);
                }
                else if (ordFrequencia != null)
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
                return NotFound();
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

        //PUT api/arquivar
        [HttpPut("arquivar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Arquivar(IList<Erro> listaIds)
        {

            if (listaIds.Count == 0)
                return BadRequest("Nenhum erro para arquivar");

            foreach (Erro erroArquivado in listaIds)
            {
                _erroService.Arquivar(erroArquivado);
            }

            return Ok();
        }

        //PUT api/desarquivar
        [HttpPut("desarquivar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Desarquivar(IList<Erro> listaIds)
        {

            if (listaIds.Count == 0)
                return BadRequest("Nenhum erro para desarquivar");

            foreach (Erro erroDesarquivado in listaIds)
            {
                _erroService.Desarquivar(erroDesarquivado);
            }

            return Ok();
        }


        //PUT api/remover
        [HttpDelete("remover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Deletar(IList<Erro> listaIds)
        {

            if (listaIds.Count == 0)
                return BadRequest("Nenhum erro para remover");

            foreach (Erro erroRemovido in listaIds)
            {
                _erroService.Remover(erroRemovido);
            }

            return Ok();
        }

    }
}
