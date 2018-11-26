using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoComputadora : MarcaDispositivo
    {
        public override int UsoMensualMin { get; set; } = 60;
        public override int UsoMensualMax { get; set; } = 360;

        public TipoComputadora(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }
    }
}