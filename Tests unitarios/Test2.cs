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
        Context db = new Context();
        DispositivoService dispositivoService = new DispositivoService();
        OperacionService operacionService = new OperacionService();

        [TestMethod]
        public void CasoDePrueba2()
        {
            // Muestro por consola los intervalos en los que estuvo encendido durante el último mes         
            operacionService.MostrarIntervalosEncendidoUltimoMes(db.Dispositivos.FirstOrDefault().Id);

            // Modifico el nombre del dispositivo y lo grabo
            dispositivoService.CambiarNombreDispositivo(db.Dispositivos.FirstOrDefault(), "NombreModificado");

            // Recupero el dispositivo y verifico que el nombre se haya modificado correctamente
            Assert.AreEqual("NombreModificado", db.Dispositivos.FirstOrDefault());
        }
    }
}
