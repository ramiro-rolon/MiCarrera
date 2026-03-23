using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    internal class Revista : MaterialBibliografico
    {
        public int NumeroVolumen { get; set; }
        public int NumeroEdicion { get; set; }

        public override string ToString() //Reescritura del ToString que ya habia reescrito en la clase base
        {
            return base.ToString() + $"\nVolumen: {NumeroVolumen}\nEdicion: {NumeroEdicion}"; // Llamo al ToString de la clase base y le agrego lo particular de la hija
        }

        public Revista(string titulo, string autor, string isbn, decimal precio, int volumen, int edicion) : base(titulo, autor, isbn, precio)
        {
            NumeroEdicion = edicion;
            NumeroVolumen = volumen;
        }
    }
}
