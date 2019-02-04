using Integrador.Models.Abstract;
using Integrador.Models.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Dispositivo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float ConsumoPorHora { get; set; }
        public bool Encendido { get; set; }
        public Cliente Cliente { get; set; }
    }
}