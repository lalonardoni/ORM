using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto.Model
{
    public class Fornecedor
    {
        [Key]
        public int ChaveFornecedor { get; set; }

        public string Nome { get; set; }

        [Required()]
        [StringLength(14, MinimumLength = 14)]
        public string Cnpj { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
