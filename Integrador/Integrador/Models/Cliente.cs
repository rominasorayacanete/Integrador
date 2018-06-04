using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        private int puntos;
        private DateTime fechaAltaServicio;
        private Categoria categoria;
        private Dispositivo[] dispositivos;

        public bool tieneDispositivosEncendidos()
        {
            foreach (Dispositivo d in dispositivos)
            {
                if (d.Encendido) return true;
            }

            return false;
        }

        public int cantidadDispositivosEncendidos()
        {
            int cant = 0;

            foreach (Dispositivo d in dispositivos)
            {
                if (d.Encendido) cant++;
            }

            return cant;
        }

        public int cantidadDispositivosApagados() => cantidadDispositivosEncendidos() - dispositivos.Length;

        public int cantidadDispositivos() => dispositivos.Length;
    }
}
