using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP8;

namespace Ejercicios_enum
{
    public enum TipoDocumento { PDF, TXT, DOCX }
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 6

            DocumentoTXT doc1 = new DocumentoTXT("Documento A");

            Console.WriteLine(doc1.ObtenerInformacion());

            DocumentoPDF doc2 = new DocumentoPDF("Documento B");

            Console.WriteLine(doc2.ObtenerInformacion());

            DocumentoDOCX doc3 = new DocumentoDOCX("Documento C");

            Console.WriteLine(doc3.ObtenerInformacion());
        }
    }
}
