using ProjetoFinal.Models;
using ProjetoFinal.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ProjetoFinal.Test
{
    public class ErroServiceTest
    {
        private Context _contexto;
        private FakeContext _contextoFake { get; }
        private ErroService _erroService;

        public ErroServiceTest()
        {
            _contextoFake = new FakeContext("ErroTest");
            _contextoFake.FillWithAll();

            _contexto = new Context(_contextoFake.FakeOptions);
            
            _erroService = new ErroService(_contexto);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]

        public void Devera_Retornar_Erro_Por_Id(int id)
        {
            _contextoFake.FillWithAll();
            var erroEsperado = _contextoFake.GetFakeData<Erro>().Find(x => x.Id == id);
            var erroAtual = _erroService.ProcurarPorId(erroEsperado.Id);

            Assert.Equal(erroEsperado, erroAtual, new ErroIdComparer());
        }

        [Fact]
        public void Devera_Retornar_Lista_de_Erros()
        {
            _contextoFake.FillWithAll();
            var erroAtual = _erroService.ListarErros();
            Assert.NotNull(erroAtual);
        }

        [Theory]
        [InlineData("producao")]
        [InlineData("homologacao")]

        public void Devera_retornar_Erro_Por_Ambiente(string nomeAmbiente)
        {
            var fakeContext = new FakeContext("ErroPorAmbiente");
            fakeContext.FillWithAll();


            using (var context = new Context(fakeContext.FakeOptions))
            {
                var ambienteEsperado = fakeContext.GetFakeData<Ambiente>().Find(x => x.NomeAmbiente == nomeAmbiente);

                var erroEsperado = fakeContext.GetFakeData<Erro>().Where(x => x.AmbienteId == ambienteEsperado.Id).ToList();

                var erroAtual = _erroService.ProcurarPorAmbiente(ambienteEsperado.NomeAmbiente);

                Assert.Equal(erroEsperado, erroAtual, new ErroIdComparer());
            }

        }

        [Theory]
        [InlineData("producao", "300")]
        [InlineData("homologacao","400")]

        public void Devera_retornar_Erro_Por_Nivel(string nomeAmbiente,string nomeNivel)
        {
            var fakeContext = new FakeContext("ErroPorNivel");
            fakeContext.FillWithAll();


            using (var context = new Context(fakeContext.FakeOptions))
            {
                var nivelEsperado = fakeContext.GetFakeData<Nivel>().Find(x => x.NomeNivel == nomeNivel);
                var ambienteEsperado = fakeContext.GetFakeData<Ambiente>().Find(x => x.NomeAmbiente == nomeAmbiente);

                var erroEsperado = fakeContext.GetFakeData<Erro>().Where(x => x.NivelId == nivelEsperado.Id && x.AmbienteId == ambienteEsperado.Id).ToList();

                var erroAtual = _erroService.ProcurarPorNivel(ambienteEsperado.NomeAmbiente,nivelEsperado.NomeNivel);

                Assert.Equal(erroEsperado, erroAtual, new ErroIdComparer());
            }

        }

        [Theory]
        [InlineData("producao", "string")]
        [InlineData("homologacao", "string")]

        public void Devera_retornar_Erro_Por_Descricao(string nomeAmbiente, string descricao)
        {
            var fakeContext = new FakeContext("ErroPorDescricao");
            fakeContext.FillWithAll();


            using (var context = new Context(fakeContext.FakeOptions))
            {
                var descEsperado = fakeContext.GetFakeData<Erro>().Find(x => x.Descricoes == descricao);
                var ambienteEsperado = fakeContext.GetFakeData<Ambiente>().Find(x => x.NomeAmbiente == nomeAmbiente);

                var erroEsperado = fakeContext.GetFakeData<Erro>().Where(x => x.Descricoes == descricao && x.AmbienteId == ambienteEsperado.Id).ToList();

                var erroAtual = _erroService.ProcurarPorDescricao(ambienteEsperado.NomeAmbiente, descEsperado.Descricoes);

                Assert.Equal(erroEsperado, erroAtual, new ErroIdComparer());
            }

        }

        [Theory]
        [InlineData("producao", "123")]
        [InlineData("homologacao", "456")]

        public void Devera_retornar_Erro_Por_Origem(string nomeAmbiente, string origem)
        {
            var fakeContext = new FakeContext("ErroPorOrigem");
            fakeContext.FillWithAll();


            using (var context = new Context(fakeContext.FakeOptions))
            {
                var origemEsperado = fakeContext.GetFakeData<Erro>().Find(x => x.Ip == origem);
                var ambienteEsperado = fakeContext.GetFakeData<Ambiente>().Find(x => x.NomeAmbiente == nomeAmbiente);

                var erroEsperado = fakeContext.GetFakeData<Erro>().Where(x => x.Ip == origem && x.AmbienteId == ambienteEsperado.Id).ToList();

                var erroAtual = _erroService.ProcurarPorOrigem(ambienteEsperado.NomeAmbiente, origemEsperado.Ip);

                Assert.Equal(erroEsperado, erroAtual, new ErroIdComparer());
            }

        }

    }
}
