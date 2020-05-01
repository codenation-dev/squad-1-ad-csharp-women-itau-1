using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Services
{
    public interface IErroService
    {
        IList<Erro> ListarErros();
        IList<Erro> OrdenarPorFrequencia();
        IList<Erro> OrdenarPorNivel();
        IList<Erro> ProcurarPorAmbiente(string nomeAmbiente);
        IList<Erro> ProcurarPorDescricao(string nomeAmbiente, string descricao);
        Erro ProcurarPorId(int id);
        IList<Erro> ProcurarPorNivel(string nomeAmbiente, string nomeNivel);
        IList<Erro> ProcurarPorOrigem(string nomeAmbiente, string origem);
        Erro Salvar(Erro erro);
    }
}