using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Services
{
    public interface IEventoService
    {
        List<Evento> ListarEventos();
        Evento ProcurarPorId(int id);
        Evento Salvar(Evento evento);
    }
}