using System;
using System.Collections.Generic;

namespace Integrador.Models
{
    public class Cliente : Usuario
    {
        private int Puntos { get; set; }
        private double Latitud { get; set; }
        private double Longitud { get; set; }
        private Categoria Categoria { get; set; }
        private Zona_Geografica Zona_Geografica { get; set; }
        private List<DispositivoEstandar> Dispositivos { get; set; }
        private List<DispositivoInteligente> DispositivosInteligentes { get; set; }


        public void AdaptarDispositivo(DispositivoEstandar dispositivo)
        {
            Dispositivos = new List<DispositivoEstandar>();
            DispositivosInteligentes = new List<DispositivoInteligente>();
            ModuloAdaptador adaptador = new ModuloAdaptador();
            adaptador.AgregarDispositivo(dispositivo);
            // Persistencia del ModuloAdaptador
            Puntos += 10;
        }

        public List<DispositivoInteligente> GetDispositivoInteligentes() => DispositivosInteligentes;      

        public void AgregarDispositivo(DispositivoEstandar dispositivo)
        {
            Dispositivos.Add(dispositivo);
        }

        public void AgregarDispositivoInteligente(DispositivoInteligente dispositivo)
        {
            DispositivosInteligentes.Add(dispositivo);
        }

        public int CantidadDispositivos() => Dispositivos.Count + DispositivosInteligentes.Count;

        public bool tieneDispositivosEncendidos()
        {
            foreach (DispositivoInteligente d in DispositivosInteligentes)
            {
                return d.EstaEncendido();
            }

            return false;
        }

        public int CantidadDispositivosEncendidos()
        {
            int cant = 0;

            foreach (DispositivoInteligente d in DispositivosInteligentes)
            {
                if (d.EstaEncendido()) cant++;
            }

            return cant;
        }

        public int cantidadDispositivosApagados()
        {
            int cant = 0;

            foreach (DispositivoInteligente d in DispositivosInteligentes)
            {
                if (d.EstaApagado()) cant++;
            }

            return cant;
        }
    }
}
