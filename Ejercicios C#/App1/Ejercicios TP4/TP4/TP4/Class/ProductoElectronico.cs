using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal class ProductoElectronico : Producto
    {
        public int GarantiaMeses { get; set; }

        // Vuelvo a reescribir el ToString para esta clase particular.

        public override string ToString()
        {
            return $"Nombre del Producto: {this.Nombre}\nPrecio: ${this.Precio}\nCantidad: {this.Cantidad}\nMeses de garantia: {this.GarantiaMeses}"; // Llamo al ToString de la clase padre (producto) y le agrego
        }                                                                         // lo particular de esta clase
        public ProductoElectronico(string nombre, decimal precio, int cantidad, int garantia) : base(nombre, precio, cantidad)
        {
            this.GarantiaMeses = garantia;
        }                                                          
    }
}
