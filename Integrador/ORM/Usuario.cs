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
        [Key]
        [Required(ErrorMessage = "Nombre de usuario requerido"), StringLength(30)]
        [Display(Name = "Nombre de usuario")]
        public string username { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
    }
}
