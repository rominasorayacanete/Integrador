using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Dispositivo
    {
        

        public float consumoPorHora { get; set; }
        public string nombreGenerico { get; set; }
        public Sensor[] Sensores { get => sensores; set => sensores = value; }
    }
}