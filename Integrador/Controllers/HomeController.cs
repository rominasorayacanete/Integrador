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
using Integrador.DAL;
using MongoDemo.App_Start;
using MongoDB.Bson;

namespace Integrador.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        private MongoContext mongo = new MongoContext();
        private SimplexService simplexService = new SimplexService();
        private ClienteService clienteService = new ClienteService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var collection = mongo.database.GetCollection<BsonDocument>("foo");

            var document = new BsonDocument
            {
                { "name", "MongoDB" },
            };
            collection.InsertOne(document);

            db.SaveChanges();
            return View();
        }

        [ActionName("Simplex")]
        public ActionResult Simplex()
        {
                var clientId = Convert.ToInt32(Session["ClientId"].ToString());
                Cliente cliente = clienteService.FindById(clientId);
                var objeto = simplexService.executeSimplex(cliente);
                ViewBag.Objeto = objeto;
          
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

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
            string str = (new StreamReader(archivo.InputStream)).ReadToEnd();
            var zonas = JsonConvert.DeserializeObject<List<ZonaGeografica>>(str);
            foreach(var zona in zonas)
            {
                db.ZonaGeograficas.Add(zona);
            }
            db.SaveChanges();
            ViewBag.Zonas = zonas;
            return View("~/Views/Transformador/Map.cshtml");
        }

    }
}