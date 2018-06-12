using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class DispositivoInteligente : Dispositivo
    {

        private bool Encendido { get; set; }
        private bool ModoAhorroDeEnergia { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }

        public virtual void ActivarModoAhorroDeEnergia()
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

        public virtual void Apagar()
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

        public virtual float EnergiaConsumidaUltimasNHoras(int horas)
        {
            return ConsumoPorHora * horas;
        }

        public virtual void Encender()
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

        public virtual bool EstaEncendido()
        {
            return Encendido == true ? true : false ; 
        }

        public virtual bool EstaApagado()
        {
            return Encendido == false ? true : false;
        }
    }
}
