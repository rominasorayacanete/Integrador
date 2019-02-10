using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Helper
{
    public class SimplexData
    {
        public string Dispositivo { get; set; }
        public float HorasDisponiles { get; set; }

        public SimplexData(string _disp, float _horas)
        {
            HorasDisponiles = _horas;
            Dispositivo = _disp;
        }
    }
}