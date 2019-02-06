using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class DispositivoEstandar : Dispositivo
    {

        public virtual ModuloAdaptador ModuloAdaptador { get; set; }

        public override bool Inteligente
        {
            get
            {
                return false;
            }
            set { }
        }

        public int UsoEstimado { get; set; }

        public void Adaptar(ModuloAdaptador adaptador)
        {
            if (ModuloAdaptador != null)
            {
                throw new Exception("Este dispositivo ya se encuentra adaptado");
            }
            ModuloAdaptador = adaptador;
        }

        public override void ActivarModoAhorro()
        {
            if (ModuloAdaptador != null)
            {
                if (ModuloAdaptador.ModoAhorroDeEnergia)
                {
                    throw new Exception("Este dispositivo ya se encuentra en modo Ahorro");
                }
                ModuloAdaptador.ModoAhorroDeEnergia = true;
            }
            else
            {
                throw new Exception("Este dispositivo no es inteligente!");
            }
        }

        public override void Apagar()
        {
             if (ModuloAdaptador != null)
            {
                if (ModuloAdaptador.Encendido == false)
                {
                    throw new Exception("Este dispositivo ya se encuentra en apagado");
                }
                ModuloAdaptador.Encendido = false;
            }
            else
            {
                throw new Exception("Este dispositivo no es inteligente!");
            }
        }

        public override void Encender()
        {
            if (ModuloAdaptador != null)
            {
                if (ModuloAdaptador.Encendido == true)
                {
                    throw new Exception("Este dispositivo ya se encuentra en encendido");
                }
                ModuloAdaptador.Encendido = true;
            }
            else
            {
                throw new Exception("Este dispositivo no es inteligente!");
            }
        }
    }
}
