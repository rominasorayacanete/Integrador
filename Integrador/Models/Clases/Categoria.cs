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

        [Required]
        public float ConsumoMinimo { get; set; }

        [Required]
        public float ConsumoMaximo { get; set; }

        [Required]
        public float CargoFijo { get; set; }

        [Required]
        public float CargoVariable { get; set; }
    }
}
