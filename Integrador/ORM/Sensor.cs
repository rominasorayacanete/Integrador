namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sensor")]
    public partial class Sensor
    {
        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string magnitud { get; set; }

        public int? regla_id { get; set; }

        public virtual Regla Regla { get; set; }
    }
}
