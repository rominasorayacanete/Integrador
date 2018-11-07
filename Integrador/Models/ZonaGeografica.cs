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
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public ZonaGeografica(int _Radio, string _NombreZona, double _Latitud, double _Longitud)
        {
            Transformadores = new List<Transformador>();
            Radio = _Radio;
            NombreZona = _NombreZona;
            Latitud = _Latitud;
            Longitud = _Longitud;
        }

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
