using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TP_Interfaces
{
    // Ejercicio 1
    // Clase Base (Solo hereda de la interface)
    internal class Producto : IVendible
    {
        public string nombre {  get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public int inventario { get; set; }

        // Los atributos arriba tenian el set privado, y solo podian ser seteados con el constructor (Gracias Neu x la idea)
        // Pero debio ser modificado para los siguientes ejercicios

        public Producto(string nombre, decimal precio, string descripcion, int inventario)
        {
            if (nombre == null) { 
                this.nombre = nombre;
                while (this.nombre == null) { 
                    throw new ArgumentNullException("WACHIN PONELE NOMBRE AL PRODUCTO O SE RE PUDRE *suena cancion bostera*\n");
                    this.nombre = Console.ReadLine(); // Validacion ? dudas
                }
            }

            // Si la validacion esta bien, hay que seguir con las demas

            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.inventario = inventario;
        }
            
        // Ejercicio 3
        public void Vender(int cant) 
        {
            Console.WriteLine("ERROR: IMPOSIBLE VENDER PRODUCTO GENERICO, DEBE ACLARAR QUE PRODUCTO DESEA VENDER");
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Nombre del producto: {this.nombre}\nDescripcion: {this.descripcion}\nInventario: {this.inventario}\nPrecio: {this.precio}");
        }

        // VENDER DEL EJERCICIO 1:

        //public void Vender(int cant) 
        //{
        //    if (this.inventario < cant) // Validacion de la cantidad
        //    {
        //        Console.WriteLine("ERROR: LA CANTIDAD INDICADA EXCEDE LA CANTIDAD DE UNIDADES DEL PRODUCTO");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Venta realizada con exito:\n - {this.nombre} - {cant} - ${this.precio * cant}");
        //    }
        //}
    }
}
