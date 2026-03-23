using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Interfaces
{ 
    // Ejercicio 4
    internal abstract class ProductoEnVenta : IVendible
    {
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public int inventario { get; set; }


        public void Vender(int cant)
        {
            if (this.inventario < cant) // Validacion de la cantidad
            {
                Console.WriteLine("ERROR: LA CANTIDAD INDICADA EXCEDE LA CANTIDAD DE UNIDADES DEL PRODUCTO");
            }
            else
            {
                Console.WriteLine($"Venta realizada con exito:\n - {this.nombre} - {cant} - ${this.precio * cant}");
                this.inventario--;
            }
        }

        public abstract void MostraInformacion();

        public override string ToString()
        {
            return $"Producto: {this.nombre}\nPrecio: ${this.precio}\nInventario: {this.inventario}\nDescripcion: {this.descripcion}\n"; 
        }

    }
}
