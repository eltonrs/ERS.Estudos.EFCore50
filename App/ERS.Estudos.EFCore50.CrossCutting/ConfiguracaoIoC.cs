using ERS.Estudos.EFCore50.Core.Servicos;
using ERS.Estudos.EFCore50.Interfaces.Repositorios;
using ERS.Estudos.EFCore50.Interfaces.Servicos;
using ERS.Estudos.EFCore50.Infra.Dados;
using Microsoft.Extensions.DependencyInjection;

namespace ERS.Estudos.EFCore50.CrossCutting
{
    public static class ConfiguracaoIoC
    {
        public static void ConfigurarIoC(this IServiceCollection services)
        {
            services
                .AddScoped<IPlotador, Plotador>()
                .AddScoped<IPessoaRepositorio, PessoaRepositorio>();
        }
    }
}
