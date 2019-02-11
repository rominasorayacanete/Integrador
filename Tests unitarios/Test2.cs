using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Integrador.Services;
using Integrador.Models;

namespace Tests_unitarios
{
    [TestClass]
    public class Test2
    {
        [TestMethod]
        public void CasoDePrueba2()
        {
            DispositivoService dispositivoService = new DispositivoService();

            var Seed = DateTime.Now.ToString("HHmmss");
            var name = "Dispo1" + Seed;

            DispositivoInteligente dispositivo1 = new DispositivoInteligente
            {
                NombreGenerico = name,
                Consumo = 100,
                Inteligente = true,
                UsoMensualMax = 1000,
                UsoMensualMin = 10
            };

            dispositivoService.createNewDispositivo(dispositivo1);

            var dispositivoRecuperado = dispositivoService.findDispositivoByName(name);

            // TODO : Mostar el log de veces encendido Console.Write()

            Assert.AreEqual(name, dispositivoRecuperado.NombreGenerico);

            var changeName = "DispoTestCambioNombre" + Seed;
            dispositivoRecuperado.NombreGenerico = changeName;
            dispositivoService.cambiarNombre(dispositivoRecuperado, changeName);

            var finalDisp = dispositivoService.findDispositivoByName(changeName);

            Assert.AreEqual(changeName, finalDisp.NombreGenerico);
        }

    }
}
