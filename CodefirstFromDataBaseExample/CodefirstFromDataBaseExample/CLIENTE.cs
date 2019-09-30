namespace CodefirstFromDataBaseExample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTE")]
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            VENDA = new HashSet<VENDA>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string NOME { get; set; }

        [StringLength(50)]
        public string CPF { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATANASCIMENTO { get; set; }

        [StringLength(20)]
        public string TELEFONE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENDA> VENDA { get; set; }
    }
}
