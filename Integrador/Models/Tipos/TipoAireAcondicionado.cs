using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoAireAcondicionado : MarcaDispositivo
    {
        public override int UsoMensualMin { get; set; } = 90;
        public override int UsoMensualMax { get; set; } = 360;
        private int Temperatura { get; set; }

        public TipoAireAcondicionado(string _EquipoConcreto, int _Temperatura)
        {
            EquipoConcreto = _EquipoConcreto;
            Temperatura = _Temperatura;
        }

        public override void BajarTemperatura()
        {
            Temperatura -= 1;
        }

    }
}