using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    // Ejercicio 1
    public abstract class ServicioViaje
    {
        public abstract int ID { get; set; }
        public abstract string Nombre { get; set; }
        public abstract decimal PrecioBase { get; set; }

        public abstract decimal CalcularPrecioTotal();
    }
}
