using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Abstract
{
    public interface IAccion
    {
        void Accionar(DispositivoInteligente dispositivo, int valor);
    }
}
