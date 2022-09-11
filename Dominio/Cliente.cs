using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Cliente:Persona ,IValidacion, IComparable<Cliente>
    {
        public Cliente(string nombre, string apellido) : base(nombre, apellido)
        {
            
        }
        public Cliente()
        {
                
        }

        public bool ValidarNombreApellido()
        {
            return NoNumsNombre(Nombre) && NoNumsApellido(Apellido);
        }

        private bool NoNumsNombre(string nombre)
        {
                bool retorno = true;
                foreach (char c in nombre)
                {
                    if (char.IsDigit(c))
                    {
                        retorno = false;
                    }
                }
                return retorno; 
        }
        private bool NoNumsApellido(string apellido)
        {
            bool retorno = true;
            foreach (char c in apellido)
            {
                if (char.IsDigit(c))
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        public int CompareTo([AllowNull] Cliente other)
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
                if (Apellido.CompareTo(other.Apellido) > 0)
                {
                    return 1;
                }
                else if (Apellido.CompareTo(other.Apellido) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

public override string ToString()
        {
            return $"{Apellido} - {Nombre}";
        }
    }
}

