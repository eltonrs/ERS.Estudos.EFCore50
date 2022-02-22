using ERS.Estudos.EFCore50.Dominio.Entidades;
using ERS.Estudos.EFCore50.Infra.Builder.Entidades;
using ERS.Estudos.EFCore50.Infra.Dados.Configuracoes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ERS.Estudos.EFCore50.Infra.Dados.Contexto
{
    public class ContextoEF : DbContext
    {
        public ContextoEF(DbContextOptions<ContextoEF> optionsBuilder) : base(optionsBuilder)
        {
            //OnConfiguring(optionsBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void SeedDadosFakes()
        {
            var migrations = Database.GetPendingMigrations();

            if (!migrations?.Any() is null)
            {
                return;
            }

            SeedPessoasFakes();
        }

        #region Declaração das entidades

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        #endregion

        #region Configurações das entidades

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PessoaConfiguracao());
            builder.ApplyConfiguration(new EnderecoConfiguracao());
        }

        #endregion

        #region Seeds

        private void SeedPessoasFakes()
        {
            var pessoasFake = new PessoaBuilder().Build();

            Pessoas.AddRange(pessoasFake);

            SaveChanges();
        }

        #endregion
    }
}
