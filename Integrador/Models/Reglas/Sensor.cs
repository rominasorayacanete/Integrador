using Integrador.Models.Interface;
using Integrador.Models.Reglas;
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

        public string Descripcion { get; set; }
        
        public virtual List<Medicion> Mediciones { get; set; }

        public List<IReglaObserver> Reglas { get; set; }

        public Sensor()
        {
            this.Reglas = new List<IReglaObserver>();
        }


        public void ObtenerMedicion()
        {
            Random random = new Random();
            var maximum = 80;
            var minimum = 20;

            double medicion = random.NextDouble() * (maximum - minimum) + minimum;
            NotifyAllObservers(Magnitud, medicion);
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


        public void NotifyAllObservers(string magnitud,double medicion)
        {
            foreach(IReglaObserver regla in Reglas)
           {
                regla.Update(magnitud, medicion);
            }
        }

    }

}