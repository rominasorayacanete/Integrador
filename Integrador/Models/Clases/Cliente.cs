using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        private Categoria categoria { get; set; }
        private DispositivoEstandar[] dispositivos;
        private DispositivoInteligente[] dispositivosInteligentes;
        private DateTime fechaAltaServicio { get; set; }
        private int numeroDocumento { get; set;}
        private int puntos { get; set; }
        private int telefono { get; set; }
        private string tipoDocumento { get; set; }


        public void AdaptarDispositivo(DispositivoEstandar dispositivo)
        {
            ModuloAdaptador adaptador = new ModuloAdaptador();
            adaptador.AgregarDispositivo(dispositivo);
            // Persistencia del ModuloAdaptador
        }

        public int cantidadDispositivos() => dispositivos.Length + dispositivosInteligentes.Length;

        public bool tieneDispositivosEncendidos()
        {
            foreach (DispositivoInteligente d in dispositivosInteligentes)
            {
                if (d.EstaEncendido()) return true;
            }

            return false;
        }

        public int cantidadDispositivosEncendidos()
        {
            int cant = 0;

            foreach (DispositivoInteligente d in dispositivosInteligentes)
            {
                if (d.EstaEncendido()) cant++;
            }

            return cant;
        }

        public int cantidadDispositivosApagados()
        {
            int cant = 0;

            foreach (DispositivoInteligente d in dispositivosInteligentes)
            {
                if (d.EstaApagado()) cant++;
            }

            return cant;
        }

    }
}
