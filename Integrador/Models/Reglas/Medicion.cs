using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Reglas
{
    public class Medicion
    {
        [Key]
        public int Id { get; set; }

        public string Magnitud { get; set; }

        public double Valor { get; set; }

        public DateTime Fecha;

        public Medicion()
        {
            Fecha = DateTime.Now;
        } 
    }
}