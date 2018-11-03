using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.ORM;
using Integrador.Services;

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
            UserService userService = new UserService();
            using (DBContext db = new DBContext())
            {
                var usr = db.Usuario.Where(u => u.username == usuario.username && u.password == usuario.password).FirstOrDefault();
                if (usr != null)
                {
                    Session["Username"] = usr.username.ToString();
                    ViewBag.Username = usr.username.ToString();
                    userService.CheckUser(usr);
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