using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Integrador.Models.Abstract;

namespace Integrador.Models.Clases
{
    public class MarcaSony : MarcaDispositivo
    {
        public override string Nombre { get; set; } = "Sony";

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