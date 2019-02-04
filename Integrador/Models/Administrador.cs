using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Administrador : Usuario
    {
        [Key]
        public int Id { get; set; }
        public string IdSistema { get; set; }
    }
}