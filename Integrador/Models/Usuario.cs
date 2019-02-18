using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id{ get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
