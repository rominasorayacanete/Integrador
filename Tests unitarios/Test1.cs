using System;
using Integrador.DAL;
using Integrador.Models;
using Integrador.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_unitarios
{
    [TestClass]
    public class Test1
    {
        private Context db = new Context();
        private UserService userService = new UserService();
        private ClienteService clienteService = new ClienteService();

        [TestMethod]
        public void CasoDePrueba1()
        {
            // Creo usuario

            Usuario usuario = new Usuario()
            {
                Username = "username",
                Password = "password",
                Email = "juan_perez@gmail.com",
            };

            Cliente cliente = new Cliente()
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                TipoDoc = "DNI",
                NroDoc = 12345678,
                Latitud = -10.1000,
                Longitud = -30.1000,
                Usuario = usuario
            };

            // Persisto usuario

            db.Usuarios.Add(usuario);
            db.SaveChanges();
            db.Clientes.Add(cliente);
            db.SaveChanges();
            
            // Recupero usuario

            cliente = clienteService.findClientByUserId(usuario.Id);
            var latitud = cliente.Longitud;
            var longitud = cliente.Longitud;
            
            // Modifico geolocalización de usuario

            clienteService.updateGeoCliente(cliente, latitud + 10, longitud - 10);

            // Verifico que el cambio se haya realizado
            Cliente clienteModificado = clienteService.findClientByUserId(usuario.Id);
            Assert.AreEqual(latitud + 10, clienteModificado.Latitud);
            Assert.AreEqual(longitud - 10, clienteModificado.Longitud);
        }
    }
}
