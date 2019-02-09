using Integrador.Models.Clases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Regla : IReglaSubject , IReglaObserver
    {

        public int Id { get; set; }
        public bool ReglaCumplida { get; set; } = false;
        public string Condicion { get; set; }

        public virtual List<Actuador> Actuadores { get; set; }

        public bool SeCumple()
        {
            return this.ReglaCumplida;
        }

        public void Attach(Actuador actuador)
        {
            if (!Actuadores.Contains(actuador))
                Actuadores.Add(actuador);
        }


        public void Detach(Actuador actuador)
        {
            if (Actuadores.Contains(actuador))
                Actuadores.Remove(actuador);
        }


        public void NotifyAllObservers()
        {
            foreach(Actuador actuador in Actuadores)
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