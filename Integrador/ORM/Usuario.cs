namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [StringLength(30)]
        public string Nombre { get; set; }

        [StringLength(30)]
        public string Apellido { get; set; }

        [StringLength(30)]
        public string Tipo_Documento { get; set; }

        [StringLength(30)]
        public string Domicilio { get; set; }

        [Key]
        [StringLength(30)]
        public string Nombre_usuario { get; set; }

        [StringLength(30)]
        public string Contrasenia { get; set; }

        public int? Nro_Documento { get; set; }

        public int? Telefono { get; set; }
    }
}
