using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Transformador
    {
        public String Nombre { get; set; }
        public ZonaGeografica ZonaGeografica { get; set; }
        public Boolean Activo { get; set; }
        public float EnergiaSuministrada { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Transformador(String _Nombre, ZonaGeografica _ZonaGeografica, Boolean _Activo, float _EnergiaSuministrada, double _Latitud, double _Longitud)
        {
            Nombre = _Nombre;
            ZonaGeografica = _ZonaGeografica;
            Activo = _Activo;           
            EnergiaSuministrada = _EnergiaSuministrada;
            Latitud = _Latitud;
            Longitud = _Longitud;
        }
    }
}

