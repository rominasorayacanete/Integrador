using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Integrador.Models;
using Integrador.Models.Clases.Tipos;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Integrador.Services.Extension;
using Integrador.DAL;
using Integrador.Models.Clases;

namespace Integrador.Services
{
    public class DispositivoService
    {
        private Context db = new Context();
        private OperacionService operacionService = new OperacionService();

        public Dispositivo findDispositivoByName(string nombre)
        {
            return db.Dispositivos
                .Where(d => d.NombreGenerico == nombre)
                .FirstOrDefault();
        }

        public Dispositivo FindById(int dispositivoId)
        {
            return db.Dispositivos
                 .Where(d => d.Id == dispositivoId)
                 .FirstOrDefault();
        }

        public void createNewDispositivo(Dispositivo dispositivo)
        {
            db.Dispositivos.Add(dispositivo);
            db.SaveChanges();
        }

        public void cambiarNombre(Dispositivo dispositivo, string nombre)
        {
            var disp = db.Dispositivos.SingleOrDefault(d => d.Id == dispositivo.Id);
            if (disp != null)
            {
                disp.NombreGenerico = nombre;
                db.SaveChanges();
            }
        }

        public double TiempoEncendido(Dispositivo dispositivo, DateTime desde, DateTime hasta)
        {
            List<Operacion> listadoOperacionesEncendidas = db.Operaciones.Where(o => (o.Fecha >= desde && o.Fecha <= hasta) && o.Tipo == "encender").ToList();
            double totalHoras = 0;
            foreach (var primeraOperacion in listadoOperacionesEncendidas)
            {
                var siguienteOperacion = SiguienteOperacionApagada(primeraOperacion);
                if (siguienteOperacion != null)
                {
                    totalHoras += (siguienteOperacion.Fecha - primeraOperacion.Fecha).TotalHours;
                }
                else
                {
                    totalHoras += (hasta - primeraOperacion.Fecha).TotalHours;
                }
            }
            return totalHoras;
        }

        public List<Operacion> OperacionesDeConsumo(DateTime desde, DateTime hasta)
        {
            return db.Operaciones.Where(o => (o.Fecha >= desde && o.Fecha <= hasta) && (o.Tipo == "encender" || o.Tipo == "apagar")).ToList();
        }

        private Operacion SiguienteOperacionApagada(Operacion operacion)
        {
            Operacion item = db.Operaciones.FirstOrDefault(o => o.Fecha <= operacion.Fecha && o.Tipo == "apagar");
            return item;
        }


        public double ConsumoDispositivo(DateTime Desde, DateTime Hasta, Dispositivo dispositivo)
        {
            return this.operacionService.ConsumosRango(Desde, Hasta, dispositivo);
        }

        public void ApagarDispositivo(DispositivoInteligente _dispositivo)
        {
            var disp = this.getDispositivo(_dispositivo);
            var encendido = disp.Encendido;
            if (encendido)
            {
                disp.Encendido = false;
                this.operacionService.RegistrarOperacionApagar(disp);
                db.SaveChanges();
                return;
            }
            throw new Exception("El dispositivo " + _dispositivo.Id + " ya se encuentra apagado.");
        }

        public void EncenderDispositivo(DispositivoInteligente _dispositivo)
        {
            var disp = this.getDispositivo(_dispositivo);
            var encendido = disp.Encendido;
            if (encendido == false)
            {
                disp.Encendido = true;
                this.operacionService.RegistrarOperacionEncender(disp);
                db.SaveChanges();
                return;
            }
            throw new Exception("El dispositivo " + _dispositivo.Id + " ya se encuentra encendido.");
        }

        public void CambiarModoAhorroDispositivo(DispositivoInteligente _dispositivo)
        {
            var disp = this.getDispositivo(_dispositivo);
            var modoAhorro = disp.ModoAhorroDeEnergia;
            if (modoAhorro == false)
            {
                disp.ModoAhorroDeEnergia = true;
                this.operacionService.RegistrarOperacionAhorro(disp);
                db.SaveChanges();
                return;
            }
            throw new Exception("El dispositivo " + _dispositivo.Id + " ya se encuentra en modo ahorro de energia.");
        }

        public void AdaptarDispositivo(Dispositivo _dispositivo)
        {
            var disp = this.getDispositivo(_dispositivo);
            var inteligente = disp.Inteligente;
            if (inteligente == false)
            {
                disp.Inteligente = true;
                this.operacionService.RegistrarOperacionConvertir(disp);
                db.SaveChanges();
                return;
            }
            throw new Exception("El dispositivo " + _dispositivo.Id + " ya es inteligente.");
        }

        private DispositivoInteligente getDispositivo(Dispositivo _dispositivo)
        {
       /*     var dipositivo = db.DispositivosInteligentes.SingleOrDefault(d => d == _dispositivo);
            if (dipositivo != null)
            {
                return dipositivo;
            }
         */   throw new Exception("Error - No se encontro el dispositivo con Id " + _dispositivo.Id);
        }

    }
}