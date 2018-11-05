namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrador")]
    public partial class Administrador
    {
        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string id_sistema { get; set; }

        [StringLength(15)]
        public string usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
