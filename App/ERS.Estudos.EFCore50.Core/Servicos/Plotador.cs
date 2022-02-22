using ERS.Estudos.EFCore50.Interfaces.Repositorios;
using ERS.Estudos.EFCore50.Interfaces.Servicos;

namespace ERS.Estudos.EFCore50.Core.Servicos
{
    public class Plotador : IPlotador
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public Plotador(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public async Task ExibirTextoAsync(
            string texto,
            CancellationToken cancellationToken
        )
        {
            await Console.Out.WriteLineAsync(texto);
        }

        public async Task ExibirNomePessoasAsync(CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepositorio.ObterPessoasOrdenadasPorNomeAsync(cancellationToken);

            foreach (var pessoa in pessoas)
            {
                Console.WriteLine(pessoa.Nome);
            }
        }
    }
}
