using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoLavarropas : TipoDispositivo
    {
        private string modo;

        public override void CambiarModo(string _modo)
        {
            modo = _modo;
        }
    }
}