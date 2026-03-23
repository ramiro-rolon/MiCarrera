using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11
{
    // Ejercicio 4 Gestora
    public class GestoraFlota
    {
        public List<Vehiculo> VehiculoList; // La lista de Vehiculos, que se inicializa cuando creo la gestora en el Main
        public GestoraFlota()
        {
            VehiculoList = new List<Vehiculo>();
        }
        //Metodo AgregarVehiculo, desempaqueta los vehiculos que ya tiene en la lista y compara las patentes de cada uno
        //si ya hay un vehiculo con la misma patente printea un mensaje de error y devuelve falso, sino agrega el vehiculo a la lista
        //y devuelve verdadero
        public bool AgregarVehiculo(Vehiculo vehiculo)
        {
            foreach (var item in VehiculoList)
            {
                if (item.Patente == vehiculo.Patente)
                {
                    Console.WriteLine($"Ya hay un vehiculo con patente {item.Patente} en la lista");
                    return false;
                }
            }
            VehiculoList.Add(vehiculo);
            return true;
        }
        //Metodo que muestra los datos de todos los vehiculos en la lista
        public void ListarVehiculos()
        {
            foreach (var item in VehiculoList)
            {
                item.MostrarDatos();
            }
        }
        // Metodo de buscar por patente
        public Vehiculo BuscarPorPatente(string patente)
        {
            foreach (var item in VehiculoList)
            {
                if (item.Patente == patente)
                {
                    Console.WriteLine($"Vehiculo encontrado");
                    return item;
                }
            }
            return null;
        }
    }
}
