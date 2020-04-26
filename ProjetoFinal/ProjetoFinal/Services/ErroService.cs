using ProjetoFinal.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinal.Services
{
    public class ErroService
    {
        private Context _context;

        public ErroService(Context context)
        {
            _context = context;
        }

        public IList<Erro> FindByAmbienteId(int ambienteId)
        {
            return _context.Erro.
                Where(x => x.Ambiente_id == ambienteId).
                ToList();
        }

        public IList<Erro> FindByNivelId(int nivelId)
        {
            return _context.Erro.
                Where(x => x.Nivel_id == nivelId).
                ToList();
        }

        public IList<Erro> FindByEventoId(int eventoId)
        {
            return _context.Erro.
                Where(x => x.Evento_id == eventoId).
                ToList();
        }

        public Erro FindById(int usuarioId, int ambienteId, int nivelId, int eventoId)
        {
            return _context.Erro.Find(usuarioId, ambienteId, nivelId, eventoId);
        }

        public Erro Save(Erro erro)
        {
            var found = _context.Erro.Find(erro.Usuario_id, erro.Ambiente_id, erro.Nivel_id, erro.Evento_id);
            if (found == null)
                _context.Erro.Add(erro);
            else
                found.Coletado = erro.Coletado;
            _context.SaveChanges();
            return erro;
        }
    }
}
