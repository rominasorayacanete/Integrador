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
using Integrador.Models.Clases;

namespace Integrador.Controllers.Reglas
{
    public class ReglasController : Controller
    {
        private Context db = new Context();

        // GET: Reglas
        public ActionResult Index(int? id)
        {
            return View(db.Reglas.Where(r => r.ClientID == id).ToList());
        }

        // GET: Reglas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regla regla = db.Reglas.Find(id);
            if (regla == null)
            {
                return HttpNotFound();
            }
            return View(regla);
        }

        // GET: Reglas/Create
        public ActionResult Create()
        {
            ViewBag.Sensores = db.Sensores
            .Select(s => new SelectListItem
            {
                Text = s.Descripcion + " " + s.Magnitud,
                Value = s.Id.ToString()
            });

            ViewBag.Tipos = new List<SelectListItem>
            {
                new SelectListItem{Text = "Mayor (>)", Value = "mayor"},
                new SelectListItem{Text = "Menor (<)", Value = "menor"}
            };

            return View();
        }

        // POST: Reglas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReglaCumplida,Condicion,Tipo,Valor,SensorID")] Regla regla)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            regla.ClientID = clientId;
            db.Reglas.Add(regla);
            db.SaveChanges();
            return RedirectToAction("Index", "Reglas", new { id = clientId });

        }

        // GET: Reglas/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Sensores = db.Sensores
            .Select(s => new SelectListItem
            {
                Text = s.Descripcion + " " + s.Magnitud,
                Value = s.Id.ToString()
            });

            ViewBag.Tipos = new List<SelectListItem>
            {
                new SelectListItem{Text = "Mayor (>)", Value = "mayor"},
                new SelectListItem{Text = "Menor (<)", Value = "menor"}
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regla regla = db.Reglas.Find(id);
            if (regla == null)
            {
                return HttpNotFound();
            }
            return View(regla);
        }

        // POST: Reglas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReglaCumplida,Condicion,Tipo,Valor,SensorID")] Regla regla)
        {
            if (ModelState.IsValid)
            {
                var clientId = Convert.ToInt32(Session["ClientId"].ToString());
                regla.ClientID = clientId;
                db.Entry(regla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Reglas", new { id = clientId });
            }
            return View(regla);
        }

        // GET: Reglas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regla regla = db.Reglas.Find(id);
            if (regla == null)
            {
                return HttpNotFound();
            }
            return View(regla);
        }

        // POST: Reglas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clientId = Convert.ToInt32(Session["ClientId"].ToString());
            Regla regla = db.Reglas.Find(id);
            db.Reglas.Remove(regla);
            db.SaveChanges();
            return RedirectToAction("Index", "Reglas", new { id = clientId });
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
