using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Acciones
{
    public class AccionBajarIntesidad : IAccion
    {
        public void Accionar(Dispositivo dispositivo)
        {
           dispositivo.Marca.BajarIntensidad();
        }
    }
}