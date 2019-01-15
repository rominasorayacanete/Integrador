using System;
using Integrador.Services;
using Integrador.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_unitarios
{
    [TestClass]
    public class Test1
    {
        /*Crear 1 usuario nuevo. Persistirlo. Recuperarlo, modificar la geolocalización y
            grabarlo. Recuperarlo y evaluar que el cambio se haya realizado
            */

        [TestMethod]
        public void Test_CrearUsuarioModificarlo_ObtenerUsuarioModificado()
        {
            UserService userService = new UserService();
            ClienteService clienteService = new ClienteService();

            var Seed = DateTime.Now.ToString("HHmmss");
            var username = "test" + Seed;

            Usuario nuevoUsuario = new Usuario()
            {
                Username = username,
                Password = "password",
                Email = "email@email.com",
            };

            Cliente nuevoCliente = new Cliente()
            {
                Nombre = "Tester",
                Apellido = "1",
                TipoDoc = "DNI",
                NroDoc = 10101010,
                Latitud = -10.1000,
                Longitud = -30.1000,
                Usuario = nuevoUsuario
            };

            clienteService.createNewCliente(nuevoCliente);
            
            var usuario = userService.findUserByUsername(username);

            Assert.AreEqual(username, usuario.Username);

            var cliente = clienteService.findClientByUserId(usuario.Id);
            var latitud = cliente.Longitud;
            var longitud = cliente.Longitud;
            
            clienteService.updateGeoCliente(cliente, latitud + 10, longitud - 10);

            var clienteUpdated = clienteService.findClientByUserId(usuario.Id);

            Assert.AreEqual(latitud + 10, clienteUpdated.Latitud);
            Assert.AreEqual(longitud - 10, clienteUpdated.Longitud);
        }
    }
}
