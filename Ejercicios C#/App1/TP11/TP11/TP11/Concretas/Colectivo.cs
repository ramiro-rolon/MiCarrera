using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11
{
    /* Ejercicio 2, clase Colectivo hija de Vehiculo
    public class Colectivo : Vehiculo
    {
        private double CantidadPasajeros { get; set; }
        public Colectivo(double cantidadpasajeros, string marca, string modelo, string patente) : base(marca, modelo, patente)
        {
            CantidadPasajeros = cantidadpasajeros;
        }
        // Metodo que hereda la clase de Vehiculo:
        public override void MostrarDatos()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Datos del Colectivo");
            Console.WriteLine($"Marca: {Marca}\nModelo: {Modelo}\nPatente: {Patente}Cantidad de pasajeros: {CantidadPasajeros}");
            Console.WriteLine("------------------");
        }

    }*/
    // Ejercicio 3, ahora la clase firma el contrato con la interfaz IMantenible y tiene que 
    // implementar los dos metodos
    public class Colectivo : Vehiculo, IMantenible
    {
        private double CantidadPasajeros { get; set; }
        public Colectivo(double cantidadpasajeros, string marca, string modelo, string patente) : base(marca, modelo, patente)
        {
            CantidadPasajeros = cantidadpasajeros;
        }
        // Metodo que hereda la clase de Vehiculo:
        public override void MostrarDatos()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Datos del Colectivo");
            Console.WriteLine($"Marca: {Marca}\nModelo: {Modelo}\nPatente: {Patente}Cantidad de pasajeros: {CantidadPasajeros}");
            Console.WriteLine("------------------");
        }
        // Genero un booleano que si esta en falso (predeterminado) es porque no necesita mantenimiento

        public bool EstadoMantenimiento = false;

        //Genero un metodo para cambiar el booleano, le otorgo el poder de cambiarlo al usuario
        public void CambiarEstadoMantenimiento()
        {
            Console.WriteLine($"Ha declarado al colectivo con patente {Patente} en la lista de espera de mantenimiento.");
            EstadoMantenimiento = true;
        }

        // Metodos de la interfaz:

        public bool RequiereMantenimiento()
        {
            return EstadoMantenimiento;
        }
        public void RealizarMantenimiento()
        {
            // Validacion, si requiere mantenimiento se realiza el mismo cambiando el EstadoMantenimiento
            if (RequiereMantenimiento() == true)
            {
                Console.WriteLine($"Se está realizando el mantenimiento del colectivo con patente {Patente}");
                Console.WriteLine($"...");
                EstadoMantenimiento = false;
                Console.WriteLine("Mantenimiento realizado con exito");
            }
            else
            {
                Console.WriteLine($"El colectivo con patente {Patente} no requiere de mantenimiento");
            }
        }
    }
}
