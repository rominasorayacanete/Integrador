using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Integrador.Models;
using Integrador.Models.Clases.Tipos;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Integrador.Services
{
    public class SimplexService
    {
        private static readonly HttpClient client = new HttpClient();

        public object CreateCSV()
        {

            // Instancia de dispositivo Heladera
            TipoComputadora tipoComputadora = new TipoComputadora();
            TipoHeladera tipoHeladera = new TipoHeladera();
            TipoLavarropas tipoLavarropas = new TipoLavarropas();
            DispositivoInteligente d1 = new DispositivoInteligente(tipoComputadora);
            DispositivoInteligente d2 = new DispositivoInteligente(tipoHeladera);
            DispositivoInteligente d3 = new DispositivoInteligente(tipoLavarropas);

            // Instancia de cliente
            Cliente cliente = new Cliente();
            cliente.AgregarDispositivoInteligente(d1);
            cliente.AgregarDispositivoInteligente(d2);
            cliente.AgregarDispositivoInteligente(d3);
            int cantDispostivos = cliente.getDispositivoInteligentes().Count;
            if (cantDispostivos < 0)
            {
                // Instancia de array contendor 
                IDictionary<Object, Object> jsonArr = new Dictionary<Object, Object>();
                List<int> varsArray = new List<int>();
                // Agregamos todos los dispositivos 
                foreach (object dispositivo in cliente.getDispositivoInteligentes())
                {
                    varsArray.Add(1);
                }
                // Agregamos la cantidad de variables
                jsonArr.Add("vars", varsArray);

                List<IDictionary<Object, Object>> restriciones = new List<IDictionary<Object, Object>>();

                IDictionary<Object, Object> firstRestriction = new Dictionary<Object, Object>();
                List<double> values = new List<double>() { 440640, 0.06, 0.875, 0.18 };
                firstRestriction.Add("values", values ); // -> TODO: ver como obtener los values 
                firstRestriction.Add("operator", "<=");

                // Agregamos la primer restriccion
                restriciones.Add(firstRestriction);

                int devicePosition = cantDispostivos;

                // Creamos las demás restricciones 
                foreach (object dispositivo in cliente.getDispositivoInteligentes())
                {
                    // Inicializo un array con 0 en todas las posiciones 
                    int[] restriccionPositiva = new int[cantDispostivos];
                    for (int i = 0; i < restriccionPositiva.Length; i++) { restriccionPositiva[i] = 0; }

                    int[] restriccionNegativa = new int[cantDispostivos];
                    for (int i = 0; i < restriccionNegativa.Length; i++) { restriccionNegativa[i] = 0; }

                    // Seteo el valor de la restriccion 
                    restriccionPositiva[0] = 90; // ->  TODO: obtener el valor de la restriccion
                    restriccionPositiva[0] = 180; // ->  TODO: obtener el valor de la restriccion

                    // Seteo el valor del dispositivo
                    restriccionPositiva[devicePosition] = 1; // ->  TODO: obtener el valor de la restriccion
                    restriccionNegativa[devicePosition] = 1; // ->  TODO: obtener el valor de la restriccion

                    // Seteo de las 2 restriccions por dispositivo
                    IDictionary<Object, Object> restriccion1 = new Dictionary<Object, Object>();
                    restriccion1.Add("values", restriccionPositiva); // -> TODO: ver como obtener los values 
                    restriccion1.Add("operator", ">="); // -> TODO: ver como obtener el operador

                    IDictionary<Object, Object> restriccion2 = new Dictionary<Object, Object>();
                    restriccion2.Add("values", restriccionNegativa); // -> TODO: ver como obtener los values 
                    restriccion2.Add("operator", ">="); // -> TODO: ver como obtener el operador

                    // Agregamos las restricciones
                    restriciones.Add(restriccion1);
                    restriciones.Add(restriccion2);

                    devicePosition--;

                }
                jsonArr.Add("restrictions", restriciones);

                // Creación de una instancia de la clase WebClient
                // La clase WebClient proporciona métodos comunes para enviar y recibir datos de un recurso identificado por un URI.
                var myWebClient = new WebClient();

                // En la colección de headers debe indicarse el tipo de argumento que se enviará
                myWebClient.Headers.Add("Content-Type", "application/json");

                // Carga de datos
                var sURI = "https://dds-simplexapi.herokuapp.com/consultar";
                var json = JsonConvert.SerializeObject(jsonArr);
                // búsqueda de los datos
                return myWebClient.UploadString(sURI, json);
            }
            throw new ArgumentException("No existen dispositivos");
        }
    }
}