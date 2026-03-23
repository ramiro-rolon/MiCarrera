using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class ProductoMenu
    {
        public int IdProducto { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; } = true;
        public ProductoMenu(int idProducto, string nombre, string descripcion, decimal precio)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
        private string Estado() {
            if (Disponible) { return "Disponible"; }
            return "No disponible";
        }
        public void MostrarDatos()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Datos del producto");
            Console.WriteLine($"Id: {IdProducto}");
            Console.WriteLine($"Producto: {Nombre}");
            Console.WriteLine($"Descripcion: {Descripcion}");
            Console.WriteLine($"Precio: ${Precio}");
            Console.WriteLine($"Estado: {Estado()}");
            Console.WriteLine("-----------------------");
        }
    }
}
