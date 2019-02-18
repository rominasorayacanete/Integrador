using Integrador.Models.Interface;
using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Integrador.Models.Clases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    public class Actuador : IActuadorObserver
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string AccionSlug { get; set; }

        public IAccion Accion { get; set; }

        [ForeignKey("Dispositivo")]
        public int? DispositivoID { get; set; }
        public virtual DispositivoInteligente Dispositivo { get; set; }

        public virtual List<Regla> ReglasRequeridas { get; set; }

        public Actuador(IAccion _accion)
        {
            Accion = _accion;
        }

        public void Update()
          {
              if (SeCumplenTodasLasReglas())
              {
                Accion.Accionar(Dispositivo, 1);
                Dispositivo.Encender();
              }
          }
          public bool SeCumplenTodasLasReglas()
          {
              foreach(Regla regla in ReglasRequeridas)
             {
                  if (regla.SeCumple() == false)
                  {
                      return false;
                  }
              }
              return true;
          }

        public void EjecutarAccion()
        {
            Accion.Accionar(Dispositivo, 1);
        }

    }
}

