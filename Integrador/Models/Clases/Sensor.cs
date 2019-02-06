using Integrador.Models.Clases.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Sensor : ISensorSubject
    {
        [Key]
        public int Id;

        public string magnitud;

        public List<IReglaObserver> reglas;

        public Sensor(string magnitud)
        {
            this.reglas = new List<IReglaObserver>();
        }


        public void Obtenermagnitud()
        {
            this.magnitud = "Magnitud4";
            this.NotifyAllObservers(magnitud);
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


        public void NotifyAllObservers(string magnitud)
        {
            foreach(IReglaObserver regla in reglas)
           {
                regla.Update(magnitud);
            }
        }

    }

}