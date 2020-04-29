using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Services
{
    public interface INivelService
    {
        IList<Nivel> ListarNiveis();
        Nivel ProcurarPorId(int id);
        Nivel Salvar(Nivel nivel);
    }
}