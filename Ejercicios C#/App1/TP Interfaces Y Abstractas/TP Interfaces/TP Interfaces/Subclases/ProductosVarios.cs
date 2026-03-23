using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Interfaces
{
    // Generamos clases de productos que hereden de la interfaz o de la clase abstracta
    // Primero uno que herede de Producto (que ya de por si utiliza la interfaz IVendible)
    internal class ProductosElectronicos : Producto
    {
        public string Tipo {  get; private set; } 
        public ProductosElectronicos(string nombre, decimal precio, string descripcion, int inventario, string tipo) : base(nombre, precio, descripcion, inventario)
        {
            this.Tipo = tipo;
        }

        public void Vender(int cant)
        {
            if (this.inventario < cant) // Validacion de la cantidad
            {
                Console.WriteLine("ERROR: LA CANTIDAD INDICADA EXCEDE LA CANTIDAD DE UNIDADES DEL PRODUCTO");
            }
            else
            {
                Console.WriteLine($"Venta realizada con exito:\n- {this.nombre} - {cant} - ${this.precio * cant}");
                this.inventario--;
            }
        }
    }

    // Clase que herede de la clase abstracta:

    internal class Libro : ProductoEnVenta
    {
        public string ISBN { get; private set; }
        public Libro(string nombre, decimal precio, string descripcion, int inventario, string isbn)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.inventario = inventario;
            this.ISBN = isbn;
        }

        public override void MostraInformacion()
        {
            Console.WriteLine($"{this.ToString()}ISBN: {this.ISBN}");
        }
    }
}
