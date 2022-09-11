using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PlatoCantidad
    {
        public Plato Plato { get; set; }
        public int Cantidad { get; set; }
    

    public PlatoCantidad(Plato plato, int cantidad)
    {
        Plato = plato;
        Cantidad = cantidad;
    }

    }
}
