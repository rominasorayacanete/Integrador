using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoTelevisor : TipoDispositivo
    {
        public override int UsoMensualMin { get; set; } = 90;
        public override int UsoMensualMax { get; set; } = 360;
        public override string EquipoConcreto { get; set; }

        public TipoTelevisor(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }

    }
}