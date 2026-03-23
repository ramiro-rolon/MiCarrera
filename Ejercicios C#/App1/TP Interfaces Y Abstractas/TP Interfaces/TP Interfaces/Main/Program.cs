using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Interfaces
{
    internal class Program
    {
        // Pruebas
        static void Main(string[] args)
        {
            // Probamos la herencia de la clase Productos Electronicos de la clase base Producto
            // que a su vez utiliza la interfaz IVendible

            ProductosElectronicos CELULARES = new ProductosElectronicos("CELULAR MOTOROLA", 500000, "CELULAR MOTOROLA 100 VECES MEJOR QUE EL DE NICOLAS", 3, "CELULAR");

            CELULARES.MostrarInformacion();
            CELULARES.Vender(2);
            CELULARES.Vender(3);

            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            // Prueba de Libros, que hereda de la clase abstracta (tambien usa la interfaz)

            Libro libro1 = new Libro("Juego de Tronos", 37000, "El mejor libro del mundo", 2, "2011256301");

            libro1.Vender(1);
            libro1.MostraInformacion();
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            libro1.Vender(2);

        }
    }
}
