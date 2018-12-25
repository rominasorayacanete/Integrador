using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class TemplateDispositivo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public bool Inteligente { get; set; }

        public bool BajoConsumo { get; set; }

        public double Consumo { get; set; }

    }
}