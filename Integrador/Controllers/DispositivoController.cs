using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.ORM;
using System.IO;
using Newtonsoft.Json;

namespace Integrador.Controllers
{
    public class DispositivoController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cargar(HttpPostedFileBase jsonFile)
        {
            if(!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {
                ViewBag.Error = "Tipo de archivo inváido.";
            }
            else
            {
                jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                string data = streamReader.ReadToEnd();
                List<Dispositivo> dispositivos = JsonConvert.DeserializeObject<List<Dispositivo>>(data);
                dispositivos.ForEach(d => { Dispositivo dispositivo = new Dispositivo() {
                        id = d.id,
                        nombre_generico = d.nombre_generico,
                        consumo_hora = d.consumo_hora,
                        encendido = d.encendido,
                        inteligente = d.inteligente
                    };
                    db.Dispositivo.Add(dispositivo);
                    db.SaveChanges();
                });
                ViewBag.Success = "Success";
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}