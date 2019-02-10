using System;
using System.Collections.Generic;
using Integrador.Models.Clases;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Integrador.Models
{
    public class Cliente
    {

        public Cliente()
        {
            this.Dispositivos = new List<Dispositivo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(25)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(15)]
        public string TipoDoc { get; set; }

        public int NroDoc { get; set; }

        [StringLength(30)]
        public string Domicilio { get; set; }

        public int Puntos { get; set; }

        public int Telefono { get; set; }

        public double Longitud { get; set; }

        public double Latitud { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Transformador Transformador { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual List<Dispositivo> Dispositivos { get; set; }

        public string NombreRegistro()
        {
            return Nombre + " " + Apellido + "-" + Id;
        }

        public void SumarPuntos(int puntos)
        {
            Puntos += puntos;
        }

        public double ConsumoHogar()
        {
            double total = 0;
            foreach(Dispositivo dispositivo in Dispositivos)
            {
                total = +dispositivo.Consumo;
            }
            return total;
        }

        public List<Dispositivo> GetDispositivos()
        {
            return Dispositivos;
        }

        /*

        public void AdaptarDispositivo(DispositivoEstandar dispositivo)
        {
            this.Dispositivos = new List<DispositivoEstandar>();
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

            foreach (Dispositivo d in Dispositivos)
            {
                if (d.Encendido()) cant++;
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
        */

    }
}
