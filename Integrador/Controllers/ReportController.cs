using Integrador.DAL;
using Integrador.ORM;
using Integrador.Services;
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
        private ReportService reportService = new ReportService();
        private TransformadorService transformadorService  = new TransformadorService();
        private ClienteService clienteService = new ClienteService();
        private DispositivoService dispositivoService = new DispositivoService();

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
            var transformador = transformadorService.FindById(transformadorId);

            string SearchName = "Transformador" + transformador.Id + periodo;
            var mongoReport = reportService.ExistReport(SearchName, periodo);

            if (mongoReport != null)
            {
                ViewBag.Consumo = mongoReport.Value;
                ViewBag.Nombre = "Transformador Mongo " + mongoReport.DisplayName;
                ViewBag.Periodo = mongoReport.Periodo;
                ViewBag.Mongo = "Este reporte ha sido generado a travez de MongoDB!";
                return View("~/Views/Report/detail.cshtml");
            }

            ViewBag.Consumo = transformador.EnergiaSuministrada * periodo;
            ViewBag.Nombre = "Transformador " + transformador.Nombre;
            ViewBag.Periodo = periodo;
            reportService.GenerateReport(ViewBag.Nombre, periodo, ViewBag.Consumo);

            reportService.SaveReport(SearchName, transformador.Nombre, periodo, transformador.EnergiaSuministrada * periodo);

            return View("~/Views/Report/detail.cshtml");
        }

        public ActionResult Hogar()
        {
            ViewBag.Hogares = context.Clientes.ToList();
            return View();
        }

        public ActionResult ReporteHogar(int clienteId, int periodo)
        {

            var cliente = clienteService.FindById(clienteId);

            string SearchName = "Hogar" + cliente.Id + periodo;
            var mongoReport = reportService.ExistReport(SearchName, periodo);

            if (mongoReport != null)
            {
                ViewBag.Consumo = mongoReport.Value;
                ViewBag.Nombre = "Hogar " + mongoReport.DisplayName;
                ViewBag.Periodo = mongoReport.Periodo;
                ViewBag.Mongo = "Este reporte ha sido generado a travez de MongoDB!";
                return View("~/Views/Report/detail.cshtml");
            }

            ViewBag.Consumo = cliente.ConsumoHogar() * periodo;
            ViewBag.Nombre = "Hogar de " + cliente.Nombre + " " + cliente.Apellido;
            ViewBag.Periodo = periodo;
            reportService.GenerateReport( ViewBag.Nombre, periodo, ViewBag.Consumo);

            reportService.SaveReport(SearchName, cliente.Nombre, periodo, cliente.ConsumoHogar() * periodo);

            return View("~/Views/Report/detail.cshtml");
        }

        public ActionResult Dispositivo()
        {
            ViewBag.Dispositivos = context.Dispositivos.ToList();
            return View();
        }

        public ActionResult ReporteDispositivo(int dispositivoId, int periodo)
        {
            var dispositivo = dispositivoService.FindById(dispositivoId);

            string SearchName = "Dispositivo" + dispositivo.Id + periodo;
            var mongoReport = reportService.ExistReport(SearchName, periodo);

            if (mongoReport != null)
            {
                ViewBag.Consumo = mongoReport.Value;
                ViewBag.Nombre = "Dispositivo " + mongoReport.DisplayName;
                ViewBag.Periodo = mongoReport.Periodo;
                ViewBag.Mongo = "Este reporte ha sido generado a través de MongoDB.";
                return View("~/Views/Report/detail.cshtml");
            }

            ViewBag.Consumo = dispositivo.Consumo * periodo;
            ViewBag.Nombre = "Dispositivo " + dispositivo.NombreGenerico;
            ViewBag.Periodo = periodo;
            reportService.GenerateReport(ViewBag.Nombre, periodo, ViewBag.Consumo);

            reportService.SaveReport(SearchName, dispositivo.NombreGenerico , periodo, dispositivo.Consumo * periodo);

            return View("~/Views/Report/detail.cshtml");
        }
    }
}
