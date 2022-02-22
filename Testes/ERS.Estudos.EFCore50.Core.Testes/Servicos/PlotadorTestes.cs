using ERS.Estudos.EFCore50.Core.Servicos;
using ERS.Estudos.EFCore50.Infra.Builder.Entidades;
using ERS.Estudos.EFCore50.Interfaces.Repositorios;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERS.Estudos.EFCore50.Core.Testes.Servicos
{
    [Trait("Unidade", nameof(Plotador))]
    public class PlotadorTestes
    {
        [Fact]
        public async Task AoInvocarExibirNomePessoas_ChamarRepositorioPessoaUmaVez()
        {
            var (plotador, assertions) = new PlotadorBuilder()
                .ComPessoaRepositorio()
                .Build();

            await plotador.ExibirNomePessoasAsync(It.IsAny<CancellationToken>());

            assertions.ComChamadaParaRepositorio();
        }

        internal class PlotadorBuilder
        {
            private readonly Mock<IPessoaRepositorio> _pessoaRepositorio;

            public PlotadorBuilder()
            {
                _pessoaRepositorio = new();
            }

            public PlotadorBuilder ComPessoaRepositorio()
            {
                var pessoas = new PessoaBuilder().Build(3);
                
                _pessoaRepositorio
                    .Setup(mock =>
                        mock.ObterPessoasOrdenadasPorNomeAsync(It.IsAny<CancellationToken>())
                    )
                    .ReturnsAsync(pessoas);

                return this;
            }

            public (Plotador, PlotadorAssertions) Build()
                => (
                    new(_pessoaRepositorio.Object),
                    new(_pessoaRepositorio)
                );
        }

        internal class PlotadorAssertions
        {
            private readonly Mock<IPessoaRepositorio> _pessoaRepositorio;

            public PlotadorAssertions(Mock<IPessoaRepositorio> pessoaRepositorio)
            {
                _pessoaRepositorio = pessoaRepositorio;
            }

            public void ComChamadaParaRepositorio()
            {
                _pessoaRepositorio.Verify(
                    mock => mock.ObterPessoasOrdenadasPorNomeAsync(It.IsAny<CancellationToken>()),
                    Times.Once()
                );
            }
        }
    }
}
