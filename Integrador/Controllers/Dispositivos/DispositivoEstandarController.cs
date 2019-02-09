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
using Integrador.Services;

namespace Integrador.Controllers.Dispositivos
{
    public class DispositivoEstandarController : Controller
    {
        private Context db = new Context();
        private OperacionService operacionService = new OperacionService();
        private ClienteService clienteService = new ClienteService();

        // GET: DispositivoEstandar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            return View(dispositivoEstandar);
        }

        // GET: DispositivoEstandar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DispositivoEstandar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreGenerico,Consumo,UsoMensualMax,UsoMensualMin,UsoEstimado")] DispositivoEstandar dispositivoEstandar)
        {
            if (ModelState.IsValid)
            {
                var id = Convert.ToInt32(Session["ClientId"].ToString());
                dispositivoEstandar.ClienteID = id;
                db.DispositivoEstandar.Add(dispositivoEstandar);
                db.SaveChanges();
                return RedirectToAction("Index","DispositivoCliente", new { id });
            }

            return View(dispositivoEstandar);
        }

        // GET: DispositivoEstandar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            return View(dispositivoEstandar);
        }

        // POST: DispositivoEstandar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreGenerico,Consumo,UsoMensualMax,UsoMensualMin,UsoEstimado")] DispositivoEstandar dispositivoEstandar)
        {
            if (ModelState.IsValid)
            {
                var id = Convert.ToInt32(Session["ClientId"].ToString());
                db.Entry(dispositivoEstandar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DispositivoCliente", new { id });
            }
            return View(dispositivoEstandar);
        }

        // GET: DispositivoEstandar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/DispositivoEstandar/Delete.cshtml");
        }

        // POST: DispositivoEstandar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            db.Dispositivos.Remove(dispositivoEstandar);
            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("Apagar")]
        public ActionResult Apagar(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            dispositivoEstandar.Apagar();
            // Registro
            var operacion = operacionService.RegistrarOperacionEncender(dispositivoEstandar);
            dispositivoEstandar.Operaciones.Add(operacion);

            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("Encender")]
        public ActionResult Encender(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            dispositivoEstandar.Encender();
            // Registro
            var operacion = operacionService.RegistrarOperacionEncender(dispositivoEstandar);
            dispositivoEstandar.Operaciones.Add(operacion);

            // Agregar trackeo
            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("ActivarAhorro")]
        public ActionResult ActivarAhorro(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            dispositivoEstandar.ActivarModoAhorro();
            // Registro
            var operacion = operacionService.RegistrarOperacionAhorro(dispositivoEstandar);
            dispositivoEstandar.Operaciones.Add(operacion);

            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
        }

        [ActionName("Adaptar")]
        public ActionResult Adaptar(int? id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());

            DispositivoEstandar dispositivoEstandar = db.DispositivoEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            ModuloAdaptador adaptador = new ModuloAdaptador();
            dispositivoEstandar.Adaptar(adaptador);
            dispositivoEstandar.Cliente.SumarPuntos(10);
            // Registro
            var operacion = operacionService.RegistrarOperacionConvertir(dispositivoEstandar);
            dispositivoEstandar.Operaciones.Add(operacion);

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
