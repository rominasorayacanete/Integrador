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
using Integrador.Models.Clases.Helper;

namespace Integrador.Controllers.Dispositivos
{
    public class DispositivoClienteController : Controller
    {
        private Context db = new Context();

        // GET: DispositivoCliente
        public ActionResult Index()
        {
            var _dispositivoInteligentes = db.DispositivosInteligentes.ToList();
            var _dispositivosEstandar = db.DispositivosEstandar.ToList();
            var listado = new ListadoDispositivos
            {
                DispositivosEstandar = _dispositivosEstandar,
                DispositivosInteligente = _dispositivoInteligentes
            };

            return View(listado);
        }

        // GET: DispositivoCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // GET: DispositivoCliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DispositivoCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreGenerico,Consumo,UsoMensualMax,UsoMensualMin,Encendido,ModoAhorroDeEnergia")] DispositivoInteligente dispositivoInteligente)
        {
            if (ModelState.IsValid)
            {
                db.Dispositivos.Add(dispositivoInteligente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dispositivoInteligente);
        }

        // GET: DispositivoCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // POST: DispositivoCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreGenerico,Consumo,UsoMensualMax,UsoMensualMin")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dispositivo);
        }

        // GET: DispositivoCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivos.Find(id);
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
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            db.Dispositivos.Remove(dispositivo);
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
