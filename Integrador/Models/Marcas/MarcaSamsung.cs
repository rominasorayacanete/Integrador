using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Integrador.Models.Abstract;

namespace Integrador.Models.Clases
{
    public class MarcaSamsung : MarcaDispositivo
    {
        public int Temperatura { get; set; }

        public override string Nombre { get; set; } = "Samsung";

        public override void BajarTemperatura(int valor)
        {
            Temperatura = valor;
        }
        public override void BajarIntensidad(int valor)
        {
            throw new NotImplementedException();
        }

        public override void CambiarModo(int valor)
        {
            throw new NotImplementedException();
        }
    }
}