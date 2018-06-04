using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Actuador
    {   
        public string magnitud { get; set; }
        public Sensor sensor { get; set; }
        public Dispositivo dispositivo;

        
        public void ActivarModoAhorroDeEnergia()
        {
            dispositivo.ActivarModoAhorroDeEnergia();
        }

        public void AgendarAccion(string accion)
        {
            dispositivo.agendarAccion( accion );
        }

        public void Apagar()
        {
            dispositivo.Apagar();
        }

        public void BajarIntensidad()
        {
            dispositivo.bajarIntensidad();
        }

        public void CambiarModoOperacion()
        {
            dispositivo.cambiarModoOperacion();
        }

        public void ConfigurarTimer()
        {
            dispositivo.configurarTimer();
        }

        public void Encender()
        {
            dispositivo.Encender();
        }

        public void SubirIntensidad()
        {
            dispositivo.subirIntensidad();
        }

    }
 }

