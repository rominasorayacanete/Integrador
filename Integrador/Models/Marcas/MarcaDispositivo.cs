using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Abstract
{
    abstract public class MarcaDispositivo
    {
        [Key]
        public virtual double Id { get; set; }
        public abstract string Nombre { get; set; }

        public abstract void BajarTemperatura();
        public abstract void BajarIntensidad();
        public abstract void CambiarModo();
    }
}
