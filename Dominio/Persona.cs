using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Persona:IValidacion
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Persona()
        {
            Id = UltimoId;
            UltimoId++;
        }

        protected Persona(string nombre, string apellido)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
        }

        public virtual bool EsValido() //Valida si el nombre y apellido de sus hijos son vacios
        {
            return !String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Apellido);
        }


    }
}
