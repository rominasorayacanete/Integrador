using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Interface
{
    abstract public class TipoDispositivo
    {
        public virtual void BajarTemperatura()
        {
            throw new NotImplementedException();
        }

        public virtual void BajarIntensidad()
        {
            throw new NotImplementedException();
        }

        public virtual void CambiarModo()
        {
            throw new NotImplementedException();
        }
    }
}
