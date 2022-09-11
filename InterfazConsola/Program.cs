using System;
using System.Collections.Generic;
using Dominio;


namespace InterfazConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();
            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Listar todos los platos");
                Console.WriteLine("2 - Listado de clientes ordenado por apellido/nombre");
                Console.WriteLine("3 - Listado de los servicios entregados por un repartidor en un rango de fecha dado");
                Console.WriteLine("4 - Modificar el valor del precio minimo del plato");
                Console.WriteLine("5 - Dar de alta a un mozo");
                Console.WriteLine("0 - Salir");

                op = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (op)
                {
                    case 1: 
                        List<Plato> listaFiltradaPlato = s.GetPlatos();
                        if (listaFiltradaPlato.Count > 0)
                        {
                            foreach (Plato p in listaFiltradaPlato)
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se enoncontraron platos registrados");
                        }
                        break;

                    case 2:
                        List<Cliente> listaFiltradaCliente = s.GetClientes();
                        if (listaFiltradaCliente.Count > 0)
                        {
                            foreach (Cliente c in listaFiltradaCliente)
                            {
                                Console.WriteLine(c);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No se enoncontraron clientes registrados");
                        }
                  
                        break;

                    case 3:

                        Console.WriteLine("Ingrese una fecha inicial");
                        DateTime fechaInicial = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese una fecha final");
                        DateTime fechaFinal = DateTime.Parse(Console.ReadLine());

                        List<Servicio> listaFiltrada = s.GetEntregasRangoFecha(fechaInicial, fechaFinal);
                        if (listaFiltrada.Count > 0)
                        {
                            foreach(Servicio serv in listaFiltrada)
                            {
                                Console.WriteLine(serv);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay registros en ese rango de fecha");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Ingrese nuevo precio minimo");
                        double precioMin = double.Parse(Console.ReadLine());
                        Console.WriteLine("El anterior precio minimo era de " + Plato.PrecioMin);
                       
                        if (precioMin < 0)  
                        {
                            Console.WriteLine("Valor de precio minimo invalido");
                            Console.ReadLine();
                            return;
                        }
                        Plato.ModificarPrecioMinimo(precioMin);
                        Console.WriteLine("El precio minimo actual del plato es: " + Plato.PrecioMin);
                        Console.ReadLine();

                        break;
                    case 5:
                        Console.WriteLine("Ingrese nombre del mozo");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese apellido del mozo");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese numero de funcionario del mozo");
                        Int32 numFuncionario = int.Parse(Console.ReadLine());

                        Mozo nuevoMozo = new Mozo(nombre, apellido, numFuncionario);
                        Mozo Mvalidado = s.AltaMozo(nuevoMozo);
                        if(Mvalidado != null)
                        {
                            Console.WriteLine("Ingreso realizado con exito.");
                        }
                        else
                        {
                            Console.WriteLine("Error al registrar el alta, por favor ingrese los datos nuevamente.");
                        }
                        
                        break;

                }
                Console.ReadKey();
            }
            Console.ReadKey();
        }

    }
}
    




