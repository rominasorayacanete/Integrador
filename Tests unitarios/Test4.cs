using System;
using System.Collections.Generic;
using Integrador.Models.Clases;
using Integrador.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Newtonsoft.Json;

namespace Tests_unitarios
{
    [TestClass]
    public class Test4
    {
        [TestMethod]
        public void RecuperarTransformadores_Agregar1_LacuentaDebeCoincidir()
        {
            ZonaService zonaService = new ZonaService();
            TransformadorService transformadorService = new TransformadorService();
            IQueryable<Transformador> transformadores = transformadorService.getAll();

            var cantidadTransformadores = transformadores.Count();
            Console.Write("TRANFORMADORES" + cantidadTransformadores);

            List<Transformador> nuevosTransformadores = new List<Transformador>{
                   new Transformador{Nombre = "TT1", Longitud= -11.5530886, Latitud = -11.5530886, Activo= true, EnergiaSuministrada= 100}
            };

            List<ZonaGeografica> zonas = new List<ZonaGeografica>{
                   new ZonaGeografica{NombreZona = "Test1", Longitud= -11.5530886, Latitud = -11.5530886, Radio= 20, Transformadores = nuevosTransformadores}
            };

            var json = JsonConvert.SerializeObject(zonas);
            zonaService.CargarJson(json);

            IQueryable<Transformador> transformadoresMasUno = transformadorService.getAll();
            var cantidadTransformadoresMasUno = transformadores.Count();

            Console.Write("TRANFORMADORES" + cantidadTransformadoresMasUno);
            Assert.AreEqual(cantidadTransformadoresMasUno, cantidadTransformadores + 1);

        }
    }
}
