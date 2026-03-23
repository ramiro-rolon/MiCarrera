using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal class Producto
    {
        // Propiedades de producto
        private decimal precio;
        public string Nombre { get; set; }
        public decimal Precio
        {
            get => precio;
            set {
                if (value < 0)
                {
                    Console.WriteLine("ERROR: El valor del precio no puede ser negativo"); // Controlo que el precio que le asignen a mi producto no sea negativo
                }
                else
                    precio = value;
            }
        }
        public int Cantidad { get; set; }
        public static int contador = 0;
        public virtual decimal CalcularValorTotal()
        {
            return Precio * Cantidad;
        }

        // Redefinicion del Equals, le paso un OBJETO como parametro
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            // Aca comparo el objeto que le paso, si es de la clase que usa el metodo
            // pasa a hacer el RETURN: devuelve un verdadero o falso dependiendo de la comparacion.
            if (obj is Producto unObjeto)
            {
                return (this.Nombre == unObjeto.Nombre && this.Precio == unObjeto.Precio);
            }

            return false;
        }

        // Aca reescribo el ToString

        public override string ToString()
        {
            return $"Nombre del Producto: {this.Nombre}\nPrecio: ${this.Precio}\nCantidad: {this.Cantidad}";
        }

        public Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;

            contador += 1;
        }

        public static int MostrarCantidad()
        {
            return contador;
        }
    }
}
