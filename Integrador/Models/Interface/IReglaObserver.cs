using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Interface
{
    public interface IReglaObserver
    {
        void Update(string magnitud, double valor);
     }
}
