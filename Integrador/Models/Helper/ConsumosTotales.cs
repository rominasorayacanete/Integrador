using Integrador.Models.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Helper
{
    public class ConsumosTotales
    {
        public List<Operacion> Operaciones { get; set; }

        public double DiasTotal { get; set; }

        public double ConsumoTotal { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Desde { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Hasta { get; set; }

        public ConsumosTotales()
        {
            Operaciones = new List<Operacion>();
        }
    }
}