using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjetoFinal.Services;
using ProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;

namespace ProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErroController : ControllerBase
    {
        private IErroService _erroService;
        private readonly IMapper _mapper;
        public ErroController(IErroService service, IMapper mapper)
        {
            _erroService = service;
            _mapper = mapper;
        }

        // GET api/erro/{id}
        [HttpGet("{id}")]
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

        // GET api/erro
        [HttpGet]
        public ActionResult<IEnumerable<ErroDTO>> GetAll()
        {
                var erroLista = _erroService.ListarErros().ToList();
                var retorno = _mapper.Map<List<ErroDTO>>(erroLista);

                return Ok(retorno);
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
