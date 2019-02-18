using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Integrador.Models.Abstract;

namespace Integrador.Models.Clases
{
    public class MarcaLG : MarcaDispositivo
    {
        public int Intensidad { get; set; }

        public override string Nombre { get; set; } = "LG";

        public override void BajarTemperatura(int valor)
        {
            throw new NotImplementedException();
        }
        public override void BajarIntensidad(int valor)
        {
            Intensidad = valor;
        }

        public override void CambiarModo(int valor)
        {
            throw new NotImplementedException();
        }
    }
}