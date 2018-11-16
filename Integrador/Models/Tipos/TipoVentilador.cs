using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoVentilador : TipoDispositivo
    {
        public override int UsoMensualMin { get; set; } = 120;
        public override int UsoMensualMax { get; set; } = 360;
        public override string EquipoConcreto { get; set; }

        public TipoVentilador(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }
    }
}