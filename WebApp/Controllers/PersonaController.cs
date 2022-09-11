using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class PersonaController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            return View(s.GetPersonas());
        }

        public IActionResult Registrar()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == null) 
            { 
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Registrar(Cliente c, string username, string password)
        {
            
                if (s.AltaCliente(c, username, password) != null)
            {
                ViewBag.mensaje = "Usted se registro con exito";
            }
            else
            {
                ViewBag.mensaje = "Error en los datos";
            }
            return View();
        }


        public IActionResult AtendioServicio()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Mozo") 
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult AtendioServicio(DateTime f1, DateTime f2)
        {
            int? idLog = HttpContext.Session.GetInt32("LogueadoId");
            List<Local> filtrados = s.AtendioServicioEntre(f1, f2, idLog);
            
                if (filtrados.Count > 0)
                {
                    return View(filtrados);
                }
                else
                {
                    ViewBag.mensaje = "Usted no tiene registro de servicios atendidos en el periodo de fechas indicado";
                    return View();
                }
        }


        public IActionResult ServiciosEntregados()
        {
            int? idLog = HttpContext.Session.GetInt32("LogueadoId");
            List<Delivery> servicEntregados = s.ServiciosEntregados(idLog);


            if (HttpContext.Session.GetString("LogueadoRol") == "Repartidor")
            {
                if (servicEntregados.Count > 0)
                {
                    return View(servicEntregados);
                }
                else
                {
                    ViewBag.mensaje = "Usted no tiene registros de entregas";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult MisServicios()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult MisServicios(DateTime f1, DateTime f2) 
        {

            int? idLog = HttpContext.Session.GetInt32("LogueadoId");
            List<Servicio> servic = s.MisServicios(f1, f2, idLog);
                if (servic.Count > 0)
                {
                    return View(servic);
                }
                else
                {
                    ViewBag.mensaje = "Usted no tiene registros de pedidos en el periodo de fechas indicado";
                    return View();
                }
        }


        public IActionResult Details(int id) /*Mostrar detalles de los servicios, muestras los platos*/
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                Servicio b = s.GetServicios(id);
                return View(b);
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult PediXPlato()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult PediXPlato(string nomPlato)
        {
            int? idLog = HttpContext.Session.GetInt32("LogueadoId");
            List<Servicio> filtradas = s.PediXPlato(nomPlato, idLog);

                if (filtradas.Count > 0)
                {
                    return View(filtradas);
                }
                else
                {
                    ViewBag.mensaje = "Usted no tiene ningun servicio con este plato";
                    return View();
                }
        }
        

        public IActionResult HacerPedido()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult HacerPedido(string slcTipoServ)
        {
            
                bool validar = s.ValidarSelect(slcTipoServ);
                if (validar)
                {
                    if (slcTipoServ.Equals("OpcLocal"))
                    {
                        return RedirectToAction("Local", "Persona");
                    }
                    if (slcTipoServ.Equals("OpcDelivery"))
                    {
                        return RedirectToAction("Delivery", "Persona");
                    }
                }
                ViewBag.mensaje = "Debe seleccionar una opcion de pedido";
                return View();
        }


        public IActionResult Delivery()
        {
            List<Repartidor> todosLosRepartidores = s.GetRepartidores();
            ViewBag.TodosLosRep = todosLosRepartidores;
            return View();
        }
        [HttpPost]
        public IActionResult Delivery(string direccion, double distancia)
        {
            bool validar = s.ValidarCamposDev(direccion, distancia);
            if (validar)
            {
                List<Repartidor> todosLosRepartidores = s.GetRepartidores();
            ViewBag.TodosLosRep = todosLosRepartidores;

            int? idLog = HttpContext.Session.GetInt32("LogueadoId");
            Cliente cliente = s.GetCliente(idLog);

            Random repRandom = new Random();

            int idRepRandom = repRandom.Next(s.GetRepartidores()[1].Id, s.GetRepartidores()[s.GetRepartidores().Count - 1].Id);

            Delivery nuevoSDev = new Delivery(cliente, DateTime.Now, direccion, s.GetRepartidor(idRepRandom), distancia);
            s.AltaDelivery(nuevoSDev);

            
                return RedirectToAction("MisServicios", "Persona");

            }
            ViewBag.mensaje = "Error en los datos ingresados";
            return View();

        }

        public IActionResult Local()
        {
            List<Mozo> todosLosMozos = s.GetMozos();
            ViewBag.TodosLosMozos = todosLosMozos;
            return View();
        }

        [HttpPost]
        public IActionResult Local(int cantComensales, int numMesa)
        {
            bool validar = s.ValidarCamposLocal(cantComensales, numMesa);
            if (validar)
            {
                List<Mozo> todosLosMozos = s.GetMozos();
                ViewBag.TodosLosMozos = todosLosMozos;

                int? idLog = HttpContext.Session.GetInt32("LogueadoId");
                Cliente cliente = s.GetCliente(idLog);

                Random mozoRandom = new Random();

                int idMozoRandom = mozoRandom.Next(s.GetMozos()[1].Id, s.GetMozos()[s.GetMozos().Count - 1].Id);

                Local nuevoSLocal = new Local(cliente,DateTime.Now,numMesa, s.GetMozo(idMozoRandom), cantComensales);
                s.AltaLocal(nuevoSLocal);

                return RedirectToAction("MisServicios", "Persona");

            }
            ViewBag.mensaje = "Error en los datos ingresados";
            return View();
        }


        public IActionResult AgregarPlato(int idServ)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                Servicio serv = s.GetServicios(idServ);

                List<Plato> todosLosPlatos = s.GetPlatos();

                List<PlatoCantidad> platosCantidad = serv.GetPlatosCantidad();

                ViewBag.Servicios = serv;

                ViewBag.Platos = todosLosPlatos;

                ViewBag.PC = platosCantidad;

                return View();
            }
            return RedirectToAction("Index", "Home");


        }

        [HttpPost]
        public IActionResult AgregarPlato(int id, int plato, int cantidad)
        {
            Servicio serv = s.GetServicios(id);

            List<Plato> todosLosPlatos = s.GetPlatos();

            List<PlatoCantidad> platosCantidad = serv.GetPlatosCantidad();

            ViewBag.Servicios = serv;

            ViewBag.Platos = todosLosPlatos;

            ViewBag.PC = platosCantidad;


            bool validarDatos = s.ValidarDatosAgregarPlato(plato, cantidad);
            if (validarDatos && serv.Estado=="Abierto") 
            { 
                Plato pl = s.GetPlato(plato);
                PlatoCantidad pc = new PlatoCantidad(pl, cantidad);

                ViewBag.mensaje = "Su plato fue agregado con exito";
                return View(serv.AgregarPlatos(pc));
            }
            ViewBag.mensaje = "Error en los datos ingresados y/o su pedido ya fue cerrado";
            return View();
        }



        public IActionResult Cerrarpedido(int idServ)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "Cliente")
            {
                Servicio b = s.GetServicios(idServ);
                b.InstanciaCerrar();

                return RedirectToAction("MisServicios", "Persona");
            }
            return View();
        }



        public IActionResult ServiciosMasCaros()
        {
            int? idLog = HttpContext.Session.GetInt32("LogueadoId");
            Cliente c = s.GetCliente(idLog);
            List<Servicio> ret = new List<Servicio>();
            List<Servicio> MisServicios = s.GetServiciosUsu(c.Id);
            double max = 0;
            foreach (Servicio ser in MisServicios)
            {
                if (ser.PrecioFinal > max)
                {
                    max = ser.PrecioFinal;
                    ret.Clear();
                    ret.Add(ser);
                }
                else if (ser.PrecioFinal == max)
                {
                    ret.Add(ser);
                }
                else if (MisServicios == null)
                {
                    ViewBag.ServiciosVacios = "Usted no tiene servicios asignados";
                }
            }
            return View(ret);

        }



    }
}
