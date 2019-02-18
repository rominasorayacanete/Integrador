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
        public int Id { get; set; }
        public abstract string Nombre { get; set; }
        public abstract void BajarTemperatura(int valor);
        public abstract void BajarIntensidad(int valor);
        public abstract void CambiarModo(int valor);
    }
}
