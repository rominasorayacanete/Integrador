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
                List<ZonaGeografica> zonas = JsonConvert.DeserializeObject<List<ZonaGeografica>>(data);
                zonas.ForEach(z => {
                   ZonaGeografica zona = new ZonaGeografica()
                    {
                        id = z.id,
                        radio = z.radio,
                        nombre_zona = z.nombre_zona
                    };
                    db.ZonaGeografica.Add(zona);
                    db.SaveChanges();
                });
                ViewBag.Success = "Success";
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}