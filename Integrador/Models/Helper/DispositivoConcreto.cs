using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Helper
{
    public class DispositivoConcreto
    {
        public int IdDispositivo { get; set; }

        [Required]
        [DisplayName("Uso aproximado (hs)")]
        public int UsoAproximado { get; set; }
    }
}