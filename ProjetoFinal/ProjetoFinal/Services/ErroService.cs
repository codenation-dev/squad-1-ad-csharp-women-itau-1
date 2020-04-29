using ProjetoFinal.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinal.Services
{
    public class ErroService : IErroService
    {
        private Context _context;

        public ErroService(Context context)
        {
            _context = context;
        }

        public Erro ProcurarPorId(int id)
        {
            return _context.Erros.Find(id);
        }

        public Erro ProcurarPorAmbiente(int ambienteId)
        {
            return _context.Erros.Find(ambienteId);
        }

        public Erro ProcurarPorNivel(int ambienteId, int? nivel)
        {
            return _context.Erros.Find(ambienteId, nivel);
        }

        public Erro ProcurarPorDescricao(int ambienteId, int? descricao)
        {
            return _context.Erros.Find(ambienteId, descricao);
        }

        public Erro ProcurarPorOrigem(int ambienteId, int? origem)
        {
            return _context.Erros.Find(ambienteId, origem);
        }

        public IList<Erro> OrdenarPorNivel()
        {
            return _context.Erros.OrderBy(x => x.NivelId).ToList();
        }

        public IList<Erro> OrdenarPorFrequencia()
        {
            return _context.Erros.OrderBy(x => x.NivelId).ToList();
        }

        public Erro Salvar(Erro erro)
        {
            var erroEncontrado = _context.Erros.Find(erro.Id);
            if (erroEncontrado == null)
                _context.Erros.Add(erro);
            else
            {
                erroEncontrado.Ip = erro.Ip;
                erroEncontrado.Data = erro.Data;
                erroEncontrado.Titulo = erro.Titulo;
                erroEncontrado.Detalhes = erro.Detalhes;
                erroEncontrado.Coletado = erro.Coletado;
                erroEncontrado.Arquivado = erro.Arquivado;
            }
            _context.SaveChanges();
            return erro;
        }
    }
}
