using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Services.Extension
{
    public static class Extension
    {
        public const float RadioTierraKm = 6378.0F;

        public static float DistanciaKm(this float posDestinoLat, float posDestinoLong, float posOrigenLat, float posOrigenLong)
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

        static float EnRadianes(this float valor)
        {
            return Convert.ToSingle(Math.PI / 180) * valor;
        }

        static double AlCuadrado(this double valor)
        {
            return Math.Pow(valor, 2);
        }
    }

 }