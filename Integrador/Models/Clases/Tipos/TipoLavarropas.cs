using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoLavarropas : TipoDispositivo
    {
        private int min = 6;
        private int max = 30;
        private string modo;

        public usosMensualesEstablecidos(int min, int max);

        public override void CambiarModo(string _modo)
        {
            modo = _modo;
        }
    }
}