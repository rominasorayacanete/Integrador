using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string IdSistema { get; set; }

        [Required]
        public virtual Usuario Usuario { get; set; }
    }
}