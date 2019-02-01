using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.Controllers
{
    public class MedicionesController : Controller
    {
        // GET: Mediciones
        public ActionResult Index()
        {
            return View("~/Views/Estado_Hogar/Index.cshtml");
        }
    }
}