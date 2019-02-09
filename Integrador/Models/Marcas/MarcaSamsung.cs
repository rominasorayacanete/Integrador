using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Integrador.Models.Abstract;

namespace Integrador.Models.Clases
{
    public class MarcaSamsung : MarcaDispositivo
    {
        public int Intensidad { get; set; }

        public override string Nombre { get; set; } = "Samsung";

        public override void BajarTemperatura()
        {
            throw new NotImplementedException();
        }
        public override void BajarIntensidad()
        {
            throw new NotImplementedException();
        }

        public override void CambiarModo()
        {
            throw new NotImplementedException();
        }
    }
}