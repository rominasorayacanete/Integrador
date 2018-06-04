using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public float ConsumoMinimo { get; set; }
        public float ConsumoMaximo { get; set; }
        public float CargoFijo { get; set; }
        public float CargoVariable { get; set; }
    }
}
