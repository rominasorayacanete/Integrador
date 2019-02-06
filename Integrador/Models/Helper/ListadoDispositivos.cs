using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases.Helper
{
    public class ListadoDispositivos
    {
        public List<DispositivoInteligente> DispositivosInteligente { get; set; }
        public List<DispositivoEstandar> DispositivosEstandar { get; set; }
    }
}