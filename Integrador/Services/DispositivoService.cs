using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Integrador.Models;
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
                .Where(d => d.Nombre == nombre)
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
                disp.Nombre = nombre;
                db.SaveChanges();
            }
        }

        public double ConsumoDispositivo(DateTime Desde, DateTime Hasta, Dispositivo dispositivo)
        {
            //return this.operacionService.ConsumosRango(Desde, Hasta, dispositivo);
            return 0;
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
            var modoAhorro = disp.ModoAhorro;
            if (modoAhorro == false)
            {
                disp.ModoAhorro = true;
                this.operacionService.RegistrarOperacionAhorro(disp);
                db.SaveChanges();
                return;
            }
            throw new Exception("El dispositivo " + _dispositivo.Id + " ya se encuentra en modo ahorro de energia.");
        }

        //public void AdaptarDispositivo(Dispositivo _dispositivo)
        //{
        //    var disp = this.getDispositivo(_dispositivo);
        //    var inteligente = disp.Inteligente;
        //    if (inteligente == false)
        //    {
        //        disp.Inteligente = true;
        //        this.operacionService.RegistrarOperacionConvertir(disp);
        //        db.SaveChanges();
        //        return;
        //    }
        //    throw new Exception("El dispositivo " + _dispositivo.Id + " ya es inteligente.");
        //}

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