using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{

    // Esta clase sirve para logear en la DB los cambios de dispositivos normales a inteligentes.

    public class Operacion
    {
        [Key]
        public int Id { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }

        [StringLength(255)]
        [Required]
        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}