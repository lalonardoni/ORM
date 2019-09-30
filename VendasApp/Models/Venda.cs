using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendasApp.Models
{
    public class Venda
    {
        public long Id { get; set; }

        [Display(Name="Cliente")]
        public long ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<VendaItem> ItensDaVenda { get; set; }
    }

}