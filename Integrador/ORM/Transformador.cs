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
        [StringLength(30)]
        public string Nombre { get; set; }

        [StringLength(30)]
        public string ZonaGeografica { get; set; }

        public bool? Activo { get; set; }

        public int? EnergiaSuministrada { get; set; }
    }
}
