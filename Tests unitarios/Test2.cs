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

            // Recupero dispositivo
            Dispositivo dispositivo = dispositivoService.FindById(1);

            OperacionService operacionService = new OperacionService();
            operacionService.MostrarIntervalosEncendido(dispositivo);
        }
    }
}
