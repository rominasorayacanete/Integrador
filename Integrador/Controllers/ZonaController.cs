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
    public class ZonaController : Controller
    {

        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cargar(HttpPostedFileBase jsonFile)
        {
            if (!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {
                ViewBag.Error = "Tipo de archivo inváido.";
            }
            else
            {
                jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                string data = streamReader.ReadToEnd();
                List<Zona_Geografica> zonas = JsonConvert.DeserializeObject<List<Zona_Geografica>>(data);
                zonas.ForEach(z => {
                    Zona_Geografica zona = new Zona_Geografica()
                    {
                        id = z.id,
                        radio = z.radio,
                        nombre_zona = z.nombre_zona,
                        latitud = z.latitud,
                        longitud = z.longitud
                    };

                    db.Zona_Geografica.Add(zona);
                    db.SaveChanges();

                    foreach (Transformador t in z.Transformador)
                    {
                        t.zona_id = zona.id;
                        db.Transformador.Add(t);
                        db.SaveChanges();
                    }

                    
                });
                ViewBag.Success = "Success";
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}