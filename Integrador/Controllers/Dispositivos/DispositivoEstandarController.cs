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

namespace Integrador.Controllers.Dispositivos
{
    public class DispositivoEstandarController : Controller
    {
        private Context db = new Context();

        // GET: DispositivoEstandar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispositivoEstandar dispositivoEstandar = db.DispositivosEstandar.Find(id);
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
                db.DispositivosEstandar.Add(dispositivoEstandar);
                db.SaveChanges();
                return RedirectToAction("Index","DispositivoCliente");
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
            DispositivoEstandar dispositivoEstandar = db.DispositivosEstandar.Find(id);
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
                db.Entry(dispositivoEstandar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DispositivoCliente");
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
            DispositivoEstandar dispositivoEstandar = db.DispositivosEstandar.Find(id);
            if (dispositivoEstandar == null)
            {
                return HttpNotFound();
            }
            return View(dispositivoEstandar);
        }

        // POST: DispositivoEstandar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DispositivoEstandar dispositivoEstandar = db.DispositivosEstandar.Find(id);
            db.Dispositivos.Remove(dispositivoEstandar);
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
