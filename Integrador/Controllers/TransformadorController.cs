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

namespace Integrador.Controllers
{
    public class TransformadorController : Controller
    {
        private Context db = new Context();

        // GET: Transformador
        public ActionResult Index()
        {
            return View(db.Transformadores.ToList());
        }

        public ActionResult Map()
        {
            ViewBag.transformadores = db.Transformadores.ToList();
            return View(db.Transformadores.ToList());
        }


        // GET: Transformador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transformador transformador = db.Transformadores.Find(id);
            if (transformador == null)
            {
                return HttpNotFound();
            }
            return View(transformador);
        }

        // GET: Transformador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transformador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Activo,EnergiaSuministrada,Latitud,Longitud")] Transformador transformador)
        {
            if (ModelState.IsValid)
            {
                db.Transformadores.Add(transformador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transformador);
        }

        // GET: Transformador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transformador transformador = db.Transformadores.Find(id);
            if (transformador == null)
            {
                return HttpNotFound();
            }
            return View(transformador);
        }

        // POST: Transformador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Activo,EnergiaSuministrada,Latitud,Longitud")] Transformador transformador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transformador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transformador);
        }

        // GET: Transformador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transformador transformador = db.Transformadores.Find(id);
            if (transformador == null)
            {
                return HttpNotFound();
            }
            return View(transformador);
        }

        // POST: Transformador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transformador transformador = db.Transformadores.Find(id);
            db.Transformadores.Remove(transformador);
            db.SaveChanges();
            return RedirectToAction("Index");
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
