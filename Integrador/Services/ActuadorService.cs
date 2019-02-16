using System.Collections.Generic;
using Newtonsoft.Json;
using Integrador.DAL;
using Integrador.Models.Clases;
using Integrador.Models;
using Integrador.Models.Clases.Acciones;
using System;
using Integrador.Models.Abstract;

namespace Integrador.Services
{
    public class ActuadorService
    {
        private Context db = new Context();

        public Actuador CrearActuador(int dispositivo, string accion, List<Regla> reglas)
        {
            IAccion tipoAccion;
            string descripcion;

            if (accion == "apagar")
            {
                 tipoAccion = new AccionApagar();
                 descripcion = "Apagar dispositivo";
            }
            else if (accion == "bajar-temperatura")
            {
                tipoAccion = new AccionBajarTemperatura();
                descripcion = "Bajar temperatura";
            }
            else if (accion == "bajar-intensidad")
            {
                tipoAccion = new AccionBajarIntesidad();
                descripcion = "Bajar intensidad";
            }
            else
            {
                throw new Exception("error");
            }

            return new Actuador(tipoAccion) { AccionSlug = descripcion, DispositivoID = dispositivo, ReglasRequeridas = reglas };
        }

    }
}