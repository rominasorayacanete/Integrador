using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Usuario
    {
        [Key]
        public int Id{ get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime FechaAltaSistema { get; set; }
    }
}
