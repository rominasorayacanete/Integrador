using System;
using Integrador.DAL;
using Integrador.Models;
using Integrador.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_unitarios
{
    [TestClass]
    public class Test5
    {
        private Context db = new Context();
        private ClienteService clienteService = new ClienteService();
        private DispositivoService dispositivoService = new DispositivoService();

       

        [TestMethod]
        public void CasoDePrueba5()
        {
                
                //5a Dado un hogar y un periodo mostrar por consola el consumo total.
                private DateTime desde = DateTime.Today.AddDays(-360);
                private DateTime hasta = DateTime.Now;

                //Creo cliente
                Cliente cliente = new Cliente()
                {
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    TipoDoc = "DNI",
                    NroDoc = 12345678,
                    Latitud = -10.1000, //Coord Domic.
                    Longitud = -30.1000,
                    Domicilio = "Rivadavia 2888"
                };
                Console.WriteLine("Consumo Total: ", clienteService.ConsumoTotal(cliente, desde, hasta).consumoTotal);

                //5b Dado un dispositivo y un periodo


        }

}
}
