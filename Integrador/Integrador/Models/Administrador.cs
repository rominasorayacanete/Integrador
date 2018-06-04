using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Administrador
    {
        private DateTime Fecha_alta_sistema { get; set; }
        private int Id_sistema { get; set; }

        public int Meses_como_administrador() => DateTime.Now.Month - Fecha_alta_sistema.Month;
    }
}