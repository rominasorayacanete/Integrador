using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.DAL;
using Integrador.Models;
using Integrador.Services;

namespace Integrador.Controllers
{
    public class UsuarioController : Controller
    {
        private Context db = new Context();

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

            var usr = db.Usuarios.Where(u => u.Username == usuario.Username && u.Password == usuario.Password).FirstOrDefault();

            if (usr != null)
            {
                Session["Username"] = usr.Username;
                Session["UserId"] = usr.Id;
                ViewBag.Username = usr.Username.ToString();
                userService.CheckUser(usr.Id);

                if (userService.isAdmin(usr))
                {
                    Session["Role"] = "Admin";
                }
                else
                {
                    Session["ClientId"] = userService.GetClientId(usr);

                }

                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos, intente de nuevo.");
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

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}