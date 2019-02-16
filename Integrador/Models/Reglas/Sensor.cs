using Integrador.Models.Interface;
using Integrador.Models.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }

        public string Magnitud { get; set; }

        public string Descripcion { get; set; }
        
        public virtual List<Medicion> Mediciones { get; set; }

        public List<Regla> Reglas { get; set; }

        public Sensor()
        {
            this.Reglas = new List<Regla>();
        }


        public void ObtenerMedicion()
        {
            Random random = new Random();
            var maximum = 80;
            var minimum = 20;

            double medicion = random.NextDouble() * (maximum - minimum) + minimum;
            NotifyAllObservers(Magnitud, medicion);
        }


        public void Attach(Regla regla)
        {
            if (!Reglas.Contains(regla))
                Reglas.Add(regla);
        }


        public void Detach(Regla regla)
        {
            if (Reglas.Contains(regla))
                Reglas.Remove(regla);
        }


        public void NotifyAllObservers(string magnitud,double medicion)
        {
            foreach(Regla regla in Reglas)
           {
                regla.Update(magnitud, medicion);
            }
        }

    }

}