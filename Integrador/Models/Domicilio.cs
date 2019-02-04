using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    public class Domicilio
    {
        [Key]
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }
        public char Departamento { get; set; }
    }
}