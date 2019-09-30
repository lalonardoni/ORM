using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto.Model
{
    public class Produto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public byte[] Foto { get; set; }

        [Column("PrecoProduto")]
        public decimal Valor { get; set; }

        public GrupoProduto Grupo { get; set; }

        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
