using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class ItemPedido
    {
        public ProductoMenu Producto { get; private set; }
        public int Cantidad { get; set; }
        public ItemPedido(ProductoMenu productito, int cant) {
            Producto = productito;
            Cantidad = cant;
        }
        public void MostrarDatos()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Item:");
            Console.WriteLine($"Producto: {Producto.Nombre}");
            Console.WriteLine($"Unidades: {Cantidad}");
            Console.WriteLine($"Precio por unidad: {Producto.Precio}");
            Console.WriteLine($"Precio total: {Producto.Precio * Cantidad}");
            Console.WriteLine("-----------------------");
        }
    }
}
