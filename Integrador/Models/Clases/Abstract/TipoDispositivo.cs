using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Interface
{
    abstract public class TipoDispositivo
    {
        public virtual double Consumo { get; set;}
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
