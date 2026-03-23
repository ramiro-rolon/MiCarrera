using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace TP6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Limite = 10;
            // Ejercicio 1
            List<int> numeros = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            Random objAleatorio = new Random();
            for (int i = 0; i < 10; i++)
            {
                int nroAleatorio = objAleatorio.Next(1, Limite);
                numeros.Add(nroAleatorio);
            }

            // Ejercicio 2: Prueba de muestreo de la lista

            //            for (int i = 0; i < numeros.Count; i++) 
            //            {
            //                Console.WriteLine(numeros[i]);
            //            }

            ////            numeros.ForEach(numero => Console.WriteLine(numeros));
            ///             El de arriba no me funciona

            //            foreach(int i in numeros)
            //            {
            //                Console.WriteLine(i);
            //            }

            // Ejercicio 3

            numeros.Insert(1, 15);
            //Utilidades.MostrarLista(numeros);

            // Ejercicio 4

            numeros.Remove(3);
            //Utilidades.MostrarLista(numeros);

            // Ejercicio 5
            for (int i = 0; i < numeros.Count - 1; i++)
            {
                if(numeros[i] == 15) { Console.Write($"Aparecio en la posicion {i+1}\n"); break; }
            }

            Console.WriteLine(numeros.Contains(43) ? "Se lo encontro" : "No se lo encontro");

            // Ejercicio 6

            Console.WriteLine($"{numeros.Sum()}");

            //Ejercicio 7

            Console.WriteLine($"{numeros.Max()}");

            // Ejercicio 98

            numeros.Sort();
            //Utilidades.MostrarLista(numeros);

            List<int> numerosInvertidos = new List<int>();
            for (int i = numeros.Count -1; i >= 0; i--)
            {
                numerosInvertidos.Add(numeros[i]);
            }
            //Utilidades.MostrarLista(numerosInvertidos);

            // Ejercicio 9

            numerosInvertidos.Reverse();
            //Utilidades.MostrarLista(numerosInvertidos);

            // Ejercicio 10

            numeros.ToArray();
            Console.WriteLine($"{numeros[15]}");

            numeros.ToList();
            Console.WriteLine($"{numeros[5]}");

            //Ejercicio 13

            Dictionary<int, int> frecuencuaNumero = new Dictionary<int, int>();

            int cant = 0;

            for (int i = 0; i < Limite; i++) {
                cant = numeros.Count(n => n == i);
                frecuencuaNumero.Add(i, cant);
            }

            foreach (var par in frecuencuaNumero) Esto es para mostrarlo por pantalla
            {
                Console.WriteLine($"El numero {par.Key} se repite {par.Value} veces");
            }

            /* Ejercicio 14 que no salio
            NumeroInfo[] listadoDeNumeros = new NumeroInfo[Limite];

            Dictionary<int, int> diccionarioNuevo = new Dictionary<int, int>();

            for (int i = 0; i < Limite; i++) {
                
                listadoDeNumeros[i].Frecuencia = numeros.Count();
                diccionarioNuevo.Add(listadoDeNumeros[i].Numero, listadoDeNumeros[i].Frecuencia);
            }
            foreach (var par in diccionarioNuevo)
            {
                Console.WriteLine($"El numero {par.Key} se repite {par.Value} veces");
            }*/

        }
    }
}
