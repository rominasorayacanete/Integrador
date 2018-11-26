using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoPlancha : MarcaDispositivo
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