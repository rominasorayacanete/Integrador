using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class ZonaGeografica
    {
        private List<Transformador> transformadores { get; set; }
        private int radio { get; set; }

        public ZonaGeografica(int _radio)
        {
            transformadores = new List<Transformador>();
            radio = _radio;
        }

        public int ConsumoTotal()
        {
            int consumoTotal = 0;

            foreach (Transformador t in transformadores)
            {
                consumoTotal += t.energiaSuministrada;
            }

            return consumoTotal;
        }
    }
}
