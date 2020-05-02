using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjetoFinal.Services;
using ProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;
using System.Runtime.InteropServices;

namespace ProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("ambiente/{nomeAmbiente}/nivel/{nomeNivel}")]
        public ActionResult<IEnumerable<ErroDTO>> GetNivel(string nomeAmbiente, string nomeNivel)
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

        [HttpGet("ambiente/{nomeAmbiente}/descricao/{descricao}")]
        public ActionResult<IEnumerable<ErroDTO>> GetDescricao(string nomeAmbiente, string descricao, string orde)
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

        [HttpGet("ambiente/{nomeAmbiente}/origem/{origem}")]
        public ActionResult<IEnumerable<ErroDTO>> GetOrigem(string nomeAmbiente, string origem)
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


        // POST api/erro
        [HttpPost]
        public ActionResult<ErroDTO> Post([FromBody] ErroDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var evento = _mapper.Map<Erro>(value);
            var retorno = _erroService.Salvar(evento);

            return Ok(_mapper.Map<ErroDTO>(retorno));
        }

    }

}
