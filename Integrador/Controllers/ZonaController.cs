using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.ORM;
using System.IO;
using Newtonsoft.Json;
using Integrador.Services;

namespace Integrador.Controllers
{
    public class ZonaController : Controller
    {

        private DBContext db = new DBContext();
        private ZonaService zonaService = new ZonaService();

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
                try
                {
                    zonaService.CargarJson(data);
                    ViewBag.Success = "Success";

                }
                catch
                {
                    ViewBag.Success = "Fail";
                }
            }
            return View("~/Views/Transformador/Map.cshtml");
        }
    }
}