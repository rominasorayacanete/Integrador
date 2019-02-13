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

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Domicilio { get; set; }

        public DateTime FechaAlta { get; set; }

        public Administrador()
        {
            FechaAlta = DateTime.Now;

        }

        public string GetFullName()
        {
            return Nombre + " " + Apellido;
        }

        public double MesesComoAdministrador()
        {
            DateTime fecharegistro = DateTime.Parse(FechaAlta.ToString());
            return Math.Round((DateTime.Now - fecharegistro).TotalDays, 0);
        }
    }
}