using Integrador.Models.Clases;
using Integrador.Models.Clases.Interface;
using Integrador.Models.Interface;
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

        public void Update(IReglaSubject regla)
        {
            foreach(IReglaSubject r in reglasRequeridas)
            {
                r.Find(r => r.nombreRegla == regla.nombreRegla)
                r.reglaCumplida = regla.reglaCumplida;
            }

            if (SeCumplenTodasLasReglas(r))
            {
                dispositivo.EjecutarAccion();
            }
        }

        public bool SeCumplenTodasLasReglas(List<Regla> reglasRequeridas)
        {
            ForEach(IReglaObserver regla in reglasRequeridas)
           {
                regla.reglaCumplida();
            }
        }

        public void Update(bool estadoRegla)
        {
            throw new NotImplementedException();
        }
    }//end of class Actuador//
 }

