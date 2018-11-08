namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transformador")]
    public partial class Transformador
    {
        [Key]
        public int tran_id { get; set; }

        [StringLength(255)]
        public string tran_nombre { get; set; }

        public bool? tran_activo { get; set; }

        public double? tran_energia_suministrada { get; set; }

        public double? tran_latitud { get; set; }

        public double? tran_longitud { get; set; }

        public int? tran_zona { get; set; }

        public virtual Zona_Geografica Zona_Geografica { get; set; }
    }
}
