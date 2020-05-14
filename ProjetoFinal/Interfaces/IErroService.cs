using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Interfaces
{
    public interface IErroService
    {
        void Arquivar(Erro erro);
        void Desarquivar(Erro erro);
        IList<Erro> ListarErros();
        IList<Erro> OrdenarPorFrequencia(List<Erro> erroLista);
        IList<Erro> OrdenarPorNivel(List<Erro> erroLista);
        IList<Erro> ProcurarPorAmbiente(string nomeAmbiente);
        IList<Erro> ProcurarPorDescricao(string nomeAmbiente, string descricao);
        Erro ProcurarPorId(int id);
        IList<Erro> ProcurarPorNivel(string nomeAmbiente, string nomeNivel);
        IList<Erro> ProcurarPorOrigem(string nomeAmbiente, string origem);
        void Remover(Erro erro);
        Erro Salvar(Erro erro);
    }
}