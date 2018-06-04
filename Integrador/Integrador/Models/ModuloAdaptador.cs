using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class ModuloAdaptador: Dispositivo
    {
        DispositivoInteligente dispositivoInteligente;

       public void ActivarModoAhorroDeEnergia()
        {
            dispositivoInteligente.ActivarModoAhorroDeEnergia();
        }

        public void AgendarAccion()
        {

        }

        public void Apagar()
        {
            dispositivoInteligente.Apagar();
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
            dispositivoInteligente.Encender();
        }

        public bool Apagado()
        {
            dispositivoInteligente.Apagado();
        }

        public bool Encendido()
        {
            dispositivoInteligente.Encendido();
        }

        public void SubirIntensidad()
        {

        }

    }
}
