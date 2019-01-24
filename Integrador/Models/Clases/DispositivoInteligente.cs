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
        public bool Encendido { get; set; }
        public bool ModoAhorroDeEnergia { get; set; }

        [NotMapped]
        public virtual MarcaDispositivo MarcaDispositivo { get; set; }

        public DispositivoInteligente()
        {

        }

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
            return 2020 * horas;
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
