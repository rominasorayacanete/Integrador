using Integrador.Models.Interface;
using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Integrador.Models.Clases;

namespace Integrador.Models
{
    public class Actuador : IActuadorObserver
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Accion { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }
        public virtual List<Regla> ReglasRequeridas { get; set; }

        public void Update()
          {
              if (SeCumplenTodasLasReglas())
              {
                // Listado de todo lo que puede hacer con respecto a la accion
                //accion.Accionar(dispositivo)
                    Dispositivo.Encender();
              }
          }
          public bool SeCumplenTodasLasReglas()
          {
              foreach(Regla regla in ReglasRequeridas)
             {
                  if (!regla.SeCumple())
                  {
                      return false;
                  }
              }
              return true;
          }

          public void Update(bool estadoRegla)
          {
              throw new NotImplementedException();
          }
    }
}

