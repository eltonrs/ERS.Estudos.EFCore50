using ERS.Estudos.EFCore50.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERS.Estudos.EFCore50.Infra.Dados.Configuracoes
{
    public class PessoaConfiguracao : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(nameof(Pessoa));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.DataNascimento);

            builder.HasMany(p => p.Enderecos)
                .WithOne(e => e.Pessoa)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}