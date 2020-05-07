using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoFinal.Services
{
    public class ErroService : IErroService
    {
        private readonly Context _context;
        private readonly IAmbienteService _ambienteService;

        public ErroService(Context context, IAmbienteService ambienteService)
        {
            _context = context;
            _ambienteService = ambienteService;
        }

        public Erro ProcurarPorId(int id)
        {
            return _context.Erros.Where(x => x.Id == id)
                .Include(x => x.Ambientes)
                .Include(x => x.Niveis)
                .FirstOrDefault();
        }

        public IList<Erro> ListarErros()
        {
            return _context.Erros.ToList();
        }

        public IList<Erro> ProcurarPorAmbiente(string nomeAmbiente)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente)
                .Include(x => x.Ambientes)
                .Include(x => x.Niveis)
                .ToList();
        }

        public IList<Erro> ProcurarPorNivel(string nomeAmbiente, string nomeNivel)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente && x.Niveis.NomeNivel == nomeNivel).ToList();
        }

        public IList<Erro> ProcurarPorDescricao(string nomeAmbiente, string descricao)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente && x.Descricoes == descricao)
                .Include(x => x.Ambientes)
                .Include(x => x.Niveis)
                .ToList();
        }

        public IList<Erro> ProcurarPorOrigem(string nomeAmbiente, string origem)
        {
            return _context.Erros.Where(x => x.Ambientes.NomeAmbiente == nomeAmbiente && x.Ip == origem)
                .Include(x => x.Ambientes)
                .Include(x => x.Niveis)
                .ToList();
        }

        public IList<Erro> OrdenarPorNivel(List<Erro> erroLista)
        {
            return erroLista.OrderBy(x => x.NivelId).ToList();
        }

        public IList<Erro> OrdenarPorFrequencia(List<Erro> erroLista)
        {
            return erroLista.GroupBy(x => x.NivelId).OrderByDescending(x => x.Count()).SelectMany(x => x).ToList();
        }

        public Erro Salvar(Erro erro)
        {
            var erroEncontrado = _context.Erros.Find(erro.Id);

            if (erroEncontrado == null)
            {
                _context.Erros.Add(erro);
            }
            else
            {
                erroEncontrado.Ip = erro.Ip;
                erroEncontrado.Data = erro.Data;
                erroEncontrado.Titulo = erro.Titulo;
                erroEncontrado.Descricoes = erro.Descricoes;
                erroEncontrado.Coletado = erro.Coletado;
                erroEncontrado.Arquivado = erro.Arquivado;
                erroEncontrado.Ambientes.NomeAmbiente = erro.Ambientes.NomeAmbiente;
                erroEncontrado.Niveis.NomeNivel = erro.Niveis.NomeNivel;
                erroEncontrado.EventoId = erro.EventoId;
            }
            _context.SaveChanges();

            return erro;
        }

        public void Remover(Erro erro)
        {
            var erroEncontrado = ProcurarPorId(erro.Id);
            if (erroEncontrado != null)
            {
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
