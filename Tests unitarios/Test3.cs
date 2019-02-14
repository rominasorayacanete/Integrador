using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Integrador.Models;
using Integrador.DAL;
using Integrador.Services;

namespace Tests_unitarios
{
    [TestClass]
    public class Test3
    {
        private Context db = new Context();
        DispositivoService dispositivoService = new DispositivoService();

        [TestMethod]
        public void CasoDePrueba3()
        {
            // Creo una nueva regla
            Regla regla = new Regla()
            {
                Condicion = "El aire acondicionado se encenderá automáticamente cuando la temperatura ambiente en el exterior supere los 25°C",
                Tipo = "Mayor",
                Valor = 30
            };

            // Asocio la regla a un dispositivo
            Dispositivo dispositivo = dispositivoService.FindById(1);
            
        }
    }
}
