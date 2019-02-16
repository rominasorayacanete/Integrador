using Integrador.Models.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Helper
{
    public class ActuadorDispositivo
    {
        public virtual Dispositivo Dispositivo { get; set; }
        public virtual List<Regla> Reglas { get; set; }
        public string Accion { get; set; }
    }
}