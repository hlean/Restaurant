using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        Sistema s = Sistema.GetInstancia();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? logueado_id = HttpContext.Session.GetInt32("LogueadoId");
            string logueado_rol = HttpContext.Session.GetString("LogueadoRol");

            if (logueado_id != null)
            {
                ViewBag.mensaje = $"Bienvenido, usted es un {logueado_rol}.";
            }
            else
            {
                ViewBag.mensaje = "Usted puede iniciar sesion en el apartado LOGIN o registrarse en el apartado REGISTRARME";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == null)  /*Si no es usuario sin loguear, deja que completar los campos pero despues salta al RedirectToAction("Index", "Home"); */
            {
                Persona b = s.ValidarDatosLogin(username, password);
                if (b != null)
                {
                    HttpContext.Session.SetInt32("LogueadoId", b.Id);
                    HttpContext.Session.SetString("LogueadoRol", b.GetType().Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "Error de datos";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
