using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class TemplateDispositivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(45)]
        public string EquipoConcreto { get; set; }

        [Required]
        public bool Inteligente { get; set; }

        [Required]
        public bool BajoConsumo { get; set; }

        [Required]
        public double Consumo { get; set; }

    }
}