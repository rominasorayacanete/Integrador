﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Models.Clases.Interface
{
    public interface IActuadorObserver
    {
        void Update(bool estadoRegla);
    }

}