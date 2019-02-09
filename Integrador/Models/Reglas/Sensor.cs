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
        public int Id { get; set; }

        public string Magnitud { get; set; }

        public List<IReglaObserver> Reglas { get; set; }

        public Sensor(string magnitud)
        {
            this.Reglas = new List<IReglaObserver>();
        }


        public void Obtenermagnitud()
        {
            this.Magnitud = "Magnitud4";
            this.NotifyAllObservers(Magnitud);
        }


        public void Attach(IReglaObserver regla)
        {
            if (!Reglas.Contains(regla))
                Reglas.Add(regla);
        }


        public void Detach(IReglaObserver regla)
        {
            if (Reglas.Contains(regla))
                Reglas.Remove(regla);
        }


        public void NotifyAllObservers(string magnitud)
        {
            foreach(IReglaObserver regla in Reglas)
           {
                regla.Update(magnitud);
            }
        }

    }

}