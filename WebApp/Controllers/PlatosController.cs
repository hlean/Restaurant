using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class PlatosController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                return View(s.GetPlatos());
            }
            if(HttpContext.Session.GetInt32("LogueadoId") == null)
            {
                return View(s.GetPlatos());
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DarMegusta(int id)
        {
            if (HttpContext.Session.GetString("LogueadoRol") != "Cliente")
            {
                return RedirectToAction("Index","Home");
            }
            s.DarMegusta(id);
            return RedirectToAction("Index", "Platos");
        }
    }
}
