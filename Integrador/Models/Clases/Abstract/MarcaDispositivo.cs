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
        public virtual double Consumo { get; set; }
        public virtual int UsoMensualMax { get; set; }
        public virtual int UsoMensualMin { get; set; }
        public virtual string EquipoConcreto { get; set; }


        public virtual void BajarTemperatura()
        {
            throw new NotImplementedException();
        }

        public virtual void BajarIntensidad()
        {
            throw new NotImplementedException();
        }

        public virtual void CambiarModo(string _modo)
        {
            throw new NotImplementedException();
        }
    }
}
