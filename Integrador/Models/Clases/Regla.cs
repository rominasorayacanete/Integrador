using Integrador.Models.Clases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Regla : IReglaObserver, IReglaSubject
    {

        private bool reglaCumplida;
        private List<IActuadorObserver> actuadores;


        public Regla(reglaCumplida)
        {
            this.actuadores = new List<Actuador>();
            this.reglaCumplida = reglaCumplida;
        }


        public boolean reglaCumplida
        {
            get { return this.reglaCumplida; }
            set
            {
                if (this.reglaCumplida != value)
                {
                    this.reglaCumplida = value;
                    NotifyAllObservers()
                   }
            }
        }


        public void Attach(IActuadorObserver actuador)
        {
            if (!actuadores.Contains(actuador))
                actuadores.Add(actuador);
        }


        public void Detach(IActuadorObserver actuador)
        {
            if (actuadores.Contains(actuador))
                actuadores.Remove(actuador);
        }


        public void NotifyAllObservers()
        {
            foreach(IActuadorObserver actuador in actuadores)
           {
                actuador.Update(this);
            }
        }


        public void Update(string magnitud)
        {
            /*evaluar magnitud ==>des/activar regla*/
        }

    } //end of class Regla//

}