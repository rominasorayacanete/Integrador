using Integrador.Models.Clases;
using Integrador.Models.Clases.Interface;
using Integrador.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    public class Actuador
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Accion { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }

        

         public void Update()
          {
              if (SeCumplenTodasLasReglas())
              {
                  //accion.Accionar(dispositivo);
              }
          }
          public bool SeCumplenTodasLasReglas()
          {
        /*      foreach(Regla regla in this.Reglas)
             {
                  if (!regla.SeCumple())
                  {
                      return false;
                  }
              }
          */    return true;
          }

          public void Update(bool estadoRegla)
          {
              throw new NotImplementedException();
          }
    }
}

