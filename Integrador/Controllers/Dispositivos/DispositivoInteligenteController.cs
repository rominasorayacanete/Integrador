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
    public class DispositivoInteligenteController : Controller
    {
        private Context db = new Context();
        private OperacionService operacionService = new OperacionService();

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
            return View();
        }

        // POST: DispositivoInteligente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreGenerico,Consumo,UsoMensualMax,UsoMensualMin,Encendido,ModoAhorroDeEnergia")] DispositivoInteligente dispositivoInteligente)
        {
            if (ModelState.IsValid)
            {
                db.DispositivosInteligentes.Add(dispositivoInteligente);
                db.SaveChanges();
                return RedirectToAction("Index", "DispositivoCliente");
            }

            return View(dispositivoInteligente);
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
                db.Entry(dispositivoInteligente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DispositivoCliente");
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
            DispositivoInteligente dispositivoInteligente = db.DispositivosInteligentes.Find(id);
            db.Dispositivos.Remove(dispositivoInteligente);
            db.SaveChanges();
            return RedirectToAction("Index", "DispositivoCliente");
        }

        [ActionName("Apagar")]
        public ActionResult Apagar(int? id)
        {
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
            return RedirectToAction("Index", "DispositivoCliente");
        }

        [ActionName("Encender")]
        public ActionResult Encender(int? id)
        {
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
            return RedirectToAction("Index", "DispositivoCliente");
        }

        [ActionName("ActivarAhorro")]
        public ActionResult ActivarAhorro(int? id)
        {
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
            return RedirectToAction("Index", "DispositivoCliente");
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
