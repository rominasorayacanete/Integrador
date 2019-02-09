using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class ModuloAdaptador
    {
        public int ID { get; set; }
        public bool Encendido { get; set; } = false;
        public bool ModoAhorroDeEnergia { get; set; } = false;
        public DispositivoEstandar Dispositivo;
    }
}
