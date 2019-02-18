using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Integrador.Models.Abstract;

namespace Integrador.Models.Clases
{
    public class MarcaSony : MarcaDispositivo
    {
        public int Modo { get; set; }

        public override string Nombre { get; set; } = "Sony";

        public override void BajarTemperatura(int valor)
        {
            throw new NotImplementedException();
        }
        public override void BajarIntensidad(int valor)
        {
            throw new NotImplementedException();
        }

        public override void CambiarModo(int valor)
        {
            Modo = valor;
        }
    }
}