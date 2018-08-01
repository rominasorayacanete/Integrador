using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string NombreGenerico { get; set; }
        public float ConsumoHora { get; set; }
        public bool Encendido { get; set; }
    }
}