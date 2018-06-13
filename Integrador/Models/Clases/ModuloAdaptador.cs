using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class ModuloAdaptador : DispositivoInteligente
    {
        public override TipoDispositivo TipoDispositivo { get; set; }
        private DispositivoEstandar Dispositivo;

        public override void ActivarModoAhorroDeEnergia()
        {
            /*
             *
             * Hacer algo con el dispositivo asociado
             * 
             */
        }

        public override void Apagar()
        {
            /*
             *
             * Hacer algo con el dispositivo asociado
             * 
             */
        }

        public override float EnergiaConsumidaUltimasNHoras(int horas)
        {
            return Dispositivo.ConsumoPorHora * horas;
        }

        public override void Encender()
        {
            /*
             *
             * Hacer algo con el dispositivo asociado
             * 
             */
        }

        public override bool EstaEncendido()
        {
            return Encendido == true ? true : false ; 
        }

        public override bool EstaApagado()
        {
            return Encendido == false ? true : false;
        }

        public void AgregarDispositivo(DispositivoEstandar dispositivo)
        {
            this.Dispositivo = dispositivo;
        }

    }
}
