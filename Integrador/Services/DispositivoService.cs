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
using Integrador.Services.Extension;
using Integrador.DAL;
using Integrador.Models.Clases;

namespace Integrador.Services
{
    public class DispositivoService
    {
        private Context db = new Context();

        public Dispositivo findDispositivoByName(string nombre)
        {
            return db.Dispositivos
                .Where(d => d.NombreGenerico == nombre)
                .FirstOrDefault();
        }

        public void createNewDispositivo(Dispositivo dispositivo)
        {
            db.Dispositivos.Add(dispositivo);
            db.SaveChanges();
        }

        public void cambiarNombre(Dispositivo dispositivo, string nombre)
        {
            var disp = db.Dispositivos.SingleOrDefault(d => d.Id == dispositivo.Id);
            if (disp != null)
            {
                disp.NombreGenerico = nombre;
                db.SaveChanges();
            }
        }

    }
}