using System.Linq;
using ProjetoFinal.Models;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Services
{
    public class UsuarioService : IUsuario
    //Criar a interface com o nome IUsuario
    {
        private Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }
        public bool RegistrarUsuario(string email, string senha)
        {
            _context.Usuario.Add(new Usuario { Email = email, Senha = senha});

            if(_context.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha) != null)
            {
                return true;
            }
                return false;
        }
        public bool Login(string email, string senha)
        {
            _context.Usuario.SingleOrDefault(x => x.Email == email && x.Senha == senha);

            if(_context.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha) != null)
            {
                return true;
            }
                return false;
        }
            public bool UsuarioId(int id)
            {
                return _context.Usuario.Any(u => u.Id == id);
            }
    }
}