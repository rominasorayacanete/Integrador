using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Zona_Geografica
    {
        public int Radio { get; set; }
        public string NombreZona { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public List<Transformador> Transformadores { get; set; }

        public float ConsumoTotal()
        {
            float consumoTotal = 0;

            foreach (Transformador t in Transformadores)
            {
                consumoTotal += t.EnergiaSuministrada;
            }

            return consumoTotal;
        }
    }
}