using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Operacion
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }

        public Operacion()
        {
            Fecha = DateTime.Now;   
        }
    }
}