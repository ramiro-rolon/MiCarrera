using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP7
{
    class Frutas
    {
        public string fruta;
        public string color;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1:

            Dictionary<string, string> Diccionario1 = new Dictionary<string, string>();

            // Ejercicio 4

            Diccionario1.Add("Manzana", "Roja");
            Diccionario1.Add("Banana", "Amarilla");
            Diccionario1.Add("Arandano", "Azul");
            Diccionario1.Add("Pera", "Verde");

            foreach(var par in Diccionario1)
            {
                Console.WriteLine($"El color de {par.Key} es: {par.Value}");
            }

            // Ejercicio 3

            Console.WriteLine($"Hay tomates en el diccionario?: {Diccionario1.ContainsKey("Tomate")}");

            foreach (var par in Diccionario1)
            {
                if (par.Value != "Naranja")
                {
                    Diccionario1.Add("Naranja", "Naranja");
                    break;
                }
            }

            // Ejercicio 5

            Diccionario1.Remove("Manzana");

            // Lo de abajo es para chequear que se hizo bien

            //foreach (var par in Diccionario1)
            //{
            //    Console.WriteLine($"El color de {par.Key} es: {par.Value}");
            //}

            // Ejercicio 6

            Diccionario1["Naranja"] = "Orange";

            foreach (var par in Diccionario1)
            {
                Console.WriteLine($"El color de {par.Key} es: {par.Value}");
            }

            //Ejercicio 7

            Console.WriteLine($"Cuantos elementos hay en mi diccionario? {Diccionario1.Count}");

            // Ejercicio 8

            List<Frutas> lista = new List<Frutas>();

            Frutas Banana = new Frutas();
            Banana.color = "Amarillo";
            Banana.fruta = "Banana";

            Frutas Sandia = new Frutas();
            Sandia.color = "Rojo";
            Sandia.fruta = "Sandia";

            lista.Add(Banana);
            lista.Add(Sandia);

            foreach (var fruta in lista)
            {
                if (!Diccionario1.ContainsKey(fruta.fruta))
                {
                    Diccionario1.Add(fruta.fruta, fruta.color);
                }
            }

            foreach (var par in Diccionario1)
            {
                Console.WriteLine($"{par.Key} : {par.Value}");
            }
        }
    }
}
