using Integrador.Models.Clases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Regla : IReglaObserver, IReglaSubject
    {

        private bool reglaCumplida { get; set; }
        private List<Actuador> actuadores;


        public Regla()
        {
            this.actuadores = new List<Actuador>();
            this.reglaCumplida = false;
        }

        public bool SeCumple()
        {
            return this.reglaCumplida;
        }

        public void Attach(Actuador actuador)
        {
            if (!actuadores.Contains(actuador))
                actuadores.Add(actuador);
        }


        public void Detach(Actuador actuador)
        {
            if (actuadores.Contains(actuador))
                actuadores.Remove(actuador);
        }


        public void NotifyAllObservers()
        {
            foreach(Actuador actuador in actuadores)
           {
                actuador.Update();
            }
        }


        public void Update(string magnitud)
        {
            /*evaluar magnitud ==>des/activar regla*/
        }

    } //end of class Regla//

}