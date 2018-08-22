using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class ZonaGeografica
    {
        public List<Transformador> Transformadores { get; set; }
        public int Radio { get; set; }
        public string NombreZona { get; set; }

        public ZonaGeografica(int _radio, string _NombreZona)
        {
            Transformadores = new List<Transformador>();
            Radio = _radio;
            NombreZona = _NombreZona;
        }

        public int ConsumoTotal()
        {
            int consumoTotal = 0;

            foreach (Transformador t in Transformadores)
            {
                consumoTotal += t.EnergiaSuministrada;
            }

            return consumoTotal;
        }
    }
}
