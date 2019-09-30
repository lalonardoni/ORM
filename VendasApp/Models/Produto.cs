using System.Collections.Generic;

namespace VendasApp.Models
{
    public class Produto
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public virtual ICollection<VendaItem> VendaItens { get; set; }
    }
}