using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.Models;
using Integrador.Models.Clases;
using Integrador.Services;
using Integrador.ORM;

namespace Integrador.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            /*
            Integrador.ORM.Regla regla = new ORM.Regla();
            regla.idRegla = 123;

            using(var db = new IntegradorDB())
            {
                db.Regla.Add(regla);
                db.SaveChanges();
            }
            */

            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Simplex()
        {
            try
            {

                SimplexService service = new SimplexService();
                Models.Cliente cliente = service.MockCliente();
                var objeto = service.executeSimplex(cliente);
                ViewBag.Objeto = objeto;

            } catch
            {
                ViewBag.Objeto = "No se pudo ejecutar el metodo simplex";
            }
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [Authorize]
        public ActionResult LoadData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowCategories(HttpPostedFileBase archivo)
        {
            try
            {
                string str = (new StreamReader(archivo.InputStream)).ReadToEnd();
                var categorias = JsonConvert.DeserializeObject<List<Integrador.Models.Categoria>>(str);
                ViewBag.List = categorias;
                return View("~/Views/Home/List.cshtml");
            }
            catch
            {
                return View("~/Views/Home/Index.cshtml");
            }

        }

        public ActionResult ListDevice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowDevice(HttpPostedFileBase archivo)
        {
            try
            {
                string str = (new StreamReader(archivo.InputStream)).ReadToEnd();
                var dispositivos = JsonConvert.DeserializeObject<List<Integrador.Models.Dispositivo>>(str);
                ViewBag.List = dispositivos;
                return View("~/Views/Home/ListDevice.cshtml");
            }
            catch
            {
                return View("~/Views/Home/Index.cshtml");
            }

        }

        [HttpPost]
        public ActionResult MostrarZonas(HttpPostedFileBase archivo)
        {
            try
            {
                string str = (new StreamReader(archivo.InputStream)).ReadToEnd();
                var zonas = JsonConvert.DeserializeObject<List<ORM.ZonaGeografica>>(str);
                using(var db = new DBContext())
                {
                    foreach(var zona in zonas)
                    {
                        db.ZonaGeografica.Add(zona);

                    }
                    db.SaveChanges();
                }



                ViewBag.Zonas = zonas;
                return View("~/Views/Home/Zonas.cshtml");
            }
            catch
            {
                return View("~/Views/Home/Index.cshtml");
            }

        }

    }
}