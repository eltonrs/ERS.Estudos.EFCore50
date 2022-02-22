using ERS.Estudos.EFCore50.Interfaces.Repositorios;
using ERS.Estudos.EFCore50.Dominio.Entidades;
using ERS.Estudos.EFCore50.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ERS.Estudos.EFCore50.Infra.Dados
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly ContextoEF _contexto;

        public PessoaRepositorio(ContextoEF contexto)
        {
            _contexto = contexto;
        }

        public async Task<Pessoa> ObterPorIdAsync(
            Guid pessoaId,
            CancellationToken cancellationToken = default
        )
            => await _contexto.Pessoas
                .FirstOrDefaultAsync(p =>
                    p.Id == pessoaId,
                    cancellationToken
                );

        public async Task<IEnumerable<Pessoa>> ObterPessoasOrdenadasPorNomeAsync(CancellationToken cancellationToken = default)
            => await _contexto.Pessoas
                .OrderBy(p => p.Nome)
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Pessoa>> ObterPessoasPaginadoAsync(
            int pagina,
            int tamanhoPagina,
            CancellationToken cancellationToken = default
        )
            => await _contexto.Pessoas
                .OrderBy(p => p.Nome)
                .Skip(tamanhoPagina * (pagina - 1))
                .Take(tamanhoPagina)
                .ToListAsync(cancellationToken);

        //public IEnumerable<PessoaNomeDto> ObterNomePessoas()
        //    => _contexto.Pessoas
        //        .Select(p => new PessoaNomeDto
        //        {
        //            PessoaNome = p.Nome
        //        })
        //        .OrderBy(p => p.PessoaNome)
        //        .ToList();

        //public IEnumerable<PessoaNomeDto> ObterNomePessoaPorId(Guid id)
        //    => _contexto.Pessoas
        //        .Where(p => p.Id == id)
        //        .Select(p => new PessoaNomeDto
        //        {
        //            PessoaNome = p.Nome
        //        })
        //        .OrderBy(p => p.PessoaNome)
        //        .ToList();

        //public Tuple<string, DateTime> ObterNomeDataNascimentoComTuplaPorId(Guid id)
        //    => _contexto.Pessoas
        //        .Where(p => p.Id == id)
        //        .Select(p => new { p.Nome, p.DataNascimento })
        //        .AsEnumerable()
        //        .Select(p => Tuple.Create(p.Nome, p.DataNascimento))
        //        .FirstOrDefault();
    }
}