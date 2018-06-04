using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public float consumoMinimo { get; set; }
        public float consumoMaximo { get; set; }
        public float cargoFijo { get; set; }
        public float cargoVariable { get; set; }
    }
}
