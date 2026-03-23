using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    class CajaEspecial <T> : Caja<T>
    {
        public bool Buscar(T item)
        {
   
            if (item == null) { return false;  }

            if (this.ObtenerLista().Contains(item)) {
                return true;
            }

            return false;
        }
    }
}
