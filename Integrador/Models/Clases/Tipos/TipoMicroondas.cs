using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoMicroondas : TipoDispositivo
    {
        public override int UsoMensualMin { get; set; } = 3;
        public override int UsoMensualMax { get; set; } = 15;
        public override string EquipoConcreto { get; set; }

        public TipoMicroondas(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }

    }
}