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

        public Operacion RegistrarOperacionApagar(Dispositivo _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " fue apagado.";
            return this.CrearOperacion(_dispositivo, "apagar", descripcion);
        }


        public Operacion RegistrarOperacionEncender(Dispositivo _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " fue encendido.";
            return this.CrearOperacion(_dispositivo, "encender", descripcion);
        }


        public Operacion RegistrarOperacionAhorro(Dispositivo _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " cambio a modo ahorro de energia";
            return this.CrearOperacion(_dispositivo, "ahorro-energia", descripcion);
        }


        public Operacion RegistrarOperacionConvertir(Dispositivo _dispositivo)
        {
            var descripcion = "Dispositivo " + _dispositivo.Id + " fue convertido a inteligente.";
            return this.CrearOperacion(_dispositivo, "convertir", descripcion);
        }

        private Operacion CrearOperacion(Dispositivo _dispositivo, string _tipo, string _descripcion)
        {
             Operacion operacion = new Operacion()
            {
                Descripcion = _descripcion,
                Fecha = DateTime.Now,
                Tipo = _tipo,
                Dispositivo = _dispositivo
            };
            return operacion;
        }

        public void EliminarOperacionesDispositivo(int id) {
            foreach (Operacion operacion in db.Operaciones)
            {
                if (operacion.Dispositivo.Id == id)
                    db.Operaciones.Remove(operacion);
            }

            db.SaveChanges();
        }

    }
}