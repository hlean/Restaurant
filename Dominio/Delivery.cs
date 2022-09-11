using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Delivery : Servicio
    {

        public string DireccionEnvio { get; set; }
        public Repartidor Repartidor { get; set; }
        public double Distancia { get; set; }

        public Delivery(Cliente cliente, DateTime fecha, string direccionEnvio, Repartidor repartidor, double distancia) : base(cliente, fecha)
        {
            DireccionEnvio = direccionEnvio;
            Repartidor = repartidor;
            Distancia = distancia;
        }

        public Delivery()
        {

        }

        public override double CalcularPrecio()
        {
            double precio = 50;
   

            foreach (PlatoCantidad pc in carrito)
            {
                precio += pc.Cantidad * pc.Plato.Precio;

                if (Distancia > 2 && Distancia <= 3)
                {
                    precio += 10;
                }
                else if (Distancia > 3 && Distancia <= 4)
                {
                    precio += 20;
                }
                else if (Distancia > 4 && Distancia <= 5)
                {
                    precio += 30;
                }
                else if (Distancia > 5 && Distancia <= 6)
                {
                    precio += 40;
                }
                else if (Distancia > 6)
                {
                    precio += 50;
                }
            }
            return precio;
        }

        public override string ToString()
        {
            return $"{Cliente} - {Fecha} - {DireccionEnvio} - {Repartidor} - {Distancia}";
        }

    }
}
