using Integrador.DAL;
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
        private Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transformador()
        {
            ViewBag.Transformadores = context.Transformadores.ToList();
            return View();
        }

        public ActionResult ReporteTransformador(int transformadorId, int periodo)
        {
            var transformador = context.Transformadores
                   .Where(t => t.Id == transformadorId)
                   .FirstOrDefault();
            
            ViewBag.Consumo = transformador.EnergiaSuministrada * periodo;
            ViewBag.Nombre = "Transformador " + transformador.Nombre;
            ViewBag.Periodo = periodo;
            return View("~/Views/Report/detail.cshtml");
        }

        public ActionResult Hogar()
        {
            ViewBag.Hogares = context.Clientes.ToList();
            return View();
        }

        public ActionResult ReporteHogar(int clienteId, int periodo)
        {
            var cliente = context.Clientes
                   .Where(c => c.Id == clienteId)
                   .FirstOrDefault();

            int consumoTotal = 0;

            foreach (var dispositivo in cliente.Dispositivos)
            {
                consumoTotal += dispositivo.Consumo;
            }

            ViewBag.Consumo = consumoTotal * periodo;
            ViewBag.Nombre = "Hogar de " + cliente.Nombre + " " + cliente.Apellido;
            ViewBag.Periodo = periodo;
            return View("~/Views/Report/detail.cshtml");
        }

        public ActionResult Dispositivo()
        {
            ViewBag.Dispositivos = context.Dispositivos.ToList();
            return View();
        }

        public ActionResult ReporteDispositivo(int dispositivoId, int periodo)
        {
            var dispositivo =  context.Dispositivos
                   .Where(d => d.Id == dispositivoId)
                   .FirstOrDefault();

            ViewBag.Consumo = dispositivo.Consumo * periodo;
            ViewBag.Nombre = "Dispositivo " + dispositivo.NombreGenerico;
            ViewBag.Periodo = periodo;
            return View("~/Views/Report/detail.cshtml");
        }
    }
}
