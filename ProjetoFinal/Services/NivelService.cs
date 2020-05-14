using System.Linq;
using System;
using ProjetoFinal.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ProjetoFinal.Interfaces;

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

        public Nivel ProcurarPorNome(string nome)
        {
            return _context.Niveis.FirstOrDefault(x => x.NomeNivel == nome);
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