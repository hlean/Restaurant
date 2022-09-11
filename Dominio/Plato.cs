using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Plato:IValidacion, IComparable<Plato>
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public static double PrecioMin { get; set; } = 100;
        public int Likes { get; set; }

        public Plato()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Plato(string nombre, double precio, double precioMin)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Precio = precio;
            PrecioMin = precioMin;
            Likes = 0;
        }


        public bool EsValido()//Valida si nombre es vacio y si el precio es mayor al precio minimo
        {
            return !String.IsNullOrEmpty(Nombre) && Precio > PrecioMin;
        }


        public static void ModificarPrecioMinimo(double nuevoPrecioMin)//Funcion que modifica el precio minimo ya establecido
        {
            PrecioMin = nuevoPrecioMin;

        }

        public override string ToString()
        {
            return $"#{Nombre}      -       Precio: ${Precio}        -       Precio Minimo: ${PrecioMin}";
        }


        public int CompareTo([AllowNull] Plato other)
        {
            if (Nombre.CompareTo(other.Nombre) > 0)
            {
                return 1;
            }
            else if (Nombre.CompareTo(other.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
    }
}

