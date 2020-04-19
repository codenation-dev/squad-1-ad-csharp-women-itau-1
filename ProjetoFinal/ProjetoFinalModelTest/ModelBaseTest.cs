using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;

namespace ProjetoFinalModel.Test
{
    public abstract class ModelBaseTest
    {
        private DbContext context;

        protected string Model { get; set; }

        protected string Table { get; set; }

        public ModelBaseTest(DbContext context)
        {
            this.context = context;
        }

        // Pega o modelo da tabela
        public IEntityType GetEntity()
        {
            return context.Model.FindEntityType(Model);
        }

        // Pega o tipo que corresponde a tabela
        private IEntityType GetEntity(string nomeTabela)
        {
            //retornar o tipo que corresponda a nomeTabela 
            return context.Model.GetEntityTypes().FirstOrDefault(x => GetTableName(x) == nomeTabela);
        }

        // Pega o nome da tabela
        protected string GetTableName(IEntityType entity)
        {
            var annotation = entity.FindAnnotation("Relational:TableName");
            return annotation?.Value?.ToString();
        }

        // Pega o nome da coluna
        protected string GetFieldName(IProperty property)
        {
            var annotation = property.FindAnnotation("Relational:ColumnName");
            return annotation?.Value?.ToString();

        }

        private IEnumerable<string> GetNomesCampos(IEntityType entity)
        {
            //procurar as propriedades através da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar a campos/colunas através das propriedades recuperadas 
            return propriedades?.Select(x => this.GetFieldName(x)).ToList();
        }

        // Retorna as primary keys do modelo
        private IEnumerable<string> GetPrimaryKeys(IEntityType entity)
        {
            var chave = entity.FindPrimaryKey();
            return chave?.Properties.Select(x => this.GetFieldName(x)).ToList();
        }

        // Compara as primary keys
        protected void ComparePrimaryKeys(params string[] keys)
        {
            var entity = GetEntity();
            Assert.NotNull(entity);

            var chavesAtuais = GetPrimaryKeys(entity);
            Assert.NotNull(chavesAtuais);
            Assert.Contains(keys, x => chavesAtuais.Contains(x));
        }

        // Procura coluna na tabela 
        private IProperty SearchField(IEntityType entity, string campoNome)
        {
            var propriedades = entity.GetProperties();
            return propriedades.FirstOrDefault(x => this.GetFieldName(x) == campoNome);
        }

        // Retorna tamanho da coluna
        private int GetFieldSize(IProperty propriedade)
        {
            return propriedade.GetMaxLength().Value;
        }

        // Comparar campos
        protected void CompararCampos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            var entity = GetEntity();
            Assert.NotNull(entity);
            Assert.Contains(campoNome, GetNomesCampos(entity));

            var propriedade = SearchField(entity, campoNome);

            var esperado = new
            {
                tipo = campoTipo,
                nulo = ehNulo,
                tamanho = campoTamanho.HasValue ? campoTamanho.Value : 0
            }.ToString();

            var atual = new
            {
                tipo = propriedade.ClrType,
                nulo = propriedade.IsNullable,
                tamanho = campoTamanho.HasValue ? GetFieldSize(propriedade) : 0
            }.ToString();

            Assert.Equal(esperado, atual);
        }

        // Compara tabela
        protected void CompararTabela()
        {
            var entity = GetEntity();
            var atual = GetTableName(entity);
            Assert.NotNull(entity);
            Assert.Equal(Table, atual);
        }

        public void AssertTable()
        {
            var entity = GetEntity();
            Assert.NotNull(entity);
            var actual = this.GetTableName(entity);
            Assert.Equal(Table, actual);
        }

    }
}

