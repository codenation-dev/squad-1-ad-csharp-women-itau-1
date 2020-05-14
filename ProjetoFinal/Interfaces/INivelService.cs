using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Interfaces
{
    public interface INivelService
    {
        IList<Nivel> ListarNiveis();
        Nivel ProcurarPorId(int id);
        Nivel ProcurarPorNome(string nome);
        Nivel Salvar(Nivel nivel);
    }
}