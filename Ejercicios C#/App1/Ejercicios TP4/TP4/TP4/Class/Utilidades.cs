using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal static class Utilidades
    {
        // Aca el buscar por nombre, lo defino como Producto porque es lo que me va a devolver. NO PORQUE SEA UNA CLASE PRODUCTO LA QUE LLAME AL METODO
        public static Producto BuscarXNombre(Producto[] productos, string nombre) // Le paso el array de productos con el que este trabajando y un string del nombre que quiero
                                                                                  // buscar.
        {
            foreach (Producto p in productos) //Meto a los productos en "p"
            {
                if (p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)) // Uso el Equals que ya esta sobreescrito para los productos, y le digo si el
                {                                                                // Nombre de p es igual al nombre que te pase por parametro
                    return p;                                                    // <= Devolve p
                }
            }
            return null; // Si no, no devuelvas nada
        }
        // Aca el Calcular valor del inventario
        public static decimal CalcularValorInventario(Producto [] productos) // le paso un array de objetos de la clase Producto
        {
            decimal valor = 0; // Acumulador
            foreach (Producto p in productos) // aca meto el array en "p"
            {
                valor += p.Precio; //Aca voy acumulando los precios de cada producto
            }
            return valor; // Y cuando finaliza el foreach que me devuelva el acumulador
        }
    }
}
