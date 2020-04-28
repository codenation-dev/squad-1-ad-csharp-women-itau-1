using ProjetoFinal.Models;
using System;
using Xunit;

namespace ProjetoFinalModel.Test
{
    public sealed class UserModelTest : ModelBaseTest
    {
        public UserModelTest()
            : base(new SquadContext())
        {
            Model = "ProjetoFinal.Models.User";
            Table = "user";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            ComparePrimaryKeys("id");
        }

        [Theory]
        [InlineData("id", false, typeof(int), null)]
        [InlineData("email", false, typeof(string), null)]
        [InlineData("password", false, typeof(string), null)]

        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}
