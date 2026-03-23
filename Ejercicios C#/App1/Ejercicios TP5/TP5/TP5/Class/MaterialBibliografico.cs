using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP5
{                   // Ejercicio 1
    internal class MaterialBibliografico
    {
        // Propiedades Automáticas
        public string Titulo {  get; set; }
        public string Autor  { get; set; } 
        public string ISBN { get; set; }
        private decimal precio;
        public decimal Precio 
            {
                get => precio; 
                set {
                if (value <= 0)
                {
                    throw new ArgumentException("El precio no puede ser menor a 0 loquito");
                }
                else
                {
                    precio = value;
                }
                } 
            }

        public static int cantidad = 0;

        public decimal CalcularPrecioDeVenta()
        {
            return (decimal)this.Precio * 1.25m;
        }

        public override bool Equals(object obj) //Sobreescritura del metodo Equals
        {
            if(obj == null) return false;

            if (obj is MaterialBibliografico o)
            {
                return (o.ISBN == ISBN);
            }

            return false;
        }

        public override string ToString()
        {
            return $"Titulo del Libro: {Titulo}\nAutor: {Autor}\nISBN: {ISBN}";
        }

        public MaterialBibliografico(string titulo, string autor, string isbn, decimal precio) 
        {
            this.Titulo = titulo ;
            this.Autor = autor ;
            this.ISBN = isbn ;
            this.Precio = precio ;

            // Ejercicio 5

            cantidad++;
        }

        // Metodo para llamar a la cantidad

        public static int ObtenerCantidadTotalMateriales()
        {
            return cantidad;
        }
    }
}
