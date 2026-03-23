using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    internal class Libro : MaterialBibliografico
    {
        public int NumeroPaginas { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nNumero de Paginas: {NumeroPaginas}";
        }
        public Libro(string titulo, string autor, string isbn, decimal precio, int paginas) : base (titulo, autor, isbn, precio) 
        {
            NumeroPaginas = paginas ;
        }
    }
}
