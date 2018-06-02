using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class DispositivoInteligente : Dispositivo
    {
        public bool Encendido;

        public bool ModoAhorroDeEnergia { get; set; }

        public bool Encendido() = Encendido;

        public bool Apagado() => !Encendido;

        public float EnergiaConsumidaUltimasNHoras(int horas) => ConsumoHora * horas;

        public float EnergiaConsumidaPeriodo(int inicioPeriodo, int finPeriodo)
        {
            return EnergiaConsumidaUltimasNHoras(finPeriodo - inicioPeriodo);
        }

        public void Apagar()
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

        public void Encender()
        {
            if (!Encendido)
            {
                Encendido = true;
            }
            else
            {
                throw new Exception("El dispositivo ya está encendido.");
            }
        }

        public void ActivarModoAhorroDeEnergia()
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

    }
}
