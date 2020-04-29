using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Services
{
    public interface IErroService
    {
        IList<Erro> OrdenarPorFrequencia();
        IList<Erro> OrdenarPorNivel();
        Erro ProcurarPorAmbiente(int ambienteId);
        Erro ProcurarPorDescricao(int ambienteId, int? descricao);
        Erro ProcurarPorId(int id);
        Erro ProcurarPorNivel(int ambienteId, int? nivel);
        Erro ProcurarPorOrigem(int ambienteId, int? origem);
        Erro Salvar(Erro erro);
    }
}