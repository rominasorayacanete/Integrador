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
        private static DeviceService deviceService = new DeviceService();

        public object CreateCSV()  // -> CreateCSV(Cliente cliente)
        {
            // Instancia de cliente ->  Mock Temporals

            List<DispositivoInteligente> listado = this.MockCliente(); //-> Reemplazar por cliente.DispositivosInteligentes;

            int cantDispostivos = listado.Count;
            if (cantDispostivos > 0)
            {
                // Instancia de array contendor 
                IDictionary<Object, Object> jsonArr = new Dictionary<Object, Object>();
                List<int> varsArray = new List<int>();
                
                // Agregamos todos los dispositivos 
                foreach (object dispositivo in listado)
                {
                    varsArray.Add(1);
                }
                // Agregamos la cantidad de variables
                jsonArr.Add("vars", varsArray);

                List<IDictionary<Object, Object>> restriciones = new List<IDictionary<Object, Object>>();

                IDictionary<Object, Object> firstRestriction = new Dictionary<Object, Object>();
                List<double> values = new List<double>() { 440640 }; // -> 440640 se deja de primera

                listado.Reverse();

                foreach (DispositivoInteligente dispositivo in listado)
                {
                    values.Add(deviceService.findConsumo(dispositivo.TipoDispositivo.EquipoConcreto));
                }

                listado.Reverse();

                firstRestriction.Add("values", values );
                firstRestriction.Add("operator", "<=");

                // Agregamos la primer restriccion
                restriciones.Add(firstRestriction);

                int devicePosition = cantDispostivos;

                // Creamos las demás restricciones 
                foreach (DispositivoInteligente dispositivo in listado)
                {
                    // Inicializo un array con 0 en todas las posiciones 
                    int[] restriccionPositiva = new int[cantDispostivos + 1];
                    for (int i = 0; i < restriccionPositiva.Length; i++) { restriccionPositiva[i] = 0; }

                    int[] restriccionNegativa = new int[cantDispostivos + 1];
                    for (int i = 0; i < restriccionNegativa.Length; i++) { restriccionNegativa[i] = 0; }

                    // Seteo el valor de la restriccion 
                    restriccionPositiva[0] = dispositivo.TipoDispositivo.UsoMensualMin;
                    restriccionNegativa[0] = dispositivo.TipoDispositivo.UsoMensualMax; 

                    // Seteo '1' segun la ubicacion del dispositivo
                    restriccionPositiva[devicePosition] = 1; 
                    restriccionNegativa[devicePosition] = 1;

                    // Seteo de las 2 restriccions por dispositivo
                    IDictionary<Object, Object> restriccion1 = new Dictionary<Object, Object>();
                    restriccion1.Add("values", restriccionPositiva);
                    restriccion1.Add("operator", ">=");

                    IDictionary<Object, Object> restriccion2 = new Dictionary<Object, Object>();
                    restriccion2.Add("values", restriccionNegativa); 
                    restriccion2.Add("operator", "<=");

                    // Agregamos las restricciones
                    restriciones.Add(restriccion1);
                    restriciones.Add(restriccion2);

                    devicePosition--;

                }
                jsonArr.Add("restrictions", restriciones);

                // HTTP POST
                List<float> httpResult = this.SendJson(jsonArr);
                
                // Formateo la informacion
                IDictionary<Object, Object> resultado = new Dictionary<Object, Object>();
                int l = 0;
                foreach (DispositivoInteligente dispositivo in listado)
                {
                    resultado.Add(dispositivo.TipoDispositivo.EquipoConcreto, httpResult[l]);
                    l++;
                }

                return JsonConvert.SerializeObject(resultado);

            }
            throw new ArgumentException("No existen dispositivos");
        }

        private List<float> SendJson(IDictionary<Object, Object> jsonArr)
        {
            var myWebClient = new WebClient();

            myWebClient.Headers.Add("Content-Type", "application/json");
            var sURI = "https://dds-simplexapi.herokuapp.com/consultar";
            var json = JsonConvert.SerializeObject(jsonArr);
            return JsonConvert.DeserializeObject<List<float>>(myWebClient.UploadString(sURI, json));

        }

        private List<DispositivoInteligente> MockCliente()
        {
            // Instancia de dispositivo Heladera
            TipoComputadora tipoComputadora = new TipoComputadora();
            TipoHeladera tipoHeladera = new TipoHeladera();
            TipoLavarropas tipoLavarropas = new TipoLavarropas();
            DispositivoInteligente d1 = new DispositivoInteligente(tipoComputadora);
            DispositivoInteligente d2 = new DispositivoInteligente(tipoHeladera);
            DispositivoInteligente d3 = new DispositivoInteligente(tipoLavarropas);

            // Instancia de cliente
            List<DispositivoInteligente> listado = new List<DispositivoInteligente>();
            listado.Add(d1);
            listado.Add(d2);
            listado.Add(d3);

            return listado;
        }

    }
}