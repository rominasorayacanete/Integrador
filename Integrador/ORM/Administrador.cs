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
        [Key]
        public int id_sistema { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
