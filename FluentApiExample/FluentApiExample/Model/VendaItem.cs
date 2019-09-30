using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiExample.Model
{
    public class VendaItem
    {
        public long Id { get; set; }

        public long ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public long VendaId { get; set; }

        public virtual Venda Venda { get; set; }

        public int Quantidade
        {
            get { return _quantidade; }
            set
            {
                _quantidade = value;
                CalcularValorFinal();
            }
        }
        private int _quantidade { get; set; }

        public decimal Valor { get; private set; }

        public decimal Desconto
        {
            get { return _desconto; }
            set
            {
                _desconto = value;
                CalcularValorFinal();
            }
        }
        private decimal _desconto { get; set; }

        private void CalcularValorFinal()
        {
            if (this.Produto != null)
            {
                this.Valor = (Quantidade * Produto.Valor) - Desconto;
            }
        }
    }
}
