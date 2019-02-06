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
            if (!ModoAhorroDeEnergia)
            {
                ModoAhorroDeEnergia = true;
            }
            else
            {
                throw new Exception("El dispositivo ya se encuentra en modo ahorro de energía.");
            }
        }

        public override void Apagar()
        {
            if (Encendido)
            {
                Encendido = false;
            }
            else
            {
                throw new Exception("El dispositivo ya está apagado.");
            }
        }

        public override void Encender()
        {
            if (Encendido)
            {
                Encendido = true;
            }
            else
            {
                throw new Exception("El dispositivo ya está encendido.");
            }
        }

    }
}
