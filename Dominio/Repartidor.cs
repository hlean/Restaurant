using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Repartidor:Persona
    {
        public Vehiculos Vehiculo { get; set; }

   
        public Repartidor(string nombre, string apellido, Vehiculos vehiculo) : base(nombre, apellido)
        {
            Vehiculo = vehiculo;
        }

        public Repartidor()
        {

        }

        public enum Vehiculos
        {
            Moto,
            Bicicleta,
            Pie
        }

        public override string ToString()
        {
            return $"{Nombre} - {Apellido} - {Vehiculo}";
        }
    }
}
