using ERS.Estudos.EFCore50.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERS.Estudos.EFCore50.Infra.Dados.Configuracoes
{
    public class EnderecoConfiguracao : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable(nameof(Endereco));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.Numero);

            builder.HasOne(e => e.Pessoa)
                .WithMany(p => p.Enderecos);
        }
    }
}
