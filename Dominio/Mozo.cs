using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Mozo:Persona
    {
        public int NumFuncionario { get; set; }

        public Mozo()
        {

        }

        public Mozo(string nombre, string apellido, int numFuncionario) : base(nombre, apellido)
        {
            NumFuncionario = numFuncionario;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Apellido} - {NumFuncionario}";
        }

        public override bool EsValido()//Valida que el nombre y apellido no sean vacios, que ninguno de ellos contenga numeros y que el numero de funcionario sea unico.
        {
            return base.EsValido() && NoContieneNumsNombre(Nombre) && NoContieneNumsApellido(Apellido);
        }

        private bool NoContieneNumsNombre(string nombre)//Valida que el nombre del mozo no contenga numeros al darlo de alta
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

        private bool NoContieneNumsApellido(string apellido)//Valida que el apellido del mozo no contenga numeros al darlo de alta
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
    }
}
