using ProjetoFinal.Models;

namespace ProjetoFinal.Services
{
    public interface IUsuarioService
    {
        bool EncontrarLogin(string email, string senha);
        Usuario ProcurarPorId(int id);
        Usuario Salvar(Usuario usuario);
    }
}