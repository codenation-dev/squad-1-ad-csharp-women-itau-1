using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public class EventoService : IEventoService
    {
        private Context _context;
        public EventoService(Context context)
        {
            _context = context;
        }

        public Evento ProcurarPorId(int id)
        {
            return _context.Eventos.Find(id);
        }

        public List<Evento> ListarEventos()
        {
            return _context.Eventos.ToList();
        }


        public Evento Salvar(Evento evento)
        {
            var eventoEncontrado = _context.Eventos
                                           .Where(x => x.Id == evento.Id)
                                           .FirstOrDefault();

            if (eventoEncontrado == null)
                _context.Eventos.Add(evento);
            else
            {
                eventoEncontrado.NomeEvento = evento.NomeEvento;
            }

            _context.SaveChanges();

            return evento;
        }
    }
}
