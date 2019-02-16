using Integrador.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Regla : IReglaSubject , IReglaObserver
    {

        public int Id { get; set; }
        public bool ReglaCumplida { get; set; } = false;
        public string Condicion { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }

        [ForeignKey("Cliente")]
        public int? ClientID { get; set; }
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Sensor")]
        [Display(Name = "Sensor")]
        public int? SensorID { get; set; }
        public virtual Sensor Sensor { get; set; }

        public virtual List<Actuador> Actuadores { get; set; }

        public bool SeCumple()
        {
            return ReglaCumplida;
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

        public void Update(string magnitud, double valorMedido)
        {
            if(Condicion == "menor")
            {
                ReglaCumplida = Valor < valorMedido; 
            }
            else if (Condicion == "mayor")
            {
                ReglaCumplida = Valor >= valorMedido;
            }
            NotifyAllObservers();
        }

    }

}