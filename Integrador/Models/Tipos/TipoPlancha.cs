using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoPlancha : TipoDispositivo
    {
        public override int UsoMensualMin { get; set; } = 3;
        public override int UsoMensualMax { get; set; } = 30;
        public override string EquipoConcreto { get; set; }

        public TipoPlancha(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }
    }
}