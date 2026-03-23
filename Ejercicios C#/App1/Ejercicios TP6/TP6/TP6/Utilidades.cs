using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP6
{
    internal class Utilidades
    {
        //Ejercicio 2 bis
        public static void MostrarLista<T>(List<T> lista)
        {
            foreach (var item in lista) 
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
