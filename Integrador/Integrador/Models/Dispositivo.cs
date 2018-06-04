using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Dispositivo
    {
        public float consumoPorHora { get; set; }
        public string nombreGenerico { get; set; }
        public Sensor[] Sensores { get => sensores; set => sensores = value; }

        public void activarModoAhorroDeEnergia()
        {

        }

        public void agendarAccion(string accion)
        {

        }

        public void apagar()
        {
           
        }

        public void bajarIntensidad()
        {

        }

        public void cambiarModoOperacion()
        {

        }

        public void configurarTimer()
        {

        }

        public void encender()
        {
           
        }

        public void subirIntensidad()
        {

        }

        public void estaEncendido()
        {

        }

        public void estaApagado()
        {

        }
    }
}