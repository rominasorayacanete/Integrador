using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Administrador
    {
        public DateTime fechaAltaSistema { get; set; }
        public int idSistema { get; set; }

        public int MesesComoAdministrador()
        {
            return Math.Abs((DateTime.Now.Month - fechaAltaSistema.Month) + 12 * (DateTime.Now.Year - fechaAltaSistema.Year));
        }
    }
}