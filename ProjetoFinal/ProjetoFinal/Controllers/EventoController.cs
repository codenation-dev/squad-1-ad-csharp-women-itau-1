using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjetoFinal.DTOs;
using ProjetoFinal.Services;
using ProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IEventoService _eventoService;
        private readonly IMapper _mapper;
        public EventoController(IEventoService service, IMapper mapper)
        {
            _eventoService = service;
            _mapper = mapper;
        }

        // GET api/evento/{id}
        [HttpGet("{id}")]
        public ActionResult<EventoDTO> Get(int id)
        {
            var eventoId = _eventoService.ProcurarPorId(id);

            if (eventoId != null)
            {
                var retorno = _mapper.Map<EventoDTO>(eventoId);
                return Ok(retorno);
            }

            else
                return NotFound();
        }

        // GET api/evento
        [HttpGet]
        public ActionResult<IEnumerable<EventoDTO>> GetAll()
        {
                var eventoLista = _eventoService.ListarEventos().ToList();
                var retorno = _mapper.Map<List<EventoDTO>>(eventoLista);

                return Ok(retorno);
        }

        // POST api/evento
        [HttpPost]
        public ActionResult<EventoDTO> Post([FromBody] EventoDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var evento = _mapper.Map<Evento>(value);
            var retorno = _eventoService.Salvar(evento);

            return Ok(_mapper.Map<EventoDTO>(retorno));
        }

    }

}
