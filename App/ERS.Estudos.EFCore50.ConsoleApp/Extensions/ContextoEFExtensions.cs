using ERS.Estudos.EFCore50.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERS.Estudos.EFCore50.ConsoleApp.Extensions
{
    public static class ContextoEFExtensions
    {
        public static IServiceCollection InstalarDbContext(
            this IServiceCollection services,
            IConfiguration configuracao
        )
        {
            var connectionString = configuracao.GetConnectionString("Contexto");

            services.AddDbContext<ContextoEF>(builder =>
            {
                builder.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
