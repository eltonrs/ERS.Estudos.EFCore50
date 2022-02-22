using ERS.Estudos.EFCore50.ConsoleApp.Extensions;
using ERS.Estudos.EFCore50.Interfaces.Servicos;
using ERS.Estudos.EFCore50.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ERS.Estudos.EFCore50.ConsoleApp
{
    class Program
    {
        private static readonly CancellationTokenSource _cancellationTokenSource = new();

        static async Task Main(string[] args)
        {
            ConfigurarCancellationTokenAoPressionarCtrlC();

            var configurationFileJson = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();

            var host = CreateHostBuilder(configurationFileJson, args).Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            //await TesteCancellationToken();

            var plotador = provider.GetRequiredService<IPlotador>();

            await plotador.ExibirTextoAsync(
                "Aplicação iniciada!",
                _cancellationTokenSource.Token
            );

            await plotador.ExibirNomePessoasAsync(_cancellationTokenSource.Token);

            //Console.WriteLine("Aplicação será encerrada.");
            //await Task.Delay(1000);

            await host.StopAsync(_cancellationTokenSource.Token);
        }

        private static async Task TesteCancellationToken()
        {
            // Passar o teste do CancellationToken para um projeto separada (específico).
            
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Trabalhando...");
                await Task.Delay(1000);
            }
        }

        private static void ConfigurarCancellationTokenAoPressionarCtrlC()
        {
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Evento de cancelamento desparado.");
                _cancellationTokenSource.Cancel();
                eventArgs.Cancel = true;
            };
        }

        public static IHostBuilder CreateHostBuilder(
            IConfiguration configuracao,
            string[] args
        )
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .InstalarDbContext(configuracao)
                        .ConfigurarIoC();
                });
        }
    }
}

/*
Fontes:

https://stackoverflow.com/questions/55123853/unable-to-create-an-object-of-type-dbcontexts-name-for-the-different-patte
https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs
https://stackoverflow.com/questions/38114761/asp-net-core-configuration-for-net-core-console-application
https://blog.tiagopariz.com/c-usando-skip-e-take-com-entity-framework-core-e-sql-server-2005-ou-2008/
 */