using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto.Model
{
    public class GrupoProduto
    {
        public int GrupoProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
