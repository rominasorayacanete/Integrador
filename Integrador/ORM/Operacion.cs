namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Operacion")]
    public partial class Operacion
    {
        [Key]
        public int oper_id { get; set; }

        public int? oper_dispositivo { get; set; }

        [StringLength(255)]
        public string oper_descripcion { get; set; }

        public DateTime? oper_fecha { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }
    }
}
