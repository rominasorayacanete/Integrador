using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoComputadora : TipoDispositivo
    {
        private int min = 60;
        private int max = 360;

        public usosMensualesEstablecidos(int min, int max);
    }
}