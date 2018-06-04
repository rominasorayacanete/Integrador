using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Administrador
    {
        private DateTime fechaAltaSistema { get; set; }
        private int idSistema { get; set; }

        public int mesesComoAdministrador() => DateTime.Now.Month - fechaAltaSistema.Month;
    }
}