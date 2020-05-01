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

        public IList<Erro> ListarErros()
        {
            return _context.Erros.ToList();
        }

        public IList<Erro> ProcurarPorAmbiente(string nomeAmbiente)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente).ToList();
        }

        public IList<Erro> ProcurarPorNivel(string nomeAmbiente, string nomeNivel)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente && x.Niveis.NomeNivel == nomeNivel).ToList();
        }

        public IList<Erro> ProcurarPorDescricao(string nomeAmbiente, string descricao)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente && x.Descricoes == descricao).ToList();
        }

        public IList<Erro> ProcurarPorOrigem(string nomeAmbiente, string origem)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente && x.Ip == origem).ToList();
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
                erroEncontrado.Descricoes = erro.Descricoes;
                erroEncontrado.Coletado = erro.Coletado;
                erroEncontrado.Arquivado = erro.Arquivado;
            }
            _context.SaveChanges();
           
            return erro;
        }

        public void Remover(Erro erro)
        {
            var erroEncontrado = ProcurarPorId(erro.Id);
            if (erroEncontrado != null) {
                _context.Erros.Remove(erroEncontrado);
                _context.SaveChanges();
            }
        }

        public void Arquivar(Erro erro)
        {
            var erroEncontrado = ProcurarPorId(erro.Id);

            if (erroEncontrado != null)
            {
                erroEncontrado.Arquivado = true;
                _context.SaveChanges();
            }
        }

        public void Desarquivar(Erro erro)
        {
            var erroEncontrado = ProcurarPorId(erro.Id);

            if (erroEncontrado != null)
            {
                erroEncontrado.Arquivado = false;
                _context.SaveChanges();
            }
        }
    }
}
