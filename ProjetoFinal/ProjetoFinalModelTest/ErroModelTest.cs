using ProjetoFinal.Models;
using System;
using Xunit;

namespace ProjetoFinalModel.Test
{
    public sealed class ErroModelTest : ModelBaseTest
    {
        public ErroModelTest()
            : base(new Context())
        {
            Model = "ProjetoFinal.Models.Evento";
            Table = "erro";
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
        [InlineData("usuario_id", false, typeof(int), null)]
        [InlineData("nivel_id", false, typeof(int), null)]
        [InlineData("titulo", false, typeof(string), null)]
        [InlineData("detalhes", false, typeof(string), null)]
        [InlineData("ambiente_id", false, typeof(int), null)]
        [InlineData("evento_id", false, typeof(int), null)]
        [InlineData("data", false, typeof(DateTime), null)]
        [InlineData("coletado", false, typeof(string), null)]
        [InlineData("arquivado", false, typeof(int), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }
    }
}
