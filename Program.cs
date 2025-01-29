using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENERICOSdELEGADOS2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione el tipo de numero para la lista:");
            Console.WriteLine("1. Enteros (int)");
            Console.WriteLine("2. Decimales (double)");
            Console.WriteLine("3. Precision decimal (decimal)");

            try
            {
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ManejarLista<int>();
                        break;

                    case 2:
                        ManejarLista<double>();
                        break;
                    case 3:
                        ManejarLista<decimal>();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un numero valido.");

            }
        }

        static void ManejarLista<T>() where T : struct, IComparable, IConvertible
        {
            ListaNumeros<T> Lista = new ListaNumeros<T>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1.Agregar numero a la lista");
                Console.WriteLine("2. Sumar los numeros");
                Console.WriteLine("3. Restar los numeros");
                Console.WriteLine("4. Multiplicar los numeros");
                Console.WriteLine("5. Dividir los numeros");
                Console.WriteLine("6. Mostrar lista");
                Console.WriteLine("7. Salir");
                Console.WriteLine("Seleccione una opcion: ");

                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese un numero:");
                            T numero = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                            Lista.Agregar(numero);
                            Console.WriteLine("Numero agregado correctamente.");
                            break;

                        case 2:
                            Console.WriteLine("Ingrese un numero:");
                            T suma = Lista.RealizarOperacion((a, b) => (dynamic)a + (dynamic)b);
                            Console.WriteLine($"Suma de los numeros: {suma}");
                            break;

                        case 3:
                            Console.WriteLine("Ingrese un numero:");
                            T resta = Lista.RealizarOperacion((a, b) => (dynamic)a - (dynamic)b);
                            Console.WriteLine($"Resta de los numeros: {resta}");
                            break;

                        case 4:
                            Console.WriteLine("Ingrese un numero:");
                            T multiplicacion = Lista.RealizarOperacion((a, b) => (dynamic)a * (dynamic)b);
                            Console.WriteLine($"Multiplicacion de los numeros: {multiplicacion}");
                            break;

                        case 5:
                            try
                            {
                                T division = Lista.RealizarOperacion((a, b) =>
                                {
                                    if ((dynamic)b == 0) throw new DivideByZeroException();
                                    return (dynamic)a / (dynamic)b;
                                });
                                Console.WriteLine($"División de los números: {division}");
                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("Error: División por cero no permitida.");
                            }
                            break;

                        case 6:
                            Lista.ImprimirLista();
                            break;

                        case 7:
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Entrada no válida. Por favor, intente nuevamente.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
