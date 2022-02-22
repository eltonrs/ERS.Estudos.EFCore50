using System;

namespace ERS.Estudos.EFCore50.Dominio.Entidades
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
