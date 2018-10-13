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
        [Required(ErrorMessage = "Nombre de usuario requerido"), StringLength(30)]
        [Display(Name = "Nombre de usuario")]
        public string Nombre_usuario { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        public int? Nro_Documento { get; set; }

        public int? Telefono { get; set; }
    }
}
