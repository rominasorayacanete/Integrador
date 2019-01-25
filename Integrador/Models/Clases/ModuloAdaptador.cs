using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class ModuloAdaptador
    {
        public  MarcaDispositivo MarcaDispositivo { get; set; }
        private DispositivoEstandar Dispositivo;

        public  void ActivarModoAhorroDeEnergia()
        {
            /*
             *
             * Hacer algo con el dispositivo asociado
             * 
             */
        }

        public  void Apagar()
        {
            /*
             *
             * Hacer algo con el dispositivo asociado
             * 
             */
        }

        public  float EnergiaConsumidaUltimasNHoras(int horas)
        {
            return Dispositivo.Consumo * horas;
        }

        public  void Encender()
        {
            /*
             *
             * Hacer algo con el dispositivo asociado
             * 
             */
        }

        public  bool EstaEncendido()
        {
            return true == true ? true : false ; 
        }

        public  bool EstaApagado()
        {
            return true == false ? true : false;
        }

        public void AgregarDispositivo(DispositivoEstandar dispositivo)
        {
            this.Dispositivo = dispositivo;
        }

    }
}
