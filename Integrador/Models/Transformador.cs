using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Transformador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public double EnergiaSuministrada { get; set; }

        [Required]
        public double Latitud { get; set; }

        [Required]
        public double Longitud { get; set; }

        [NotMapped]
        public virtual ZonaGeografica ZonaGeografica { get; set; }

    }
}

