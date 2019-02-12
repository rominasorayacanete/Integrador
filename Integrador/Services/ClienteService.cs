using System.Linq;
using Integrador.Models;
using Integrador.DAL;
using System;
using Integrador.Models.Helper;

namespace Integrador.Services
{
    public class ClienteService
    {
        private Context db = new Context();
        private DispositivoService dispositivoService = new DispositivoService();

        public Cliente findClientByUserId(int userId)
        {
            return db.Clientes
                .Where(c => c.Usuario.Id == userId)
                .FirstOrDefault();
        }


        public Cliente FindById(int clienteId)
        {
            return db.Clientes
            .Where(c => c.Id == clienteId)
            .FirstOrDefault();
        }


        public void createNewCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        public void updateGeoCliente(Cliente cliente, double latitud, double longitud)
        {
            var cli = db.Clientes.SingleOrDefault(c => c.Id == cliente.Id);
            if (cli != null)
            {
                cli.Latitud = latitud;
                cli.Longitud = longitud;
                db.SaveChanges();
            }
        }

        public string NombreCliente(string username)
        {
            var cliente = db.Clientes.FirstOrDefault(c => c.Usuario.Username == username);
            return cliente.Nombre;
        }

        public string ApellidoCliente(string username)
        {
            var cliente = db.Clientes.FirstOrDefault(c => c.Usuario.Username == username);
            return cliente.Apellido;
        }

        public int PuntosCliente(string username)
        {
            var cliente = db.Clientes.FirstOrDefault(c => c.Usuario.Username == username);
            return cliente.Puntos;
        }

        public ConsumosTotales ConsumoTotal(Cliente cliente, DateTime desde, DateTime hasta)
        {
            ConsumosTotales consumosTotales = new ConsumosTotales();
            double total = 0;

            foreach (Dispositivo item in cliente.Dispositivos)
            {
                var tiempoEncendido = dispositivoService.TiempoEncendido(item, desde, hasta);
                total = tiempoEncendido * item.Consumo;
            }

            consumosTotales.Desde = desde;
            consumosTotales.Hasta = hasta;
            consumosTotales.ConsumoTotal = Math.Round(total, 2);
            consumosTotales.DiasTotal = (hasta - desde).TotalDays;
            consumosTotales.Operaciones = dispositivoService.OperacionesDeConsumo(desde, hasta);

            return consumosTotales;
        }
    }
}