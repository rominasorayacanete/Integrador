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
    public class TemplateDispositivosController : Controller
    {
        private Context db = new Context();

        // GET: TemplateDispositivos
        public ActionResult Index()
        {
            return View(db.TemplateDispositivos.ToList());
        }

        // GET: TemplateDispositivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateDispositivo templateDispositivo = db.TemplateDispositivos.Find(id);
            if (templateDispositivo == null)
            {
                return HttpNotFound();
            }
            return View(templateDispositivo);
        }

        // GET: TemplateDispositivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TemplateDispositivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,EquipoConcreto,Inteligente,BajoConsumo,Consumo")] TemplateDispositivo templateDispositivo)
        {
            if (ModelState.IsValid)
            {
                db.TemplateDispositivos.Add(templateDispositivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(templateDispositivo);
        }

        // GET: TemplateDispositivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateDispositivo templateDispositivo = db.TemplateDispositivos.Find(id);
            if (templateDispositivo == null)
            {
                return HttpNotFound();
            }
            return View(templateDispositivo);
        }

        // POST: TemplateDispositivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,EquipoConcreto,Inteligente,BajoConsumo,Consumo")] TemplateDispositivo templateDispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(templateDispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(templateDispositivo);
        }

        // GET: TemplateDispositivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateDispositivo templateDispositivo = db.TemplateDispositivos.Find(id);
            if (templateDispositivo == null)
            {
                return HttpNotFound();
            }
            return View(templateDispositivo);
        }

        // POST: TemplateDispositivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemplateDispositivo templateDispositivo = db.TemplateDispositivos.Find(id);
            db.TemplateDispositivos.Remove(templateDispositivo);
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
