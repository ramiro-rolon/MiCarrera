using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    // Interface de Ejercicio 9
    public interface IContenedor <T>
    {
        void Guardar(T item);
        T Obtener();
    }
}
