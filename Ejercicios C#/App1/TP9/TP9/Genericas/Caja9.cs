using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    // Ejercicio 9
    public class Caja9<T> : IContenedor<T>
    {
        protected T Item ;
        public void Guardar(T item)
        { 
            this.Item = item;
        }
        public T Obtener()
        {
            return this.Item;
        }
    }
}
