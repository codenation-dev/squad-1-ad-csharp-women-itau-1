using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetoFinal.Test
{
    public class FakeContext
    {
        public DbContextOptions<Context> Options { get; }

        private Dictionary<Type, string> NomesArquivosDados { get; } = new Dictionary<Type, string>();


        public FakeContext(string NomeTeste)
        {
            Options = new DbContextOptionsBuilder<Context>()
                 //.UseInMemoryDatabase(databaseName: $"Context_{NomeTeste}")
                 .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjetoFinal;Trusted_Connection=True")
                 .Options;

            NomesArquivosDados.Add(typeof(Erro), $"FakeData{Path.DirectorySeparatorChar}erro.json");

        }
        private string NomeArquivo<T>()
        {
            return NomesArquivosDados[typeof(T)];
        }

        public List<T> GetDadosFake<T>()
        {
            // retorna lista tipada JSON (serealizada)
            string conteudo = File.ReadAllText(NomeArquivo<T>());

            // variável T (tê maiúsculo) representa um tipo genérico, podemos deserializar através de todos modelos 
            return JsonConvert.DeserializeObject<List<T>>(conteudo);
        }

        public void AdicionarTodosDados()
        {
            AdicionarDados<Erro>();
        }

        public void AdicionarDados<T>() where T : class
        {
            using (var context = new Context(Options))
            {
                if (context.Set<T>().Count() == 0)
                {
                    foreach (T item in GetDadosFake<T>())
                        context.Set<T>().Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
