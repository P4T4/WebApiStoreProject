namespace ApiRestStoreProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("venta")]
    public partial class venta
    {
        [Key]
        public int id_venta { get; set; }

        public int cantidad { get; set; }

        public double valor_total { get; set; }

        public int id_producto { get; set; }

        public int id_cliente { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual producto producto { get; set; }
    }
}
