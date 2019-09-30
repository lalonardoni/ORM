using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto.Model
{
    public class Cliente
    {
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 5)]
        public string TelefoneResidencial { get; set; }

        [Column(Order = 4)]
        public string Celular { get; set; }

        [Column(Order = 2)]
        public string Nome { get; set; }

        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public string Nome_Celular
        {
            get
            {
                return string.Format("{0} - {1}", Nome, Celular);
            }
        }
    }
}
