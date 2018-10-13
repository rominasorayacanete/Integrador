using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.ORM;

namespace Integrador.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            using (DBContext db = new DBContext())
            {
                var usr = db.Usuario.Where(u => u.Nombre_usuario == usuario.Nombre_usuario && u.Contrasenia == usuario.Contrasenia).FirstOrDefault();
                if (usr != null)
                {
                    Session["Username"] = usr.Nombre_usuario.ToString();
                    ViewBag.Username = usr.Nombre_usuario.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos, intente de nuevo.");
                }
            }
                return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Username"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}