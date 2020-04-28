using ProjetoFinal.Models;
using System;
using Xunit;

namespace ProjetoFinalModel.Test
{
    public sealed class LogsModelTest : ModelBaseTest
    {
        public LogsModelTest()
            : base(new SquadContext())
        {
            Model = "ProjetoFinal.Models.Logs";
            Table = "logs";
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
        [InlineData("level", false, typeof(string), null)]
        [InlineData("titulo", false, typeof(string), null)]
        [InlineData("detalhes", false, typeof(string), null)]
        [InlineData("evento", false, typeof(int), null)]
        [InlineData("data", false, typeof(DateTime), null)]
        [InlineData("coletado_por", false, typeof(string), null)]
        [InlineData("arquivado", false, typeof(bool), null)]


        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}
