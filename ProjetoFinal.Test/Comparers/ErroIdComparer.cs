using ProjetoFinal.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoFinal.Test
{
    internal class ErroIdComparer : IEqualityComparer<Erro>
    {
        bool IEqualityComparer<Erro>.Equals(Erro x, Erro y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<Erro>.GetHashCode(Erro obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}