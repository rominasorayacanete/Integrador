using Integrador.Models.Clases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Sensor : ISensorSubject
    {

        private string magnitud;
        private List<IReglaObserver> reglas;


        public Sensor(string magnitud)
        {
            this.reglas = new List<IReglaObserver>();
            this.magnitud = magnitud;
        }


        public string magnitud
        {
            get { return this.magnitud; }
            set
            {
                if (this.magnitud != value)
                {
                    this.magnitud = value;
                    NotifyAllObservers()
                     }
            }
        }


        public void Attach(IReglaObserver regla)
        {
            if (!reglas.Contains(regla))
                reglas.Add(regla);
        }


        public void Detach(IReglaObserver regla)
        {
            if (reglas.Contains(regla))
                reglas.Remove(regla);
        }


        public void NotifyAllObservers()
        {
            ForEach(IReglaObserver regla in reglas)
           {
                regla.Update(magnitud);
            }
        }

    } //end of class Sensor//

}