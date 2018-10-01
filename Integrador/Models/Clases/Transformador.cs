using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Transformador
    {
        public string Nombre { get; set; }
        public ZonaGeografica ZonaGeografica { get; set; }
        public Boolean Activo { get; set; }
        public int EnergiaSuministrada { get; set; }

        public Transformador(String _zonaGeografica, int _energiaSuministrada, string _nombre, Boolean _Activo)
        {
            Activo = _Activo;
            Nombre = _nombre;
            ZonaGeografica = _zonaGeografica;
            EnergiaSuministrada = _energiaSuministrada;
        }
    }
}

