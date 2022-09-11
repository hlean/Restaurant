using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public abstract class Servicio : IValidacion
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }
        public double PrecioFinal { get; set; }

        public List<PlatoCantidad> carrito = new List<PlatoCantidad>();


        public string Estado { get; set; }

        protected Servicio(Cliente cliente, DateTime fecha)
        {
            Id = UltimoId;
            UltimoId++;
            Cliente = cliente;
            Fecha = fecha;
            Estado = "Abierto";
        }
        public Servicio()
        {
            Id = UltimoId;
            UltimoId++;
            Estado = "Abierto";
        }
        public List<PlatoCantidad> GetCarrito()
        {
            return carrito;
        }
        public bool AgregarPlatoCarrito(Plato p, int cantidad)
        {
            PlatoCantidad nuevo = new PlatoCantidad(p, cantidad);
            carrito.Add(nuevo);
            return true;
        }


        public virtual bool EsValido()
        {
            return true;
        }

        public abstract double CalcularPrecio();



        public bool AgregarPlatos(PlatoCantidad pc)
        {
            if (Estado.Equals("Abierto"))
            {
                carrito.Add(pc);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<PlatoCantidad> GetPlatosCantidad()
        {
            List<PlatoCantidad> ret = new List<PlatoCantidad>();

            foreach (PlatoCantidad p in carrito)
            {

                PlatoCantidad pc = p as PlatoCantidad;
                ret.Add(pc);
            }
            return ret;
        }




        public double precioCantidad(double pf, double pcprecio)
        {
            double precioCantidad = pf * pcprecio;

            return precioCantidad;
        }

        public void InstanciaCerrar()
        {
            if (Estado == "Abierto")
            {
                
                PrecioFinal = CalcularPrecio();
                Estado = "Cerrado";
            }
        }


    }
}
