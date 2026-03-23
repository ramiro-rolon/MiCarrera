using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    // Ejercicio 2
    public interface ICalificable
    {
        void AgregarCalificacion(int calificacion);
        double ObtenerPromedioCalificaciones();
    }
}
