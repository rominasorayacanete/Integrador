using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoHeladera : TipoDispositivo
    {
        public override int UsoMensualMin { get; set; } = 90;
        public override int UsoMensualMax { get; set; } = 180;
        public override string EquipoConcreto { get; set; }
        public int Intensidad { get; set; }

        public TipoHeladera(string _EquipoConcreto)
        {
            EquipoConcreto = _EquipoConcreto;
        }

        public void BajarIntesidad(int _intensidad)
        {
            Intensidad -= _intensidad;
        }
    }
}