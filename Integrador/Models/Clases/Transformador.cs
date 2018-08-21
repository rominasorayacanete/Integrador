using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Transformador
    {
        private ZonaGeografica zonaGeografica { get; set; }
        public int energiaSuministrada { get; set; }

        public Transformador(ZonaGeografica _zonaGeografica, int _energiaSuministrada)
        {
            zonaGeografica = _zonaGeografica;
            energiaSuministrada = _energiaSuministrada;
        }
    }
}

