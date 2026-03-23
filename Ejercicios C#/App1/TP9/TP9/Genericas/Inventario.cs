using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    // Clase del Ejercicio 8
    public class Inventario <T>
    {
        private T ITEM;
        public void Guardar(T item)
        {
            this.ITEM = item;
        }
        public T Obtener()
        {
            return this.ITEM;
        }
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
    }
}
