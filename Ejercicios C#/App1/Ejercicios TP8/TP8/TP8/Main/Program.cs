using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class Program
    {
        static void Main(string[] args)
        {

            // Ejercicio 7

            List<ServicioViaje> servicioViajes = new List<ServicioViaje>();

            Vuelo Aerolineas_Arg_PP = new Vuelo("Aerolineas Argentina Primera Clase", ClaseVuelo.PrimeraClase, 0, "Aerolineas Argentinas Primera Clase", 250000);
            Vuelo Vuelo_Tirso = new Vuelo("FlyBondi", ClaseVuelo.Economica, 1, "FlyBondi", 10000);
            Alojamiento Renzo_Patagonia = new Alojamiento(2, "Apart Hotel RM", 150000, TipoAlojamiento.Apartamento, 2);
            Alojamiento Ramon_en_Miami = new Alojamiento(3, "HOTEL RAMIRO MESSI", 500000, TipoAlojamiento.Hotel, 2);

            servicioViajes.Add(Aerolineas_Arg_PP);
            servicioViajes.Add(Vuelo_Tirso);
            servicioViajes.Add(Renzo_Patagonia);
            servicioViajes.Add(Ramon_en_Miami);


            // Mostramos la lista

            foreach (ServicioViaje s in servicioViajes)
            {
                Console.WriteLine($"ID: {s.ID}");
                Console.WriteLine($"Nombre del viaje: {s.Nombre}");
                Console.WriteLine($"Precio del viaje: ${s.PrecioBase}");
                if(s is Alojamiento a)
                {
                    Console.WriteLine($"Tipo de Alojamiento: {a.GetTipoAlojamiento()}");
                }
                if(s is Vuelo v)
                {
                    Console.WriteLine($"Clase de Vuelo: {v.GetClaseVuelo()}");
                }
                Console.WriteLine($"Precio Total: ${s.CalcularPrecioTotal()}");
                Console.WriteLine("___________________________________________");
            }

            Aerolineas_Arg_PP.AgregarCalificacion(3);
            Vuelo_Tirso.AgregarCalificacion(8);
            Renzo_Patagonia.AgregarCalificacion(10);
            Ramon_en_Miami.AgregarCalificacion(10);
            Ramon_en_Miami.AgregarCalificacion(9);
            Ramon_en_Miami.AgregarCalificacion(8);
            Ramon_en_Miami.AgregarCalificacion(10);
            Ramon_en_Miami.AgregarCalificacion(9);
            Ramon_en_Miami.AgregarCalificacion(10);


            foreach (ServicioViaje obj in servicioViajes)
            {
                if(obj is ICalificable a)
                {
                    Console.WriteLine($"El promedio de {obj.Nombre} es de {a.ObtenerPromedioCalificaciones()} puntos");
                    Console.WriteLine("......................................");
                }
            }

            // Ejercicio 8

            Dictionary<string, List<ServicioViaje>> diccionario_1 = new Dictionary<string, List<ServicioViaje>>();

            List<ServicioViaje> vuelos = new List<ServicioViaje>();
            List<ServicioViaje> alojamientos = new List<ServicioViaje>();

            foreach (ServicioViaje service in servicioViajes)
            {
                if(service is Vuelo vuelo)
                {
                    vuelos.Add(vuelo);
                }
                if (service is Alojamiento alojamiento)
                {
                    alojamientos.Add(alojamiento);
                }
            }

            diccionario_1.Add("Vuelo", vuelos);
            diccionario_1.Add("Alojamiento", alojamientos);

            // Ejercicio 9

            foreach (Vuelo vuelo in vuelos)
            {
                Console.WriteLine(vuelo.ToString());
            }
            foreach (Alojamiento alojamiento in alojamientos)
            {
                Console.WriteLine(alojamiento.ToString());
            }

        }
    }
}
