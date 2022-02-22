using ERS.Estudos.EFCore50.Dominio.Entidades;

namespace ERS.Estudos.EFCore50.Interfaces.Repositorios
{
    public interface IPessoaRepositorio
    {
        Task<Pessoa> ObterPorIdAsync(
            Guid pessoaId,
            CancellationToken cancellationToken = default
        );

        Task<IEnumerable<Pessoa>> ObterPessoasOrdenadasPorNomeAsync(CancellationToken cancellationToken = default);
        
        Task<IEnumerable<Pessoa>> ObterPessoasPaginadoAsync(
            int pagina,
            int tamanhoPagina,
            CancellationToken cancellationToken = default
        );
    }
}
