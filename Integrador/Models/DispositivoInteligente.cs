using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Integrador.Models
{
    public class DispositivoInteligente : Dispositivo
    {
        public bool ModoAhorro { get; set; }

        public void Encenderse()
        {
            Encendido = true;
            ModoAhorro = false;
        }

        public void Apagarse()
        {
            Encendido = false;
        }
        
        public void _ModoAhorro()
        {
            ModoAhorro = true;
        }

        public float EnergiaConsumida(int horas) => ConsumoPorHora * horas;
    }
}
