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
        public DbContextOptions<Context> FakeOptions { get; }

        private Dictionary<Type, string> DataFileNames { get; } =
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: $"Test_{testName}")
                .Options;

            DataFileNames.Add(typeof(Erro), $"FakeData{Path.DirectorySeparatorChar}erro.json");

        }

        public void FillWithAll()
        {
            FillWith<Erro>();
        }

        public void FillWith<T>() where T : class
        {
            using (var context = new Context(FakeOptions))
            {
                if (context.Set<T>().Count() == 0)
                {
                    foreach (T item in GetFakeData<T>())
                        context.Set<T>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        public List<T> GetFakeData<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }
    }
}
