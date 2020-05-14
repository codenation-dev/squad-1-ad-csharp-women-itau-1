using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Interfaces
{
    public interface IAmbienteService
    {
        IList<Ambiente> ListarAmbientes();
        Ambiente ProcurarPorId(int id);
        Ambiente ProcurarPorNome(string nome);
        Ambiente Salvar(Ambiente ambiente);
    }
}