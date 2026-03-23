using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            /*
            Caja<string> nombre = new Caja<string>();
            nombre.Guardar("Ramiro");
            Console.WriteLine(nombre.ObtenerItem());

            Caja<int> edad = new Caja<int>();
            edad.Guardar(24);
            Console.WriteLine($"Edad: {edad.ObtenerItem()}");*/

            // Ejercicio 2
            /*
            Caja<string> nombres = new Caja<string>();

            nombres.GuardarItem("Rama");
            nombres.GuardarItem("Kevo");
            nombres.GuardarItem("Nico");
            nombres.GuardarItem("Renzo");
            nombres.GuardarItem("NEHUENCHADDOMADORDEGIRLS");
            nombres.GuardarItem("Tirso");

            Console.WriteLine("Los pibardos:");
            nombres.ObtenerItem();

            Caja<int> edades = new Caja<int>();
            edades.GuardarItem(24);
            edades.GuardarItem(29);
            edades.GuardarItem(29);
            edades.GuardarItem(24);
            edades.GuardarItem(20);
            edades.GuardarItem(20);

            Console.WriteLine("Edades de los pibardos:");

            edades.ObtenerItem();*/

            // Ejercicio 3

            Caja<int> numero = new Caja<int>();
            numero.Guardar(5);
            numero.GuardarItem(54);
            numero.GuardarItem(6);
            numero.GuardarItem(15);
            numero.GuardarItem(13);
            numero.GuardarItem(27);
            numero.GuardarItem(10);

            int numero_5 = numero.Obtener();
            int numero_5_mas_1 = numero.Obtener() + 1;

            Utilidades.Intercambiar(ref numero_5, ref numero_5_mas_1);

            Console.WriteLine(numero_5);
            Console.WriteLine(numero_5_mas_1);

            List<int> numerosFiltrados = Caja<int>.Filtrar(numero.ObtenerLista(), x4 => x4 > 10);
            // aqui se define que hace la funcion "criterio" que usa el metodo Filtrar

            foreach (int elemento in numerosFiltrados) {
                Console.WriteLine(elemento);
            }

            // Ejercicio 5

            CajaEspecial<int> Caja5 = new CajaEspecial<int>();
            Caja5.Guardar(7);
            Caja5.GuardarItem(8);
            Caja5.GuardarItem(10);
            Caja5.GuardarItem(2);
            Caja5.GuardarItem(7);

            Console.WriteLine($"Tiene el numero 2? {Caja5.Buscar(8)}");

            // Ejercicio 6

            Producto producto1 = new Producto("Tirso", 1400000);
            Producto producto2 = new Producto("Cepillo", 3500);
            Producto producto3 = new Producto("Guante", 5000);
            Producto producto4 = new Producto("Aire del futuro", 10);

            Caja<Producto> caja6 = new Caja<Producto>();
            caja6.GuardarItem(producto1);
            caja6.GuardarItem(producto2);
            caja6.GuardarItem(producto3);
            caja6.GuardarItem(producto4);

            foreach (Producto p in caja6.ObtenerLista()) {
                Console.WriteLine($"Nombre del producto: {p.Nombre} Precio ${p.Precio}");
            }

            // Ejercicip 7

            Caja7<int> caja7 = new Caja7<int>();
            caja7.GuardarItem(31);
            caja7.GuardarItem(56);
            caja7.GuardarItem(26);
            caja7.GuardarItem(36);

            Console.WriteLine($"El mayor de la lista es {caja7.ObtenerMayor()}");

            Caja7<string> caja7_2 = new Caja7<string>();
            caja7_2.GuardarItem("Rama");
            caja7_2.GuardarItem("Rolon");
            caja7_2.GuardarItem("Thomas");
            caja7_2.GuardarItem("Castelluccio");

            Console.WriteLine($"El mayor de la lista es {caja7_2.ObtenerMayor()}");

            // Ejercicio 8

            Herramienta martillo = new Herramienta("Herramienta", 35000, "Hammer");
            Herramienta destornillador = new Herramienta("Destornillador", 25000, "Phillips");
            Herramienta tirso = new Herramienta("Tirso", 1400000, "Talbot Wrigth");

            Inventario<Herramienta> inventario = new Inventario<Herramienta>();
            inventario.GuardarItem(martillo);
            inventario.GuardarItem(destornillador);
            inventario.GuardarItem(tirso);

            foreach(Herramienta herramienta in inventario.ObtenerLista()){
                herramienta.MostrarInformacion();
            }

            // Ejercicio 9

            Caja9<int> caja9_1 = new Caja9<int>();
            caja9_1.Guardar(8);
            Caja9<string> caja9_2 = new Caja9<string>();
            caja9_2.Guardar("OCHO");

            Console.WriteLine($"{caja9_1.Obtener()}");
            Console.WriteLine($"{caja9_2.Obtener()}");

        }
    }
}
