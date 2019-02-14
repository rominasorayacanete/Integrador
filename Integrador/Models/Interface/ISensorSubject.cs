using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Clases.Interface
{
    public interface ISensorSubject
    {
        void Attach(IReglaObserver regla);
        void Detach(IReglaObserver regla);
        void NotifyAllObservers(string magnitud, double valor);
    }

}
