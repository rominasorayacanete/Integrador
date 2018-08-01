using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models//.Clases
{
    public class Transformador
    { 
        public String Nombre { get; set; }
        public Boolean Activo { get; set; }
        public String ZonaGeografica { get; set; }
        public int EnergiaSuministrada { get; set; }

        public Transformador(String _Nombre, Boolean _Activo, String _ZonaGeografica, int _EnergiaSuministrada)
        {
         Nombre = _Nombre;
         Activo = _Activo;
         ZonaGeografica = _ZonaGeografica;
         EnergiaSuministrada = _EnergiaSuministrada;
        }
    }
}

