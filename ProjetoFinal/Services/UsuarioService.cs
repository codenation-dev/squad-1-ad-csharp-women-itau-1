using System;
using System.Linq;
using ProjetoFinal.Models;
using ProjetoFinal.Services;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Services
{
    public class UsuarioService : IUsuarioService
    {
        private Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }

        public Usuario Salvar(Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.Find(usuario.Id, usuario.Email);
            if (usuarioEncontrado == null)
                _context.Usuarios.Add(usuario);
            else
            {
                throw new NotImplementedException();
            }
            _context.SaveChanges();
            return usuario;
        }

        public bool EncontrarLogin(string email, string senha)
        {
            var loginEncontrado = _context.Usuarios.SingleOrDefault(x => x.Email == email && x.Senha == senha);

            if(loginEncontrado != null)
            {
                return true;
            }
                return false;
        }        
        public Usuario ProcurarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }
    }
}