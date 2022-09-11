using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario: IValidacion
    {
        public int IdPersona { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }

        public Usuario(int idPersona, string username, string password)
        {
            IdPersona = idPersona;
            Username = username;
            Password = password;
            Estado = true;
        }

        public Usuario()
        {

        }
        public bool EsValido()
        {
            return PasswordEsValido(Password);
        }


        private bool PasswordEsValido(string password)
        {
            //Validar que el password tenga un largo de 5 caracteres, que contenga al menos una minuscula, una mayuscula y un numero.
            bool retorno = false;
            if (password.Length >= 6)
            {
                if (ValidarMayusculas(password) && ValidarMinusculas(password) && ValidarNumeros(password))
                {
                    retorno = true;

                }
            }
            return retorno;
        }


        private bool ValidarMayusculas(string password)//Busca una letra mayuscula en el password y retorna true si encontro la misma, si no false. 
        {
            bool retorno = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        private bool ValidarMinusculas(string password)//Busca una letra minuscula en el password y retorna true si encontro la misma, si no false.
        {
            bool retorno = false;
            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        private bool ValidarNumeros(string password)//Busca un numero en el password y retorna true si encontro la misma, si no false.
        {
            bool retorno = false;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        
    }
}
