using ProjetoFinal.Models;
using ProjetoFinal.Services;
using ProjetoFinal.Test.Comparacoes;
using System;
using System.Linq;
using Xunit;

namespace ProjetoFinal.Test
{
    public class ErroServiceTest
    {
        private Context _contexto;
        private FakeContext _fakeContexto { get; }

        private ErroService _erroService;
        public ErroServiceTest()
        {
            _fakeContexto = new FakeContext("ErroTestes");
            _contexto = new Context(_fakeContexto.Options);

            _erroService = new ErroService(_contexto);
        }

        [Fact]
        public void Devera_Add_Novo_Erro()
        {
            var fakeContext = new FakeContext("AddErro");
            var context = new Context(fakeContext.Options);

            var fakeErro = fakeContext.GetDadosFake<Erro>().FirstOrDefault();
            fakeErro.Id = 0;

            var erroservices = new ErroService(context);
            var erroAtual = erroservices.Salvar(fakeErro);
            //Assert
            Assert.NotEqual(0, erroAtual.Id);
        }

        [Fact]
        public void Devera_Alterar_Erro()
        {
            _fakeContexto.AdicionarTodosDados();

            //definir entradas
            var erroEsperado = _fakeContexto.GetDadosFake<Erro>().Last();
            erroEsperado.Data = DateTime.Parse("2020-10-01");
            erroEsperado.Titulo = "error.Service.ProcurarPorAmbiente: forbidden";
            erroEsperado.Descricoes = "Olar, Debug 1 no acceleration.Service.AddCandidate";
            erroEsperado.Coletado = "Olar, Debug 1 no acceleration.Service.AddCandidate";
            erroEsperado.Arquivado = false;
            erroEsperado.EventoId = 123;

            //metodo de teste
            var erroAtual = _erroService.Salvar(erroEsperado);

            //Assert
            Assert.Equal(erroEsperado.Id, erroAtual.Id);
            Assert.Equal(erroEsperado.Data, erroAtual.Data);
            Assert.Equal(erroEsperado.Titulo, erroAtual.Titulo);
            Assert.Equal(erroEsperado.Descricoes, erroAtual.Descricoes);
            Assert.Equal(erroEsperado.Coletado, erroAtual.Coletado);
            Assert.Equal(erroEsperado.Arquivado, erroAtual.Arquivado);
            Assert.Equal(erroEsperado.EventoId, erroAtual.EventoId);
        }

        [Fact]
        public void Devera_retornar_Erro()
        {
            _fakeContexto.AdicionarTodosDados();
            var erroEsperado = _fakeContexto.GetDadosFake<Erro>().Find(x => x.Id == 3);

            //metodo de teste
            var erroAtual = _erroService.ProcurarPorId(erroEsperado.Id);

            //Assert 
            //comparação de referencia de objetos
            Assert.Equal(erroEsperado, erroAtual, new ErroIdComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Devera_retornar_Erro_Por_Id(int id)
        {
            _fakeContexto.AdicionarTodosDados();

            //procurar pelo id nos dados mocados
            var erroEsperado = _fakeContexto.GetDadosFake<Erro>().Find(x => x.Id == id);

            //metodo de teste
            var atual = _erroService.ProcurarPorId(erroEsperado.Id);

            //Assert 
            //comparação de referencia de objetos
            Assert.Equal(erroEsperado, atual, new ErroIdComparer());
        }
    }
}
