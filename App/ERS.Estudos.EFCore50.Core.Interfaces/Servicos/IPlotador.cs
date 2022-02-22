namespace ERS.Estudos.EFCore50.Interfaces.Servicos
{
    public interface IPlotador
    {
        Task ExibirTextoAsync(
            string texto,
            CancellationToken cancellationToken
        );

        Task ExibirNomePessoasAsync(CancellationToken cancellationToken);
    }
}
