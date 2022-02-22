using System;
using System.Collections.Generic;

namespace ERS.Estudos.EFCore50.Dominio.Entidades
{
    public class Pessoa
    {
        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativa { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
    }
}