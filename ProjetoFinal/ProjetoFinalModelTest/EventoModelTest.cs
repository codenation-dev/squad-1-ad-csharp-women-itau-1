using ProjetoFinal.Models;
using System;
using Xunit;

namespace ProjetoFinalModel.Test
{
    public sealed class EventoModelTest : ModelBaseTest
    {
        public EventoModelTest()
            : base(new Context())
        {
            Model = "ProjetoFinal.Models.Evento";
            Table = "evento";
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
        [InlineData("evento", false, typeof(int), null)]

        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}
