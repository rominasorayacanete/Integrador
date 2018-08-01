using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models//.Clases
{
    public class ZonaGeografica
    {
        public String NombreZona { get; set; }
        public int Radio { get; set; }
        public List<Transformador> Transformadores { get; set; }
        //public int ConsumoTotal { get; set; }


        public ZonaGeografica(String _NombreZona, int _Radio)
        {
            NombreZona = _NombreZona;
            Transformadores = new List<Transformador>();
            Radio = _Radio;
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
