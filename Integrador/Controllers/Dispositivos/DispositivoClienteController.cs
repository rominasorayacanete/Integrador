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
using Integrador.Models.Clases.Helper;
using System.IO;
using Newtonsoft.Json;

namespace Integrador.Controllers.Dispositivos
{
    public class DispositivoClienteController : Controller
    {
        private Context db = new Context();
        private DispositivoService dispositivoService = new DispositivoService();

        // GET: DispositivoCliente
        [ActionName("Index")]
        public ActionResult Index(int? id)
        {
            var _dispositivoInteligentes = db.DispositivosInteligentes.Where(d => d.Cliente.Id == id).ToList();
            var _dispositivosEstandar = db.DispositivoEstandar.Where(d => d.Cliente.Id == id).ToList();
            var listado = new ListadoDispositivos
            {
                DispositivosEstandar = _dispositivosEstandar,
                DispositivosInteligente = _dispositivoInteligentes
            };

            return View(listado);
        }

        public ActionResult CargarDispositivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarInteligente(HttpPostedFileBase jsonFile)
        {
            if (!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {
                ViewBag.Error = "Tipo de archivo inváido.";
            }
            else
            {
                var clientId = Convert.ToInt32(Session["ClientId"].ToString());
                jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                string data = streamReader.ReadToEnd();
                List<DispositivoInteligente> dispositivos = JsonConvert.DeserializeObject<List<DispositivoInteligente>>(data);
                dispositivos.ForEach(d => {
                    DispositivoInteligente dispositivo = new DispositivoInteligente()
                    {
                        NombreGenerico = d.NombreGenerico,
                        Consumo = d.Consumo,
                        Encendido = d.Encendido,
                        ModoAhorroDeEnergia = d.ModoAhorroDeEnergia,
                        UsoMensualMax = d.UsoMensualMax,
                        UsoMensualMin = d.UsoMensualMin,
                        Inteligente = true,
                        ClienteID = clientId,
                    };
                    db.DispositivosInteligentes.Add(dispositivo);
                });

                db.Clientes.Find(clientId).SumarPuntos(15);
                db.SaveChanges();
                ViewBag.Success = "Success";
                return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });

            }

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult CargarEstandar(HttpPostedFileBase jsonFile)
        {
            if (!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {
                ViewBag.Error = "Tipo de archivo inváido.";
            }
            else
            {
                var clientId = Convert.ToInt32(Session["ClientId"].ToString());
                jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));
                string data = streamReader.ReadToEnd();
                List<DispositivoEstandar> dispositivos = JsonConvert.DeserializeObject<List<DispositivoEstandar>>(data);
                dispositivos.ForEach(d => {
                    DispositivoEstandar dispositivo = new DispositivoEstandar()
                    {
                        NombreGenerico = d.NombreGenerico,
                        Consumo = d.Consumo,
                        Inteligente = false,
                        UsoMensualMax = d.UsoMensualMax,
                        UsoMensualMin = d.UsoMensualMin,
                        ClienteID = clientId,
                    };
                    db.DispositivoEstandar.Add(dispositivo);
                });

                db.SaveChanges();
                ViewBag.Success = "Success";
                return RedirectToAction("Index", "DispositivoCliente", new { id = clientId });
            }

            return View("~/Views/Home/Index.cshtml");
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
