using Integrador.Models.Clases;
using Integrador.Models.Clases.Interface;
using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Actuador : IActuadorObserver
    {

        private DispositivoInteligente dispositivo;
        private List<Regla> reglasRequeridas;
        private IAccion accion;

        public Actuador(List<Regla> reglasRequeridas)
        {
            this.reglasRequeridas = new List<Regla>();
        }

        public void Update()
        {
            if (SeCumplenTodasLasReglas(reglasRequeridas))
            {
                accion.Accionar(dispositivo);
            }
        }

        public bool SeCumplenTodasLasReglas(List<Regla> reglasRequeridas)
        {
            foreach(Regla regla in reglasRequeridas)
           {
                if (!regla.SeCumple())
                {
                    return false;
                }
            }
            return true;
        }

        public void Update(bool estadoRegla)
        {
            throw new NotImplementedException();
        }
    }//end of class Actuador//
 }

