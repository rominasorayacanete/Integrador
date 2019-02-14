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
            OperacionService operacionService = new OperacionService();

            // Recupero dispositivo
            Dispositivo dispositivo = dispositivoService.FindById(1);

            // Muestro por consola los intervalos en los que estuvo encendido durante el último mes         
            operacionService.MostrarIntervalosEncendidoUltimoMes(dispositivo);

            // Modifico el nombre del dispositivo y lo grabo
            dispositivoService.CambiarNombreDispositivo(dispositivo, "NombreModificado");

            // Recupero el dispositivo y verifico que el nombre se haya modificado correctamente
            Dispositivo dispositivoModificado = dispositivoService.FindById(1);
            Assert.AreEqual("NombreModificado", dispositivoModificado.NombreGenerico);
        }
    }
}
