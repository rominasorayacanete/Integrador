using System.Collections.Generic;
using Newtonsoft.Json;
using Integrador.DAL;
using Integrador.Models;
using Integrador.Models.Clases;
using System.Linq;
using System;

namespace Integrador.Services
{
    public class OperacionService
    {
        private Context db = new Context();

        public double ConsumosRango(DateTime Desde, DateTime Hasta, Dispositivo dispositivo)
        {
            List<Operacion> operaciones = db.Operaciones
                .Where(o => (o.Fecha >= Desde && o.Fecha <= Hasta) 
                && o.Dispositivo == dispositivo 
                && (o.Tipo == "apagar" || o.Tipo == "encender"))
                .ToList();

            return (operaciones.Count() * dispositivo.Consumo) / 2;
        }

        public void RegistrarOperacionApagar(DispositivoInteligente _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " fue apagado.";
            this.CrearOperacion(_dispositivo, "apagar", descripcion);
        }


        public void RegistrarOperacionEncender(DispositivoInteligente _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " fue encendido.";
            this.CrearOperacion(_dispositivo, "encender", descripcion);
        }


        public void RegistrarOperacionAhorro(DispositivoInteligente _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " cambio a modo ahorro de energia";
            this.CrearOperacion(_dispositivo, "ahorro-energia", descripcion);
        }


        public void RegistrarOperacionConvertir(Dispositivo _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " fue convertido a inteligente.";
            this.CrearOperacion(_dispositivo, "convertir", descripcion);
        }

        private void CrearOperacion(Dispositivo _dispositivo, string _tipo, string _descripcion)
        {
            Operacion operacion = new Operacion()
            {
                Descripcion = _descripcion,
                Fecha = new System.DateTime(),
                Tipo = _tipo,
                Dispositivo = _dispositivo
            };
            db.Operaciones.Add(operacion);
        }

    }
}