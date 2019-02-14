using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Integrador.Services;
using Integrador.Models;
using Integrador.DAL;
using System.Collections.Generic;

namespace Tests_unitarios
{
    [TestClass]
    public class Test2
    {
        private Context db = new Context();
        private DispositivoService dispositivoService = new DispositivoService();
        private OperacionService operacionService = new OperacionService();

        [TestMethod]
        public void CasoDePrueba2()
        {
            var dispositivo = dispositivoService.FindById(1);
            // Muestro por consola los intervalos en los que estuvo encendido un dispositivo durante el último mes         
            operacionService.MostrarIntervalosEncendidoUltimoMes(dispositivo);

            // Modifico el nombre del dispositivo y lo grabo
            dispositivoService.CambiarNombreDispositivo(dispositivo, "NombreModificado");

            // Recupero el dispositivo y verifico que el nombre se haya modificado correctamente
            Assert.AreEqual("NombreModificado", dispositivoService.FindById(1).NombreGenerico);
        }
    }
}
