using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    // Clase Generica de la que se desprende todo
    class Caja<T>
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
            foreach (T item in list) {
                Console.WriteLine (item);
            }
        }

        // Ejercicio 4

        public static List<T> Filtrar(List<T> elementos, Func<T, bool> criterio)
        {
            return elementos.FindAll(x => criterio(x));
        }

        /* FILTRAR: 
         - es un metodo generico que puede trabajar con cualquier tipo de datos y
           nos devuelve una lista T (filtrada)
         - le pasamos 2 parametros: una lista generica y una funcion que recibe 
         un generico y devuelve bool
         - usamos el metodo de la lista y le pasamos el resultado de la ejecucion 
           de "criterio", con cada uno de los elementos de la lista

         - donde esta el codigo que indica que hace "criterio". Rta: en la llamada
           al metodo que hace uso de esta funcion anonima (criterio)
         */



        /* OTRA OPCION(mas sencilla):
         * public static List<T> Filtrar(List<T> elementos, Func<T, bool> criterio)
            {
            List<T> resultado = new List<T>();

            foreach (T elemento in elementos)
            {
                if (criterio(elemento)) 
                {
                    resultado.Add(elemento); 
                }
            }

            return resultado;
            }
         */

    

    }
}
