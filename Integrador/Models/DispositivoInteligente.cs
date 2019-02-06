using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public partial  class DispositivoInteligente : Dispositivo
    {
        public bool Encendido { get; set; } = false;

        public bool ModoAhorroDeEnergia { get; set; } = false;

        public override bool Inteligente
        {
            get
            {
                return true;
            }
            set { }
        }

        public DispositivoInteligente()
        {

        }

        public override void ActivarModoAhorro()
        {
            if (ModoAhorroDeEnergia == true)
            {
                throw new Exception("El dispositivo ya se encuentra en modo ahorro de energía.");
            }
            ModoAhorroDeEnergia = true;
        }

        public override void Apagar()
        {
            if (Encendido == false)
            {
                throw new Exception("Este dispositivo ya se encuentra en apagado");
            }
            Encendido = false;

        }

        public override void Encender()
        {
            if (Encendido == true)
            {
                throw new Exception("Este dispositivo ya se encuentra en encendido");
            }
            Encendido = true;
         
        }

    }
}
