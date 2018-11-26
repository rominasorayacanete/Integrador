using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoLampara : MarcaDispositivo
    {
        public override int UsoMensualMin { get; set; } = 90;
        public override int UsoMensualMax { get; set; } = 360;
        public override string EquipoConcreto { get; set; }

        public TipoLampara(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }
    }
}