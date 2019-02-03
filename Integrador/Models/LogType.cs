using Integrador.Models.Clases.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class LogType
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Tipo { get; set; }
    }
}