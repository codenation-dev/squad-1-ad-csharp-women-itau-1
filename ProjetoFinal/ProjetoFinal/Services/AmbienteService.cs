using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services
{
    public class AmbienteService
    {
        private Context _context;

        public AmbienteService(Context context)
        {
            _context = context;
        }

        public Ambiente ProcurarPorId(int id)
        {
            return _context.Ambientes.Find(id);
        }

        public IList<Ambiente> ListarAmbientes()
        {
            return _context.Ambientes.ToList();
        }

        public Ambiente Salvar(Ambiente ambiente)
        {
            var ambienteEncontrado = _context.Ambientes
                                              .Where(x => x.Id == ambiente.Id)
                                              .FirstOrDefault();

            if (ambienteEncontrado == null)
                _context.Add(ambiente);
            else
                ambienteEncontrado.NomeAmbiente = ambiente.NomeAmbiente;

            _context.SaveChanges();
            return ambiente;
        }
    }
}
