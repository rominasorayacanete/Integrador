using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Integrador.Models;
using Integrador.Models.Clases;
using Integrador.Models.Clases.Acciones;
using Integrador.Models.Abstract;
using Integrador.DAL;
using Integrador.Services;
using System.Collections.Generic;

namespace Tests_unitarios
{
    [TestClass]
    public class Test3
    {
        private Context db = new Context();
        DispositivoService dispositivoService = new DispositivoService();

        string condicion = "El aire acondicionado se encenderá automáticamente cuando la temperatura ambiente en el exterior supere los 25°C";
        string condicionModificada = "El aire acondicionado se encenderá automáticamente cuando la temperatura ambiente en el exterior supere los 30°C";

        [TestMethod]
        public void CasoDePrueba3()
        {
            // Creo una nueva regla.

            Regla regla = new Regla()
            {
                Condicion = condicion,
                Tipo = "Mayor",
                Valor = 30
            };

            // Persisto la regla.
            db.Reglas.Add(regla);
            db.SaveChanges();

            // Recupero la regla, modifico la condición y la persisto.
            Regla reglaRecuperada = db.Reglas.Where(r => r.Condicion == condicion).FirstOrDefault();
            reglaRecuperada.Condicion = condicionModificada;
            db.Reglas.Add(reglaRecuperada);
            db.SaveChanges();

            // Recupero la regla y evalúo que la condición se haya modificado.
            Regla reglaModificada = db.Reglas.Where(r => r.Condicion == condicionModificada).FirstOrDefault();
        }
    }
}
