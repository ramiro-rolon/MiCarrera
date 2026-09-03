using RepasoFinal.Clases;
using RepasoFinal.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace RepasoFinal.Gestora
{
    internal class GestorFlora
    {
        public List<Vehiculo> vehiculos;

        public GestorFlora()
        {
            vehiculos = new List<Vehiculo>();
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            foreach (var v in vehiculos)
            {
                if (v.getLicensePlate() == vehiculo.getLicensePlate())
                {
                    throw new ArgumentException("Ya existe un vehículo con la misma patente.");
                }
            }
            vehiculos.Add(vehiculo);
        }

        public void EliminarVehiculo(string licensePlate)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.getLicensePlate() == licensePlate);
            if (vehiculo != null)
            {
                vehiculos.Remove(vehiculo);
            }
            else
            {
                throw new ArgumentException("No se encontró un vehículo con la patente especificada.");
            }
        }

        public Vehiculo BuscarVehiculo(string licensePlate)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.getLicensePlate() == licensePlate);
            if (vehiculo != null)
            {
                return vehiculo;
            }
            else
            {
                throw new ArgumentException("No se encontró un vehículo con la patente especificada.");
            }
        }

        public List<Vehiculo> ListarVehiculos()
        {
            return vehiculos;
        }

        public List<Vehiculo> ListarVehiculosPorEstado(EstadoVehiculo estado)
        {
            List<Vehiculo> vehiculosFiltrados = new List<Vehiculo>();
            foreach (var v in vehiculos)
            {
                if (v.getStatus() == estado)
                {
                    vehiculosFiltrados.Add(v);
                }
            }
            return vehiculosFiltrados;
        }

        public void serializeToJSON(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(vehiculos);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al serializar la flota a JSON: " + ex.Message);
            }
        }
        public void deserializeFromJSON(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("El archivo JSON no existe.");
                }
                string json = File.ReadAllText(filePath);
                vehiculos = JsonSerializer.Deserialize<List<Vehiculo>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al deserializar la flota desde JSON: " + ex.Message);
            }
        }
    }
}
