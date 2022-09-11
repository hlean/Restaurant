using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {
        List<Persona> personas = new List<Persona>();
        List<Plato> platos = new List<Plato>();
        List<Servicio> servicios = new List<Servicio>();
        List<Usuario> usuarios = new List<Usuario>();

        
        private static Sistema instancia = null;

        public static Sistema GetInstancia()
        {

            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }
        public Sistema()
        {
            Precarga();
        }

        public List<Persona> GetPersonas() {
            return personas;
        }
        public Cliente GetCliente(int? idCliente)
        {
            foreach (Persona p in personas)
            {
                if (p is Cliente)
                {
                    Cliente c = p as Cliente;
                    if (c.Id.Equals(idCliente)) {
                        return c;
                    }
                }
            }
            return null;
        }

        public List<Cliente> GetClientes()  
        {
                List<Cliente> ret = new List<Cliente>();
                foreach (Persona p in personas)
                {
                    if (p is Cliente)   //Filtra los clientes de su padre Persona, para poder devolverlos en el menu.
                    {
                        Cliente c = p as Cliente;
                        ret.Sort(PorApellidoyNombre);

                    ret.Add(c);
                    }
                }
            ret.Reverse();
          return ret;
        }

        private int PorApellidoyNombre(Cliente a, Cliente b)
        {
            if (a.Apellido.CompareTo(b.Apellido) > 0)
                {
                    return 1;
                }
                else if (b.Apellido.CompareTo(a.Apellido) < 0)
                {
                    return -1;
            }
            else
            {
                if (a.Nombre.CompareTo(b.Nombre) < 0)
                {
                    return 1;
                }
                else if (b.Nombre.CompareTo(a.Nombre) > 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Servicio GetServicios(int idServ)
        {
            
                foreach (Servicio s in servicios)
                {
                    if (s.Id.Equals(idServ))
                    {
                        return s;
                    }
                }
            return null;
        }

        public Persona ValidarDatosLogin(string username, string password)
        {
            Persona p = null;
            foreach (Usuario u in usuarios)
            {
                if (u.Username.Equals(username) && u.Password.Equals(password) && u.Estado)
                {

                    p = GetPersona(u.IdPersona);
                }
            }
            return p;
        }

        private Persona GetPersona(int idPersona)
        {
            foreach (Persona p in personas)
            {
                if (p.Id.Equals(idPersona))
                {
                    return p;
                }
            }
            return null;
        }

        public Plato GetPlato(int id)
        {
            foreach (Plato p in platos)
            {
                if (p.Id.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }

        

        public List<Plato> GetPlatos()
        {
            List<Plato> ret = new List<Plato>();

            foreach (Plato p in platos)
            {
                ret.Sort();
                ret.Add(p);

            }
            return ret;
        }
        public List<Repartidor> GetRepartidores()
        {
            List<Repartidor> ret = new List<Repartidor>();

            foreach (Persona p in personas)
            {
                if (p is Repartidor) 
                {
                    Repartidor r = p as Repartidor;
                    ret.Add(r);
                }

            }
            return ret;
        }

       

        public Repartidor GetRepartidor(int id)
        {
            foreach (Persona p in personas)
            {
                if (p is Repartidor)
                {
                    Repartidor r = p as Repartidor;
                    if (r.Id.Equals(id))
                    {
                        return r;
                    }
                }
            }
            return null;
        }

        public List<Mozo> GetMozos()
        {
            List<Mozo> ret = new List<Mozo>();

            foreach (Persona p in personas)
            {
                if (p is Mozo)
                {
                    Mozo m = p as Mozo;
                    ret.Add(m);
                }
            }
            return ret;
        }

        public Mozo GetMozo(int id)
        {
            foreach (Persona p in personas)
            {
                if (p is Mozo)
                {
                    Mozo m = p as Mozo;
                    if (m.Id.Equals(id))
                    {
                        return m;
                    }
                }
            }
            return null;
        }
        public bool ValidarCamposDev(string direccion, double distancia)
        {
            if (distancia > 0 && !string.IsNullOrEmpty(direccion))
            {
                return true;
            }
            return false;
        }
        public bool ValidarCamposLocal(int cantComensales, int numMesa)
        {
            if (cantComensales > 0 && numMesa > 0)
            {
                return true;
            }
            return false;
        }
        public bool ValidarSelect(string slcTipoServ)
        {
            if (slcTipoServ != null)
            {
                return true;
            }
            return false;
        }

        public bool ValidarDatosAgregarPlato(int plato, int cantidad)
        {
            if (cantidad > 0 && plato != 0)
            {
                return true;
            }
            return false;
        }
        public List<Servicio> GetServicio()
        {
            return servicios;
        }


        public Servicio AltaServicio(Servicio serv)
        {
            if (serv.EsValido())
            {
                servicios.Add(serv);
                return serv;

            }
            return null;
        }

        public Plato AltaPlato(Plato p)
        {
            if (p.EsValido())
            {
                platos.Add(p);
                return p;

            }
            return null;
        }

        public Mozo AltaMozo(Mozo m, string username, string password)
        {
            if (m.EsValido())
            {
                personas.Add(m);
                Usuario nuevoUser = new Usuario(m.Id, username, password);
                usuarios.Add(nuevoUser);
                return m;

            }
            return null;
        }

     
        public Cliente AltaCliente(Cliente c, string username, string password)
        {
            if (c.EsValido() && c.ValidarNombreApellido())
            {
                personas.Add(c);
                Usuario nuevoUser = new Usuario(c.Id, username, password);
                if (nuevoUser.EsValido()) { 
                usuarios.Add(nuevoUser);
                return c;
                }
            }
            return null;
        }

      

        public Repartidor AltaRepartidor(Repartidor r, string username, string password)
        {
            if (r.EsValido())
            {
                personas.Add(r);
                Usuario nuevoUser = new Usuario(r.Id, username, password);
                usuarios.Add(nuevoUser);
                return r;

            }
            return null;
        }

        public Local AltaLocal(Local l)
        {
            if (l.EsValido())
            {
                servicios.Add(l);
                return l;

            }
            return null;
        }

        public Delivery AltaDelivery(Delivery d)
        {
            if (d.EsValido())
            {
                servicios.Add(d);
                return d;

            }
            return null;
        }

        public List<Servicio> GetEntregasRangoFecha(DateTime i, DateTime f)
        {
            if (i > f)
            {
                DateTime aux = i;
                i = f;
                f = aux;

            }
            List<Servicio> ret = new List<Servicio>();
            foreach (Servicio serv in servicios)
            {
                if (serv.Fecha >= i && serv.Fecha <= f)
                {
                    ret.Add(serv);
                }
            }
            return ret;
        }

        public void DarMegusta(int idPlato)
        {
            Plato p = GetPlato(idPlato);
            p.Likes++;
        }
        public List<Local> AtendioServicioEntre(DateTime f1, DateTime f2, int? idLog)
        {
            if (f1 > f2)
            {
                DateTime aux = f1;
                f1 = f2;
                f2 = aux;
            }

            List<Local> ret = new List<Local>();
            foreach (Servicio s in servicios)
            {
                if (s is Local)
                {
                    if (s.Fecha >= f1 && s.Fecha <= f2)
                    {
                        Local l = s as Local;
                        if (l.Mozo.Id.Equals(idLog)) { 
                        ret.Add(l);
                        }
                    }
                }
            }
            return ret;
        }

        public List<Delivery> ServiciosEntregados(int? idLog) 
        {
            List<Delivery> ret = new List<Delivery>();

            foreach (Servicio p in servicios)
            {
                if (p is Delivery)
                {
                    Delivery d = p as Delivery;

                    if (d.Repartidor.Id.Equals(idLog)) {
                        ret.Add(d);
                    }
                }
            }
            return ret;
        }

        

        public List<Servicio> MisServicios(DateTime f1, DateTime f2, int? idLog)
        {
            if (f1 > f2)
            {
                DateTime aux = f1;
                f1 = f2;
                f2 = aux;
            }

            List<Servicio> ret = new List<Servicio>();
            foreach (Servicio s in servicios)
            {
                if (s.Fecha >= f1 && s.Fecha <= f2)
                {
                    if (s.Cliente.Id.Equals(idLog))
                    {
                    ret.Add(s);
                    }
                }

            }
            return ret;
        }
        public List<Servicio> PediXPlato(string nomPlato, int? idLog)
        {
            List<Servicio> ret = new List<Servicio>();
            
            foreach (Servicio s in servicios)
            {
                if (s.Cliente.Id.Equals(idLog))
                {
                    if (BuscarPlatoCantidad(nomPlato, s.carrito))
                    {
                        ret.Add(s);               
                    }
                }   
            }
            return ret;
        }
        public bool BuscarPlatoCantidad(string nP, List<PlatoCantidad> carrito)
        {
            foreach (PlatoCantidad pc in carrito)
            {
                if (pc.Plato.Nombre.Equals(nP))
                {
                    return true;
                }
            }
            return false;
        }


        public List<Servicio> GetServiciosUsu(int idUsuario)
        {
            List<Servicio> ret = new List<Servicio>();

            foreach (Servicio se in servicios)
            {
                if (se.Cliente.Id == idUsuario)
                {
                    ret.Add(se);
                }
            }
            return ret;
        }


        private void Precarga()
        {
            Plato p1 = new Plato("Pancho con muzzarella", 128, Plato.PrecioMin);
            AltaPlato(p1);
            Plato p2 = new Plato("Sandwich caliente", 330, Plato.PrecioMin);
            AltaPlato(p2);
            Plato p3 = new Plato("Chivito canadiense", 585, Plato.PrecioMin);
            AltaPlato(p3);
            Plato p4 = new Plato("Papas fritas (porcion)", 285, Plato.PrecioMin);
            AltaPlato(p4);
            Plato p5 = new Plato("Pollo grille", 600, Plato.PrecioMin);
            AltaPlato(p5);
            Plato p6 = new Plato("Churrasco de cuadril", 710, Plato.PrecioMin);
            AltaPlato(p6);
            Plato p7 = new Plato("Spaghettis a la bolognesa", 490, Plato.PrecioMin);
            AltaPlato(p7);
            Plato p8 = new Plato("Hamburguesa napolitana", 505, Plato.PrecioMin);
            AltaPlato(p8);
            Plato p9 = new Plato("Omelette de jamon y queso", 440, Plato.PrecioMin);
            AltaPlato(p9);
            Plato p10 = new Plato("Ravioles a la carusso", 560, Plato.PrecioMin);
            AltaPlato(p10);



            Cliente c1 = new Cliente("Dante", "Sosa");
            AltaCliente(c1,"DanteSosa","DanteSosa1");
            Cliente c2 = new Cliente("Mariana", "Sosa");
            AltaCliente(c2,"MarianaS", "MarianaSosa2");
            Cliente c3 = new Cliente("Jorge", "Hernandez");
            AltaCliente(c3, "JorguitoHer", "JorgeHernandez3");
            Cliente c4 = new Cliente("Allison", "Vega");
            AltaCliente(c4, "VegaAllison", "AllisonVega4");
            Cliente c5 = new Cliente("Rodrigo", "Amaro");
            AltaCliente(c5, "RodriAmaro", "RodrigoAmaro5");


            Mozo m1 = new Mozo("Walter", "Sanchez", 13);
            AltaMozo(m1,"MozoWalter","WalterSanchez13");
            Mozo m2 = new Mozo("Gimena", "Gonzalez", 4);
            AltaMozo(m2, "MozaGimena", "GimenaGonzalez4");
            Mozo m3 = new Mozo("Daiana", "Dorta", 21);
            AltaMozo(m3, "MozaDaiana", "DaianaDorta21");
            Mozo m4 = new Mozo("Juan", "Castro", 15);
            AltaMozo(m4, "MozoJuan", "JuanCastro15");
            Mozo m5 = new Mozo("Melina", "Castillo", 9);
            AltaMozo(m5, "MozaMelina", "MelinaCastillo9");


            Repartidor r1 = new Repartidor("Leonel", "Amado", Repartidor.Vehiculos.Moto);
            AltaRepartidor(r1, "REPLeonel", "LeonelAmado1");
            Repartidor r2 = new Repartidor("Omar", "Garcia", Repartidor.Vehiculos.Pie);
            AltaRepartidor(r2,"REPOmar", "OmarGarcia2");
            Repartidor r3 = new Repartidor("Alexander", "Rojas", Repartidor.Vehiculos.Bicicleta);
            AltaRepartidor(r3, "REPAlexander", "AlexanderRojas3");
            Repartidor r4 = new Repartidor("Facundo", "Diana", Repartidor.Vehiculos.Moto);
            AltaRepartidor(r4, "REPFacundo", "FacundoDiana4");
            Repartidor r5 = new Repartidor("Cristian", "Gomez", Repartidor.Vehiculos.Bicicleta);
            AltaRepartidor(r5, "REPCristian", "CristianGomez5");


            Local l1 = new Local(c1, new DateTime (2018,05,07),1,m5,5);
            AltaLocal(l1); 
            l1.AgregarPlatoCarrito(p1, 2);
            l1.AgregarPlatoCarrito(p2, 3);
            
            Local l2 = new Local(c2, new DateTime(2019, 08, 04), 3, m4, 6);
            AltaLocal(l2);
            l2.AgregarPlatoCarrito(p1, 2);
            l2.AgregarPlatoCarrito(p3, 2);
            
            Local l3 = new Local(c3, new DateTime(2020, 01, 01), 4, m3, 2);
            AltaLocal(l3);
            l3.AgregarPlatoCarrito(p1, 1);
            l3.AgregarPlatoCarrito(p5, 3);
            
            Local l4 = new Local(c4, new DateTime(2021, 08, 09), 7, m2, 5);
            AltaLocal(l4);
            l4.AgregarPlatoCarrito(p7, 1);
            l4.AgregarPlatoCarrito(p2, 2);
            l4.AgregarPlatoCarrito(p6, 1);
            
            Local l5 = new Local(c5, new DateTime(2022, 03, 02), 6, m1, 6);
            AltaLocal(l5);
            l5.AgregarPlatoCarrito(p10, 2);
            l5.AgregarPlatoCarrito(p8, 1);
            l5.AgregarPlatoCarrito(p6, 2);
            l5.AgregarPlatoCarrito(p9, 1);

            Delivery d1 = new Delivery(c5, new DateTime(2019, 04, 03), "Bulevar del Bicentenario 318", r2, 2);
            AltaDelivery(d1);
            d1.AgregarPlatoCarrito(p5, 3);
            
            Delivery d2 = new Delivery(c4, new DateTime(2020, 02, 11), "Av Roosevelt Y Av Fco. Acuña De Figueroa", r3, 6);
            AltaDelivery(d2);
            d2.AgregarPlatoCarrito(p2, 1);
            d2.AgregarPlatoCarrito(p5, 3);
            d2.AgregarPlatoCarrito(p9, 1);
            
            Delivery d3 = new Delivery(c3, new DateTime(2021, 08, 23), "Av Joaquin De Viena Y Roman Bergali", r4, 1);
            AltaDelivery(d3);
            d3.AgregarPlatoCarrito(p5, 1);
            d3.AgregarPlatoCarrito(p6, 1);
            d3.AgregarPlatoCarrito(p3, 1);
            d3.AgregarPlatoCarrito(p7, 1);
            
            Delivery d4 = new Delivery(c2, new DateTime(2022, 03, 12), "Treinta y Tres y 18 de Julio", r2, 3);
            AltaDelivery(d4);
            d4.AgregarPlatoCarrito(p1, 2);
            d4.AgregarPlatoCarrito(p2, 5);
            
            Delivery d5 = new Delivery(c1, new DateTime(2022, 04, 03), "Gral. Flores 444", r5, 4);
            AltaDelivery(d5);
            d5.AgregarPlatoCarrito(p4, 3);

        }
    }
}
