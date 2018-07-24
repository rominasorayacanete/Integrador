using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Interface
{
    abstract public class TipoDispositivo
    {
        public int usoMensualMax;
        public int usoMensualMin;

        public int UsoMensualMax { get => usoMensualMax; set => usoMensualMax = value; }
        public int UsoMensualMin { get => usoMensualMin; set => usoMensualMin = value; }

        public usosMensualesEstablecidos(int usoMin, int usoMax)
        {
            set.UsoMensualMax = usoMax;
            set.UsoMensualMin = usoMin;
        }

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
