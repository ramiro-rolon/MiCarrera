using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    class Caja7<T> where T : IComparable
    {
        // Ejericio 1
        private T ITEM;
        public void Guardar(T item)
        {
            this.ITEM = item;
        }
        public T Obtener()
        {
            return this.ITEM;
        }

        // Ejercicio 2

        private List<T> list = new List<T>();

        public List<T> ObtenerLista()
        {
            return list;
        }
        public void GuardarItem(T item)
        {
            list.Add(item);
        }

        public void ObtenerItem()
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
        
        

        public T ObtenerMayor()
        {
            return ObtenerLista().Max();
        }
    }
}
