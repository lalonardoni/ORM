using System;
using System.Collections.Generic;

namespace VendasApp.Models
{
    public class Cliente
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public virtual ICollection<Venda> ComprasRealizadas { get; set; }
    }

}