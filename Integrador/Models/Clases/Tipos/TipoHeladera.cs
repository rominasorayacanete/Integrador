using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoHeladera : TipoDispositivo
    {
        private int intensidad;

        public void BajarIntesidad(int _intensidad)
        {
            intensidad = _intensidad;
        }
    }
}