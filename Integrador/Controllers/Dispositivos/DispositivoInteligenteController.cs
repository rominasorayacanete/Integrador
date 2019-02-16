using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrador.DAL;
using Integrador.Models;
using Integrador.Models.Helper;
using Integrador.Services;

namespace Integrador.Controllers.Dispositivos
{
    public class DispositivoInteligenteController : Controller
    {
        private Context db = new Context();
        private OperacionService operacionService = new OperacionService();
        private DeviceService deviceService = new DeviceService();
        private ActuadorService actuadorService = new ActuadorService();

        // GET: DispositivoInteligente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);

            if (dispositivoInteligente == null)
            {
                return HttpNotFound();
            }
            return View(dispositivoInteligente);
        }

        // GET: DispositivoInteligente/Create
        public ActionResult Create()
        {
            ViewBag.Dispositivos = db.TemplateDispositivos.Where(t => t.Inteligente == true)
            .Select(t => new SelectListItem
            {
                Text = t.Tipo + " " + t.EquipoConcreto,
                Value = t.Id.ToString()
            });

            ViewBag.Marcas = deviceService.GetMarcas();

            return View();
        }

        // POST: DispositivoInteligente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DispositivoConcreto dispositivoConcreto)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            deviceService.CrearNuevoDispositivoInteligente(clientId, dispositivoConcreto);
            db.Clientes.Find(clientId).SumarPuntos(15);
            db.SaveChanges();
            return RedirectToAction("Index","DispositivoCliente", new { id = clientId });
        }

        // GET: DispositivoInteligente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);

            if (dispositivoInteligente == null)
            {
                return HttpNotFound();
            }

            return View(dispositivoInteligente);
        }

        // POST: DispositivoInteligente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreGenerico,Consumo,UsoMensualMax,UsoMensualMin,Encendido,ModoAhorroDeEnergia")] DispositivoInteligente dispositivoInteligente)
        {
            if (ModelState.IsValid)
            {
                var clientId = Convert.ToInt32(Session["ClientId"].ToString());

                db.Entry(dispositivoInteligente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
            }
            return View(dispositivoInteligente);
        }

        // GET: DispositivoInteligente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);
            if (dispositivoInteligente == null)
            {
                return HttpNotFound();
            }
            return View(dispositivoInteligente);
        }

        // POST: DispositivoInteligente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);
            dispositivoInteligente.Archivado = true;
            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("Apagar")]
        public ActionResult Apagar(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);
            if (dispositivoInteligente == null)
            {
                return HttpNotFound();
            }
            dispositivoInteligente.Apagar();
            // Registro
            var operacion = operacionService.RegistrarOperacionApagar(dispositivoInteligente);
            dispositivoInteligente.Operaciones.Add(operacion);

            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("Encender")]
        public ActionResult Encender(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);
            if (dispositivoInteligente == null)
            {
                return HttpNotFound();
            }
            dispositivoInteligente.Encender();
            // Registro
            var operacion = operacionService.RegistrarOperacionEncender(dispositivoInteligente);
            dispositivoInteligente.Operaciones.Add(operacion);

            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("ActivarAhorro")]
        public ActionResult ActivarAhorro(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);
            if (dispositivoInteligente == null)
            {
                return HttpNotFound();
            }
            dispositivoInteligente.ActivarModoAhorro();
            // Registro
            var operacion = operacionService.RegistrarOperacionAhorro(dispositivoInteligente);
            dispositivoInteligente.Operaciones.Add(operacion);

            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("AsociarActuador")]
        public ActionResult AsociarActuador(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            ViewBag.Reglas = db.Reglas.Where(r => r.ClientID == clientId)
            .Select(r => new SelectListItem
            {
                Text = r.Condicion + " " + r.Tipo + " " + r.Valor,
                Value = r.Id.ToString()
            });

            ViewBag.Acciones = new List<SelectListItem>
            {
                new SelectListItem{Text = "Apagar", Value = "apagar"},
                new SelectListItem{Text = "Bajar Temperatura", Value = "bajar-temperatura"},
                new SelectListItem{Text = "Bajar Intensidad", Value = "bajar-intensidad"}
            };

            ActuadorDispositivo actuadorDispositivo = new ActuadorDispositivo();
            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);

            actuadorDispositivo.Dispositivo = dispositivoInteligente;
            Session["DeviceId"] = dispositivoInteligente.Id;

            return View(actuadorDispositivo);
        }

        [HttpPost, ActionName("AsociarActuador")]
        public ActionResult AsociarActuador(ActuadorDispositivo actuadorDispositivo)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            var dispositivoID = Convert.ToInt32(Session["DeviceId"].ToString());
            Actuador actuador = actuadorService.CrearActuador(dispositivoID, actuadorDispositivo.Accion,actuadorDispositivo.Reglas);
            db.Actuadores.Add(actuador);
            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
