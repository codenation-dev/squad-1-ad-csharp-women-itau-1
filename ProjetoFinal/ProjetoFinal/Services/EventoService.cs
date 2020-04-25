using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public class EventoService
    {
        private Context _context;
        public EventoService(Context context)
        {
            _context = context;
        }

        public Evento FindById(int id)
        {
            return _context.Evento.Find(id);
        }

        public List<Evento> FindAllEvents()
        {
            return _context.Evento.Select(x => x).ToList();
        }


        public Evento Save(Evento evento)
        {
            var existe = _context.Evento
                          .Where(x => x.Id == evento.Id)
                          .FirstOrDefault();

            if (existe == null)
                _context.Evento.Add(evento);
            else
            {
                existe.Eventos = evento.Eventos;
            }

            _context.SaveChanges();

            return evento;
        }
    }
}
