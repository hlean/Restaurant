using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Local : Servicio
    {
        public int NumeroMesa { get; set; }
        public Mozo Mozo { get; set; }
        public int CantComensales { get; set; }
        public static double PrecioCubierto { get; set; } = 50;

        public static double Propina { get; set; } = 1.1;


        public Local(Cliente cliente, DateTime fecha, int numeroMesa, Mozo mozo, int cantComensales) : base(cliente, fecha)
        {
            NumeroMesa = numeroMesa;
             Mozo = mozo;
            CantComensales = cantComensales;
        }


        public override double CalcularPrecio()
        {

            double precio = 0;

            foreach (PlatoCantidad pc in carrito)
            {
                precio += pc.Cantidad * pc.Plato.Precio;
            }

            precio += (PrecioCubierto * CantComensales) * Propina;

            PrecioFinal += precio;

            return precio;
        }


        public override string ToString()
        {
            return $"{Cliente} - {Fecha} - {NumeroMesa} - {Mozo} - {CantComensales} - {PrecioCubierto}";
        }
    }
}
