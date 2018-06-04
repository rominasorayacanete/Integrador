using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        private int puntos;
        private DateTime fecha_alta_servicio;
        private Categoria categoria;
        private Dispositivo[] dispositivos;

        public bool Tiene_dispositivos_encendidos()
        {
            foreach (Dispositivo d in dispositivos)
            {
                if (d.Encendido) return true;
            }

            return false;
        }

        public int Cantidad_dispositivos_encendidos()
        {
            int cant = 0;

            foreach (Dispositivo d in dispositivos)
            {
                if (d.Encendido) cant++;
            }

            return cant;
        }

        public int Cantidad_dispositivos_apagados() => Cantidad_dispositivos_encendidos() - dispositivos.Length;

        public int Cantidad_dispositivos() => dispositivos.Length;
    }
}
