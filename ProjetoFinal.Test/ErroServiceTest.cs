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

        [Fact]
        public void Devera_Ordernar_Erros_Por_Nivel()
        {
            _contextoFake.FillWithAll();
            var erroLista = _erroService.ListarErros().ToList();
            var erroAtual = _erroService.OrdenarPorNivel(erroLista);
            Assert.NotNull(erroAtual);
        }

        [Fact]
        public void Devera_Ordernar_Erros_Por_Frequencia()
        {
            _contextoFake.FillWithAll();
            var erroLista = _erroService.ListarErros().ToList();
            var erroAtual = _erroService.OrdenarPorFrequencia(erroLista);
            Assert.NotNull(erroAtual);
        }

        [Fact]
        public void Devera_Add_Novo_Erro()
        {
            var fakeContext = new FakeContext("AddErro");

            var fakeErro = new Erro();
            fakeErro.AmbienteId = 1;
            fakeErro.Arquivado = false;
            fakeErro.Coletado = "Squad";
            fakeErro.Data = DateTime.Today;
            fakeErro.Descricoes = "haha";
            fakeErro.EventoId = 2;
            fakeErro.Ip = "11234";
            fakeErro.NivelId = 2;
            fakeErro.Titulo = "Teste Squad";

            using (var context = new Context(fakeContext.FakeOptions))
            {
                var service = new ErroService(context);
                var actual = service.Salvar(fakeErro);

                Assert.NotEqual(0, actual.Id);
                Assert.NotEqual(0, actual.AmbienteId);
                Assert.NotEqual(0, actual.EventoId);
                Assert.NotEqual(0, actual.NivelId);
            }
        }

        [Fact]
        public void Devera_Remover_Erro()
        {
            var fakeContext = new FakeContext("RemoveErro");
            _contextoFake.FillWithAll();

            var fakeErro = new Erro();
            fakeErro.AmbienteId = 1;
            fakeErro.Arquivado = false;
            fakeErro.Coletado = "Squad";
            fakeErro.Data = DateTime.Today;
            fakeErro.Descricoes = "haha";
            fakeErro.EventoId = 2;
            fakeErro.Ip = "11234";
            fakeErro.NivelId = 2;
            fakeErro.Titulo = "Teste Squad";

            using (var context = new Context(fakeContext.FakeOptions))
            {
                var service = new ErroService(context);
                var actual = service.Salvar(fakeErro);
                service.Remover(fakeErro);
                var erroProcurado = service.ProcurarPorId(fakeErro.Id);
                Assert.Null(erroProcurado);
            }
        }

        [Fact]
        public void Devera_Arquivar_Erro()
        {
            var fakeContext = new FakeContext("ArquivaErro");
            _contextoFake.FillWithAll();

            var fakeErro = new Erro();
            fakeErro.AmbienteId = 1;
            fakeErro.Arquivado = false;
            fakeErro.Coletado = "Squad";
            fakeErro.Data = DateTime.Today;
            fakeErro.Descricoes = "haha";
            fakeErro.EventoId = 2;
            fakeErro.Ip = "11234";
            fakeErro.NivelId = 2;
            fakeErro.Titulo = "Teste Squad";

            using (var context = new Context(fakeContext.FakeOptions))
            {
                var service = new ErroService(context);
                var actual = service.Salvar(fakeErro);
                service.Arquivar(fakeErro);

                Assert.True(fakeErro.Arquivado);

            }
        }

        [Fact]
        public void Devera_Desarquivar_Erro()
        {
            var fakeContext = new FakeContext("DesarquivaErro");
            _contextoFake.FillWithAll();

            var fakeErro = new Erro();
            fakeErro.AmbienteId = 1;
            fakeErro.Arquivado = true;
            fakeErro.Coletado = "Squad";
            fakeErro.Data = DateTime.Today;
            fakeErro.Descricoes = "haha";
            fakeErro.EventoId = 2;
            fakeErro.Ip = "11234";
            fakeErro.NivelId = 2;
            fakeErro.Titulo = "Teste Squad";

            using (var context = new Context(fakeContext.FakeOptions))
            {
                var service = new ErroService(context);
                var actual = service.Salvar(fakeErro);
                service.Desarquivar(fakeErro);

                Assert.False(fakeErro.Arquivado);

            }
        }


    }
}
