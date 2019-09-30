namespace CodefirstFromDataBaseExample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUTO")]
    public partial class PRODUTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUTO()
        {
            VENDA = new HashSet<VENDA>();
        }

        public int ID { get; set; }

        [StringLength(20)]
        public string CODIGO { get; set; }

        [StringLength(50)]
        public string DESCRICAO { get; set; }

        [Column(TypeName = "money")]
        public decimal? VALOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENDA> VENDA { get; set; }
    }
}
