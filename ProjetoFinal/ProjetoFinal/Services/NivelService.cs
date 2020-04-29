using System.Linq;
using System;
using ProjetoFinal.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Services

{
    public class NivelService : INivelService
    {
        public Context _context;
        public NivelService(Context context)
        {
            _context = context;
        }
        public Nivel ProcurarPorId(int id)
        {
            return _context.Niveis.Find(id);
        }

        public IList<Nivel> ListarNiveis()
        {
            return _context.Niveis.ToList();
        }

        public Nivel Salvar(Nivel nivel)
        {
            var nivelEncontrado = _context.Niveis
                                    .Where(x => x.Id == nivel.Id)
                                    .FirstOrDefault();

            if (nivelEncontrado == null)
                _context.Add(nivel);
            else
                nivelEncontrado.NomeNivel = nivel.NomeNivel;

            _context.SaveChanges();

            return nivel;
        }

    }
}