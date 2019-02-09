using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Acciones
{
    public class AccionApagar : IAccion
    {
        public void Accionar(Dispositivo dispositivo)
        {
            dispositivo.Apagar();
        }
    }
}