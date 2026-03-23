using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class Cliente
    {
        public int IdCliente { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Cliente(int id, string nombre, string apellido) {
            IdCliente = id;
            Nombre = nombre;
            Apellido = apellido;
        }
    }
}
