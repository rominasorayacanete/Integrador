using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrador.ORM;

namespace Integrador.Controllers
{
    public class TransformadorsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Transformadors
        public ActionResult Index()
        {
            var transformador = db.Transformador.Include(t => t.Zona_Geografica);
            return View(transformador.ToList());
        }

        public ActionResult Map()
        {
            // Codigo para obtener los transformadores
            //return View(transformador.ToList());

            return View();
        }

        // GET: Transformadors/Details/5
        [HttpGet]
        public ActionResult Details(int id, int periodo)
        {
            if (id == null || periodo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Consumo = 10000;
            return View();
        }
    }
}
