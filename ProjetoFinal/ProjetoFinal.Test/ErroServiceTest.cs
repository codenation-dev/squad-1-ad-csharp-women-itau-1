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

        public void Devera_retornar_Erro_Por_Id(int id)
        {
            _contextoFake.FillWithAll();
            var erroEsperado = _contextoFake.GetFakeData<Erro>().Find(x => x.Id == id);
            var atual = _erroService.ProcurarPorId(erroEsperado.Id);

            Assert.Equal(erroEsperado, atual, new ErroIdComparer());
        }

    }
}
