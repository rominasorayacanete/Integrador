using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Reglas2
    {
        public int Id { get; set; }
        public bool ReglaCumplida { get; set; } = false;
        public string Condicion { get; set; }

    }
}