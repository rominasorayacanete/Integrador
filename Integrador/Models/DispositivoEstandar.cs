using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class DispositivoEstandar : Dispositivo
    {
        public int UsoEstimado { get; set; }
        public Adaptador Adaptador { get; set; }
        
        public void Encenderse()
        {
            Adaptador.Encenderse();
        }

        public void Apagarse()
        {
            Adaptador.Apagarse();
        }

        public void _ModoAhorro()
        {
            Adaptador._ModoAhorro();
        }

        public float EnergiaConsumida(int horas)
        {
            return Adaptador.EnergiaConsumida(horas);
        }
    }
}