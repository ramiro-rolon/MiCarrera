using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11
{
    // Ejercicio 1 Clase Abstracta Vehiculo
    public abstract class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; private set; }
        public Vehiculo(string marca, string modelo, string patente) {
            Marca = marca;
            Modelo = modelo;
            Patente = patente;
        }
        public abstract void MostrarDatos();
    }
}
