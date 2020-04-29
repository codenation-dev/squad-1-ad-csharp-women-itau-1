using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Services
{
    public interface IAmbienteService
    {
        IList<Ambiente> ListarAmbientes();
        Ambiente ProcurarPorId(int id);
        Ambiente Salvar(Ambiente ambiente);
    }
}