using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string NombreGenerico { get; set; }

        public int ConsumoPorHora { get; set; }

        public int Consumo { get; set; }

        public int UsoMensualMax { get; set; }

        public int UsoMensualMin { get; set; }

        public bool Inteligente { get; set; }

        [StringLength(15)]
        public string Marca { get; set; }

        public virtual List<Actuador> Actuadores { get; set; }

        public virtual List<Operacion> Operaciones { get; set; }

    }
}