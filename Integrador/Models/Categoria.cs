using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Categoria
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public float ConsumoMinimo { get; set; }

        public float ConsumoMaximo { get; set; }

        public double CargoFijo { get; set; }

        public double CargoVariable { get; set; }
    }
}
