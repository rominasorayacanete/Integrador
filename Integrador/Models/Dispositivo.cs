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
    public abstract class Dispositivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreGenerico { get; set; }

        public int Consumo { get; set; }

        public int UsoMensualMax { get; set; }

        public int UsoMensualMin { get; set; }

        public abstract bool Inteligente { get; set; }

        public virtual List<Actuador> Actuadores { get; set; }

        public virtual List<Operacion> Operaciones { get; set; }

        public virtual MarcaDispositivo MarcaDispositivo { get; set; }

        public Dispositivo()
        {
            this.Operaciones = new List<Operacion>();
            this.Actuadores = new List<Actuador>();
        }

        public abstract void Encender();

        public abstract void Apagar();

        public abstract void ActivarModoAhorro();


    }
}