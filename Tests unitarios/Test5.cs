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
        private DispositivoService dispositivoInteligenteService = new DispositivoService();
        //private TransformadorService transformadorService = new TransformadorService();

       

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
                Console.WriteLine("Consumo Total Cliente: ", clienteService.ConsumoTotal(cliente, desde, hasta).consumoTotal);

                //5b Dado un dispositivo y un periodo
                
                DispositivoInteligente dispositivo = new DispositivoInteligente()
                {
                    NombreGenerico="Smart 200",
                    Consumo=0.15,
                    UsoMensualMax=360,
                    UsoMensualMin=30
                }

                Console.WriteLine("Consumo Total Dispositivo: ",dispositivoInteligenteService.ConsumoDispositivo(desde, hasta, dispositivo));

            //5c Dado un transformador y un periodo calcular su consumoTotal
            //ver periodo

                Transformador transformador = new Transformador()
                {
                    Nombre = "T1",
                    Activo = 1,
                    EnergiaSuministrada = 402685,
                    Latitud = -34.5550886,
                    Longitud= -58.4879849,
                    ZonaGeografica=1,
                    Cliente=cliente
                }
                Console.WriteLine("Consumo Total Transformador: ",transformador.GetConsumoTotal() );
            



}

}
}
