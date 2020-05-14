using System.Collections.Generic;
using System.Linq;
using ProjetoFinal.Models;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Services
{
    public class AmbienteService : IAmbienteService
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

        public Ambiente ProcurarPorNome(string nome)
        {
            return _context.Ambientes.FirstOrDefault(x => x.NomeAmbiente == nome);
        }

        public IList<Ambiente> ListarAmbientes()
        {
            return _context.Ambientes.ToList();
        }

        public Ambiente Salvar(Ambiente ambiente)
        {
            var ambienteEncontrado = _context.Ambientes
                                    .Where(x => x.Id == ambiente.Id && x.NomeAmbiente == ambiente.NomeAmbiente)
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
