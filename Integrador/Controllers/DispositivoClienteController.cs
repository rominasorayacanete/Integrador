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
    public class DispositivoClienteController : Controller
    {
        private DBContext db = new DBContext();

        // GET: DispositivoCliente
        public ActionResult Index()
        {
            var userId = Convert.ToInt16(Session["UserId"]); ;
            var cliente = db.Cliente
                .Where(c => c.Usuario.id == userId)
                .FirstOrDefault();
            var dispositivo = db.Dispositivo.Where(d => d.Cliente.id == cliente.id);
            return View(dispositivo.ToList());
        }

        // GET: DispositivoCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // GET: DispositivoCliente/Create
        public ActionResult Create()
        {
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre");
            return View();
        }

        // POST: DispositivoCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre_generico,consumo_hora,encendido,modo_ahorro_energia,consumo,uso_mensual_max,uso_mensual_min,inteligente,tipo_dispositivo,uso_estimado")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                var userId = Convert.ToInt16(Session["UserId"]); ;
                var cliente = db.Cliente
                    .Where(c => c.Usuario.id == userId)
                    .FirstOrDefault();
                dispositivo.cliente_id = cliente.id;
                db.Dispositivo.Add(dispositivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre", dispositivo.cliente_id);
            return View(dispositivo);
        }

        // GET: DispositivoCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre", dispositivo.cliente_id);
            return View(dispositivo);
        }

        // POST: DispositivoCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cliente_id,nombre_generico,consumo_hora,encendido,modo_ahorro_energia,consumo,uso_mensual_max,uso_mensual_min,inteligente,tipo_dispositivo,uso_estimado")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente_id = new SelectList(db.Cliente, "id", "nombre", dispositivo.cliente_id);
            return View(dispositivo);
        }

        // GET: DispositivoCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // POST: DispositivoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            db.Dispositivo.Remove(dispositivo);
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
