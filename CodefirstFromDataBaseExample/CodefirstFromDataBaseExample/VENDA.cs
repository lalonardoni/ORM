namespace CodefirstFromDataBaseExample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENDA")]
    public partial class VENDA
    {
        public int ID { get; set; }

        public int? CLIENTE { get; set; }

        public int? PRODUTO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATAVENDA { get; set; }

        public virtual CLIENTE CLIENTE1 { get; set; }

        public virtual PRODUTO PRODUTO1 { get; set; }
    }
}
