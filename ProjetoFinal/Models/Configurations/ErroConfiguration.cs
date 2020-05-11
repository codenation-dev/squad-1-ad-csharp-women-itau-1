using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoFinal.Models.Configurations
{
    public class ErroConfiguration : IEntityTypeConfiguration<Erro>
    {
        public void Configure(EntityTypeBuilder<Erro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Ambientes)
                   .WithMany(x => x.Erros)
                   .HasForeignKey(x => x.AmbienteId)
                   .HasConstraintName("FK_erro_ambiente");

            builder.HasOne(x => x.Niveis)
                   .WithMany(x => x.Erros)
                   .HasForeignKey(x => x.NivelId)
                   .HasConstraintName("FK_erro_nivel");
        }
    }
}
