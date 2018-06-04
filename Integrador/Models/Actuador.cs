using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Actuador
    {
        public Dispositivo dispositivo;

        public void ActivarModoAhorroDeEnergia()
        {
            dispositivo.ActivarModoAhorroDeEnergia();
        }

        public void AgendarAccion()
        {

        }

        public void Apagar()
        {
            dispositivo.Apagar();
        }

        public void BajarIntensidad()
        { 
            
        }

        public void CambiarModoOperacion()
        {

        }

        public void ConfigurarTimer()
        {

        }

        public void Encender()
        {
            dispositivo.Encender();
        }

        public void SubirIntensidad()
        {

        }

    }
 }

