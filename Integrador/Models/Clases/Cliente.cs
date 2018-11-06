using System;
using System.Collections.Generic;
using Integrador.Models.Clases;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        private Categoria categoria { get; set; }
        private List <DispositivoEstandar> dispositivos { get; set; } = new List<DispositivoEstandar>();
        private List<DispositivoInteligente> dispositivosInteligentes { get; set; } = new List<DispositivoInteligente>();
        private DateTime fechaAltaServicio { get; set; }
        public int numeroDocumento { get; set;}
        public int puntos { get; set; }
        public int telefono { get; set; }
        public string tipoDocumento { get; set; }
        private ZonaGeografica ZonaGeografica { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }


        public void AdaptarDispositivo(DispositivoEstandar dispositivo)
        {
            this.dispositivos = new List<DispositivoEstandar>();
            this.dispositivosInteligentes = new List<DispositivoInteligente>();
            ModuloAdaptador adaptador = new ModuloAdaptador();
            adaptador.AgregarDispositivo(dispositivo);
            // Persistencia del ModuloAdaptador
            puntos += 10;
        }

        public List<DispositivoInteligente> GetDispositivoInteligentes()
        {
            return this.dispositivosInteligentes;
        }

        public void AgregarDispositivo(DispositivoEstandar dispositivo)
        {
            dispositivos.Add(dispositivo);
        }

        public void AgregarDispositivoInteligente(DispositivoInteligente dispositivo)
        {
            dispositivosInteligentes.Add(dispositivo);
        }

        public int cantidadDispositivos() => dispositivos.Count + dispositivosInteligentes.Count;

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
