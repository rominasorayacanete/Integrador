using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class DispositivoEstandar : Dispositivo
    {
        public int UsoEstimado { get; set; }
    }
}
