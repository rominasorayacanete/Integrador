using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Sensor
    {
        private string magnitud { get; set; }
        private int intervaloMedicicion { get; set; }
        private Actuador Actuador;

        public void TomarMedicion()
        {
           Actuador.magnitud = this.magnitud;
        }

    }
}