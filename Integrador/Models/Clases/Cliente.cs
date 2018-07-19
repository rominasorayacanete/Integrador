using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        private Categoria categoria { get; set; }
        private List <DispositivoEstandar> dispositivos;
        private List <DispositivoInteligente> dispositivosInteligentes;
        private DateTime fechaAltaServicio { get; set; }
        private int numeroDocumento { get; set;}
        private int puntos { get; set; }
        private int telefono { get; set; }
        private string tipoDocumento { get; set; }
        private ZonaGeografica zonaHogar { get; set; }


        public void AdaptarDispositivo(DispositivoEstandar dispositivo)
        {
            this.dispositivos = new List<DispositivoEstandar>();
            this.dispositivosInteligentes = new List<DispositivoInteligente>();
            ModuloAdaptador adaptador = new ModuloAdaptador();
            adaptador.AgregarDispositivo(dispositivo);
            // Persistencia del ModuloAdaptador
            puntos += 10;
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
