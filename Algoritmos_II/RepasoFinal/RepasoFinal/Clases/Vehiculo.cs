using RepasoFinal.Enumerados;
using RepasoFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoFinal.Clases
{
    internal abstract class Vehiculo : IMaintainable
    {
        private string licensePlate;
        private string brand;
        private string model;
        private double baseCost;
        private tipoCombustible fuelType;
        private EstadoVehiculo status;

        public Vehiculo(string licensePlate, string brand, string model, double baseCost, tipoCombustible fuelType, EstadoVehiculo status)
        {
            try
            {
                this.licensePlate = licensePlate;
                this.brand = brand;
                this.model = model;
                this.baseCost = baseCost;
                this.fuelType = fuelType;
                this.status = status;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al crear el vehículo: " + ex.Message);
            }
        }
        public string getLicensePlate()
        {
            return licensePlate;
        }
        public string getBrand()
        {
            return brand;
        }
        public string getModel()
        {
            return model;
        }
        public double getBaseCost()
        {
            return baseCost;
        }
        public tipoCombustible getFuelType()
        {
            return fuelType;
        }
        public EstadoVehiculo getStatus()
        {
            return status;
        }

        public abstract int getServiceIntervalKm();
        public abstract double calculateMaintenanceCost();
        public abstract string generateInspectionReport();


    }
}
