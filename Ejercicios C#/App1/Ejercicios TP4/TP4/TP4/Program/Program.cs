using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producto[] inventario = new Producto[3];
            {
                inventario[0] = new Producto("Mesa", 25000, 4);
                inventario[1] = new ProductoAlimenticio("Arroz", 26000, 5, DateTime.Now.AddDays(15));
                inventario[2] = new ProductoElectronico("Computadora", 1500000, 5, 12);
            }

            Console.WriteLine($"{inventario[0].ToString()}");
            Console.WriteLine($"{inventario[1].ToString()}");
            Console.WriteLine($"{inventario[2].ToString()}");

            // Ejercicio 3
            // Prueba del metodo Equals

            Console.WriteLine("\n \n Prueba del Equals:\n");
            Producto productoPrueba = new Producto("Arroz", 26000, 1);
            bool resultadoPrueba = productoPrueba.Equals(inventario[1]);

            Console.WriteLine($"¿El productoPrueba es igual al inventario[1]?\n {resultadoPrueba}");

            // Segunda prueba

            Console.WriteLine("\n\nSegunda prueba");
            resultadoPrueba = inventario[0].Equals(inventario[2]);
            Console.WriteLine($"\nResultado de la segunda prueba: {resultadoPrueba}");

            // Usamos el BuscarPorNombre a ver si funciona

            Console.WriteLine("\n\n Prueba del BuscarPorNombre");

            var productoBuscado = Utilidades.BuscarXNombre(inventario, "Arroz");
            Console.WriteLine($"El producto buscado es: {productoBuscado}");

            // Prueba del Calcular Valor Total

            var valorTotal = Utilidades.CalcularValorInventario(inventario);
            Console.WriteLine($"El valor total del inventario es : {valorTotal}");

            // Prueba del contador Cantidad de productos (Ejercicio 5)

            Console.WriteLine(Producto.MostrarCantidad());
        }
    }
}
