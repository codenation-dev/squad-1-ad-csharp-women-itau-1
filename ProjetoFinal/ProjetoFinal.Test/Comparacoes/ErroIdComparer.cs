using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal.Test.Comparacoes
{
     public class ErroIdComparer : IEqualityComparer<Erro>
    {
        public bool Equals(Erro x, Erro y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Erro obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
