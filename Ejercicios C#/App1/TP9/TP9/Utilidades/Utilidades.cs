using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    // Ejercicio 3
    static class Utilidades
    {
        public static void Intercambiar<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
    }
}
