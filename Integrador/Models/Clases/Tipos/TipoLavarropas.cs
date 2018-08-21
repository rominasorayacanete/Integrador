using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoLavarropas : TipoDispositivo
    {
        public override int UsoMensualMin { get; set; } = 6;
        public override int UsoMensualMax { get; set; } = 30;
        public override string EquipoConcreto { get; set; } = "Automático de 5 kg con calentamiento de agua";

        private string modo;

        public override void CambiarModo(string _modo)
        {
            modo = _modo;
        }
    }
}