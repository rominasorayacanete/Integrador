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

        public void AdaptarDispositivo(DispositivoInteligente _dispositivo)
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

        private DispositivoInteligente getDispositivo(DispositivoInteligente _dispositivo)
        {
            var dipositivo = db.DispositivosInteligentes.SingleOrDefault(d => d == _dispositivo);
            if (dipositivo != null)
            {
                return dipositivo;
            }
            throw new Exception("Error - No se encontro el dispositivo con Id " + _dispositivo.Id);
        }

    }
}