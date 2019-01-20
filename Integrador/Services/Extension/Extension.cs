using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Services.Extension
{
    public static class Extension
    {
        public const float RadioTierraKm = 6378.0F;

        public static float DistanciaKm(this double posDestinoLat, double posDestinoLong, double posOrigenLat, double posOrigenLong)
        {
            var difLatitud = (posDestinoLat - posOrigenLat).EnRadianes();
            var difLongitud = (posDestinoLong - posOrigenLong).EnRadianes();

            var a = Math.Sin(difLatitud / 2).AlCuadrado() +
                      Math.Cos(posOrigenLat.EnRadianes()) *
                      Math.Cos(posDestinoLat.EnRadianes()) *
                      Math.Sin(difLongitud / 2).AlCuadrado();
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return RadioTierraKm * Convert.ToSingle(c);

        }

        static double EnRadianes(this double valor)
        {
            return Convert.ToSingle(Math.PI / 180) * valor;
        }

        static double AlCuadrado(this double valor)
        {
            return Math.Pow(valor, 2);
        }
    }

 }