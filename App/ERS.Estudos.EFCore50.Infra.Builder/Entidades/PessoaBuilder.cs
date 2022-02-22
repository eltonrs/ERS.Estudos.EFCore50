using Bogus;
using ERS.Estudos.EFCore50.Dominio.Entidades;

namespace ERS.Estudos.EFCore50.Infra.Builder.Entidades
{
    public class PessoaBuilder
    {
        private readonly Faker<Pessoa> _pessoaFake;

        public PessoaBuilder()
        {
            _pessoaFake = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Nome, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
                .RuleFor(p => p.DataNascimento, f => f.Date.Past(18, DateTime.Now));
        }

        public PessoaBuilder ComId(Guid pessoaId)
        {
            _pessoaFake
                .RuleFor(p => p.Id, pessoaId);

            return this;
        }

        public PessoaBuilder ComNome(string nome)
        {
            _pessoaFake
                .RuleFor(p => p.Nome, nome);

            return this;
        }

        public Pessoa Build() => _pessoaFake.Generate();

        public IEnumerable<Pessoa> Build(int quantidade = 1) => _pessoaFake.Generate(quantidade);
    }
}
