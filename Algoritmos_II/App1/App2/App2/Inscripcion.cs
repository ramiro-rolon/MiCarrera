using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Inscripcion
    {
        public string Nombre { get; set; }
        public int Edad { get ; set; }
        public string Taller { get; set; }
        public string Turno { get; set; }
        public Inscripcion(string nombre , int edad, string taller, string turno)
        {
            Nombre = nombre;
            Edad = edad;
            Taller = taller;
            Turno = turno;
        }
        public string Datos()
        {
            return $"{Nombre} - ({Edad}) - {Taller} - {Turno}";
        }
    }
}
