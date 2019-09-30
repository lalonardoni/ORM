using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiExample.Model
{
    public class Venda
    {
        public long Id { get; set; }

        public long ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<VendaItem> ItensDaVenda { get; set; }
    }
}
