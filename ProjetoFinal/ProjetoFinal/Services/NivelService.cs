using System.Linq;
using System;
using ProjetoFinal.Models;
using ProjetoFinal.Interfaces;
using System.Collections.Generic;

namespace ProjetoFinal.Services

{
    public class NivelService : INivel
    //Criar interface com o nome INivel
    {
        public Context _context;
        public NivelService(Context context)
        {
            this._context = context;
        }
        public Nivel RegistraOuAtualiza(Nivel nivel)
        {
            var state;
            if( nivel.NivelId == 0)
            {
                return state = EntityState.Added;
            }
            else
            {
                return state = EntityState.Modified;
            }
            _context.Entry(nivel).State = state;
            _context.SaveChanges();
            return nivel;
        }
        public Nivel ConsultaPorId(int id)
        {
            return _context.Niveis.Find(id);
        }
        public Nivel ConsultaPorNome(string nome)
        {
            return _context.Niveis.FirstOrDefault(n => n.NivelNome = nome);
        }
        public List<Nivel> ConsultaTodos()
        {
            return _context.Niveis.Select(n => n).ToList();
        }
        public bool NivelExiste(int id)
        {
            return _context.Niveis.Any(e => e.NivelId == id);
        }

    }
}