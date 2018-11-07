using Integrador.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.Controllers
{
    public class ReportController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transformador()
        {
            ViewBag.Transformadores = db.Transformador.ToList();
            return View();
        }

        public ActionResult ReporteTransformador(int transformadorId, int periodo)
        {
            var transformador = db.Transformador
                   .Where(t => t.id == transformadorId)
                   .FirstOrDefault();
            
            ViewBag.Consumo = transformador.energia_suministrada * periodo;
            ViewBag.Nombre = "Transformador " + transformador.nombre;
            ViewBag.Periodo = periodo;
            return View("~/Views/Report/detail.cshtml");
        }

        public ActionResult Hogar()
        {
            ViewBag.Hogares = db.Cliente.ToList();
            return View();
        }

        public ActionResult ReporteHogar(int clienteId, int periodo)
        {
            var cliente = db.Cliente
                   .Where(c => c.id == clienteId)
                   .FirstOrDefault();
            int consumoTotal = 0;
            foreach (var dispositivo in cliente.Dispositivo)
            {
                consumoTotal += dispositivo.consumo;
            }

            ViewBag.Consumo = consumoTotal * periodo;
            ViewBag.Nombre = "Hogar de " + cliente.nombre + " " + cliente.apellido;
            ViewBag.Periodo = periodo;
            return View("~/Views/Report/detail.cshtml");
        }

        public ActionResult Dispositivo()
        {
            ViewBag.Dispositivos = db.Dispositivo.ToList();
            return View();
        }

        public ActionResult ReporteDispositivo(int dispositivoId, int periodo)
        {
            var dispositivo =  db.Dispositivo
                   .Where(d => d.id == dispositivoId)
                   .FirstOrDefault();

            ViewBag.Consumo = dispositivo.consumo * periodo;
            ViewBag.Nombre = "Dispositivo " + dispositivo.nombre_generico;
            ViewBag.Periodo = periodo;
            return View("~/Views/Report/detail.cshtml");
        }
    }
}
