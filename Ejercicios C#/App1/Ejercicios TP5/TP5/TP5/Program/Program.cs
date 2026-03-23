using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 3
            MaterialBibliografico[] biblioteca = new MaterialBibliografico[4];
            biblioteca[0] = new Libro("La vida de Messi", "CR7", "2011502410", 26000, 300);
            biblioteca[1] = new Revista("ParaTi", "Messi", "15002410325", 10000, 3, 5);
            biblioteca[2] = new MaterialBibliografico("LA BIBLIA DE NICO", "nico", "1", 12);
            biblioteca[3] = new Libro("Campeon del Mundo", "Messi", "2501320225", 100000, 300);

            Console.WriteLine(biblioteca[0].ToString());
            Console.WriteLine(biblioteca[1].ToString());
            Console.WriteLine(biblioteca[2].ToString());

            // Prueba del Equals

            MaterialBibliografico pruebaEquals = new Libro("La vida de CR7", "Messi", "2011502410", 26000, 300);

            int i = 0;

            foreach (MaterialBibliografico b in biblioteca) 
            {
                if (pruebaEquals.ISBN.Equals(biblioteca[i].ISBN, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"pruebaEquals es igual al objeto biblioteca[{i}]");
                    i++;
                }
            }
            // Segunda prueba
            if (biblioteca[0].ISBN.Equals(biblioteca[1].ISBN, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("son iguales");
            }
            else
            {
                Console.WriteLine("Son distintos");
            }

            // Prueba del BuscarXISBN

            i = 0; // reinicio contador
            foreach (var obj in biblioteca)
            {
                if(obj == UtilidadesBiblioteca.BuscarXISBN(biblioteca, "2011502410")) // Busco el objeto
                {
                    Console.WriteLine("El objeto se a encontrado"); // si lo encuentra me devuelve que esta y me lo trae
                    Console.WriteLine(obj.ToString());
                }
                else
                {
                    i++; // si no lo encuentra el contador va sumando uno
                }
            }
            if (i == biblioteca.Length) // si el contador equivale a la cantidad de objetos de mi array es porque 
            {                           // el objeto que busque no esta en el array
                Console.WriteLine("No se encontro el objeto");
            }
            i = 0;

            // Prueba del Calcular Valor

            Console.WriteLine($"El valor total del inventario es: ${UtilidadesBiblioteca.CalcularValorTotalInventario(biblioteca)}");

            // Prueba Filtrar por autor

            MaterialBibliografico[] filtrado = UtilidadesBiblioteca.FiltrarPorAutor(biblioteca, "Messi");

            Console.WriteLine("\nPRUEBA DEL FILTRAR POR AUTOR \n\n");
            if (filtrado.Length != 0)
            {
                foreach (var obj in filtrado)
                {
                    Console.WriteLine(obj.ToString());
                }
            }
            else { Console.WriteLine("No se encontro el objeto de tal autor"); }

            // Ejercicio 4
            // Prueba del ArgumentException

            Console.WriteLine("PRUEBA DEL TRY CATCH\n");

            MaterialBibliografico pruebaAE = new MaterialBibliografico("GOT", "Jorge", "3", 10);
            try
            {
                pruebaAE.Precio = -1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Ejercicio 5

            Console.WriteLine("\nPrueba del metodo para retornar la cantidad\n");
            Console.WriteLine($"Cantidad total de materiales bibliograficos creados hasta el momento: {MaterialBibliografico.ObtenerCantidadTotalMateriales()}");
        }
    }
}
