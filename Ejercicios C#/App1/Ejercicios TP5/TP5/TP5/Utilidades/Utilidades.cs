using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    internal class UtilidadesBiblioteca
    {
        // Ejercicio 2
        // Usamos el Equals ya sobreescrito para la clase MaterialBibliografico para hacer la comparacion
        // entre los objetos que tenemos y lo que le pasamos por parametro
        public static MaterialBibliografico BuscarXISBN(MaterialBibliografico[] objeto, string ISBN)
        {
            foreach (var obj in objeto)
            {
                if (obj.ISBN.Equals(ISBN, StringComparison.OrdinalIgnoreCase))
                {
                    return obj;
                }
            }
            return null;
        }
        // Metodo para calcular el valor total del inventario

        public static decimal CalcularValorTotalInventario(MaterialBibliografico[] inventario)
        {
            decimal valorTotal = 0;
            foreach (var obj in inventario) 
            {
                valorTotal += obj.Precio;
            }
            return valorTotal;
        }

        // Metodo para filtrar por autor
        public static MaterialBibliografico[] FiltrarPorAutor(MaterialBibliografico[] inventario, string autor ) //Paso el array con el que estoy trabajando y el nombre
        {                                                                                                        //del autor
            int i = 0; // Contador
            foreach (var obj in inventario) 
            {
                if (obj.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
                {
                    i++; // En el primer foreach cuento las veces que aparece el autor buscado en el array, definiendo el tamaño del array que voy a devolver
                }
            }
            MaterialBibliografico[] respuesta = new MaterialBibliografico[i]; // Genero el array que voy a devolver con la cantidad de veces que aparece el autor
            i = 0; // reinicio el contador
            foreach (var obj in inventario)
            {
                if (obj.Autor.Equals(autor))
                {
                    respuesta[i] = obj; // Vuelvo a hacer la comparacion, esta vez con el array ya hecho y cada vez que encuentre un objeto que coincide el autor
                    i++;                // lo guarde dentro del array
                }
            }
            return respuesta; //Una vez terminado, devuelvo el array completo
        }
    }
}
