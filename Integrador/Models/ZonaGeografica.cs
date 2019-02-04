using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class ZonaGeografica
    {

        public int Id { get; set; }

        [Required]
        public int Radio { get; set; }

        [Required]
        [StringLength(15)]
        public string NombreZona { get; set; }

        [Required]
        public double Latitud { get; set; }

        [Required]
        public double Longitud { get; set; }

        public virtual List<Transformador> Transformadores { get; set; }


        public double ConsumoTotal()
        {
            double consumoTotal = 0;

            foreach (Transformador t in Transformadores)
            {
                consumoTotal += t.EnergiaSuministrada;
            }

            return consumoTotal;
        }
    }
}
