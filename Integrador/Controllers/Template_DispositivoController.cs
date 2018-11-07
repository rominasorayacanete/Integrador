using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrador.ORM;

namespace Integrador.Controllers
{
    public class Template_DispositivoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Template_Dispositivo
        public ActionResult Index()
        {
            return View(db.Template_Dispositivo.ToList());
        }

        // GET: Template_Dispositivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template_Dispositivo template_Dispositivo = db.Template_Dispositivo.Find(id);
            if (template_Dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(template_Dispositivo);
        }

        // GET: Template_Dispositivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Template_Dispositivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,inteligente,bajo_consumo,consumo")] Template_Dispositivo template_Dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Template_Dispositivo.Add(template_Dispositivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(template_Dispositivo);
        }

        // GET: Template_Dispositivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template_Dispositivo template_Dispositivo = db.Template_Dispositivo.Find(id);
            if (template_Dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(template_Dispositivo);
        }

        // POST: Template_Dispositivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,inteligente,bajo_consumo,consumo")] Template_Dispositivo template_Dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(template_Dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(template_Dispositivo);
        }

        // GET: Template_Dispositivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template_Dispositivo template_Dispositivo = db.Template_Dispositivo.Find(id);
            if (template_Dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(template_Dispositivo);
        }

        // POST: Template_Dispositivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Template_Dispositivo template_Dispositivo = db.Template_Dispositivo.Find(id);
            db.Template_Dispositivo.Remove(template_Dispositivo);
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
