using System.Linq;
using ProjetoFinal.Models;
<<<<<<< Updated upstream
using ProjetoFinal.Interfaces;
=======
>>>>>>> Stashed changes

namespace ProjetoFinal.Services
{
    public class UsuarioService : IUsuarioService
    {
        private Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }
<<<<<<< Updated upstream
        public bool RegistrarUsuario(string email, string senha)
=======

        public Usuario Salvar(Usuario usuario)
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
            if(_context.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha) != null)
=======
            if (loginEncontrado != null)
>>>>>>> Stashed changes
            {
                return true;
            }
            return false;
        }

        public Usuario ProcurarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }
<<<<<<< Updated upstream
            public bool UsuarioId(int id)
            {
                return _context.Usuario.Any(u => u.Id == id);
            }
=======
>>>>>>> Stashed changes
    }
}