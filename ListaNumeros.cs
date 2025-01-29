using System;
using System.Collections.Generic;

namespace GENERICOSdELEGADOS2
{
    // Delegado genérico para operaciones matemáticas
    public delegate T Operacion<T>(T a, T b);

    // Clase genérica para manejar la lista de números
    public class ListaNumeros<T> where T : struct, IComparable, IConvertible
    {
        private List<T> numeros;

        public ListaNumeros()
        {
            numeros = new List<T>();
        }

        // Método para agregar un número a la lista
        public void Agregar(T numero)
        {
            numeros.Add(numero);
        }

        // Método para realizar operaciones matemáticas
        public T RealizarOperacion(Operacion<T> operacion)
        {
            if (numeros.Count < 2)
            {
                throw new InvalidOperationException("Debe haber al menos dos números en la lista para realizar una operación.");
            }

            T resultado = numeros[0];
            for (int i = 1; i < numeros.Count; i++)
            {
                resultado = operacion(resultado, numeros[i]);
            }

            return resultado;
        }

        // Método para imprimir la lista
        public void ImprimirLista()
        {
            Console.WriteLine("Lista de números:");
            foreach (var numero in numeros)
            {
                Console.Write($"{numero} ");
            }
            Console.WriteLine();
        }
    }
}