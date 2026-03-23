using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal class ProductoAlimenticio : Producto
    {
        public DateTime FechaVencimiento { get; set; }

        public override string ToString()
        {
            return $"Nombre del Producto: {this.Nombre}\nPrecio: ${this.Precio}\nCantidad: {this.Cantidad}\nFecha de Vencimiento: {this.FechaVencimiento}";
        }
        public ProductoAlimenticio(string nombre, decimal precio, int cantidad, DateTime fechavencimiento) : base (nombre, precio, cantidad) 
        {
            this.FechaVencimiento = fechavencimiento;
        }
    }
}
