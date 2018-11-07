using System;
using Integrador.Services;
using Integrador.ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_unitarios
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void Test_CrearUsuarioModificarlo_ObtenerUsuarioModificado()
        {
            UserService userService = new UserService();
            ClienteService clienteService = new ClienteService();

            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.username = "test1";
            nuevoUsuario.password = "password";
            nuevoUsuario.email = "email@email.com";

            userService.createNewUser(nuevoUsuario);

            Cliente nuevoCliente = new Cliente();
            nuevoCliente.nombre = "Tester";
            nuevoCliente.apellido = "1";
            nuevoCliente.tipo_doc = "DNI";
            nuevoCliente.nro_doc = 10101010;
            nuevoCliente.latitud = -10.1000;
            nuevoCliente.longitud = -30.1000;
            nuevoCliente.Usuario = nuevoUsuario;

            clienteService.createNewCliente(nuevoCliente);

            var usuario = userService.findUserByUsername("cliente1");

            Assert.AreEqual("cliente1", usuario.username);

            var cliente = clienteService.findUserByUserId(usuario.id);
            var latitud = cliente.latitud;
            var longitud = cliente.longitud;
            clienteService.updateGeoCliente(cliente, latitud + 10, longitud - 10);

            var clienteLatitud = clienteService.findUserByUserId(usuario.id);

            Assert.AreEqual(latitud + 10, clienteLatitud.latitud);
            Assert.AreEqual(longitud - 10, clienteLatitud.longitud);

        }
    }
}
