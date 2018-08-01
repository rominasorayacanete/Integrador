using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Tipos
{
    class TipoAireAcondicionado : TipoDispositivo
    {
        private int min = 90;
        private int max = 360;
        private int temperatura;

        public int Temperatura { get => temperatura; set => temperatura = value; }

        //public usosMensualesEstablecidos(int min, int max);

        public override void BajarTemperatura()
        {
            // funcionalidad
            temperatura -= 1;
        }

        public override void BajarIntensidad()
        {
        }

    }
}