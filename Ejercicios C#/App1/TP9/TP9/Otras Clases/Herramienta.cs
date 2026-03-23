using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    public class Herramienta : Item
    {
        private float precio;
        private string marca; 
        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {this.Nombre}\nPrecio: ${this.precio}\nMarca: {this.marca}");
        }
        public Herramienta(string nombre, float precio, string marca)
        {
            Nombre = nombre;
            this.precio = precio;
            this.marca = marca;
        }
    }
}
