using System;
using System.Collections.Generic;
using Integrador.Models.Clases;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public Domicilio Domicilio { get; set; }
        public int Puntos { get; set; } 
        public int Telefono { get; set; }
        public Categoria Categoria { get; set; }
        public Transformador Transformador { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        public void RegistrarDispositivo(Dispositivo dispositivo)
        {
            dispositivo.Cliente = this;
            Puntos += 15;
        }
    }
}
