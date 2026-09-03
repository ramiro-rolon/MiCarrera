using RepasoFinal.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoFinal.Clases
{
    internal class Camion : Vehiculo
    {
        private double capacityTons;
        private int axlesCount;
        public Camion(string licensePlate, string brand, string model, double baseCost, tipoCombustible fuelType, EstadoVehiculo status, double cargaMaxima, int ejes)
            : base(licensePlate, brand, model, baseCost, fuelType, status)
        {
            this.capacityTons = cargaMaxima;
            this.axlesCount = ejes;
        }
        public override double calculateMaintenanceCost()
        {
            // Implementación del cálculo del costo de mantenimiento para un camión
            return getBaseCost() + (250 * axlesCount) + (80 * capacityTons);
        }
        public override string generateInspectionReport()
        {
            // Implementación de la generación del informe de inspección para un camión
            return $"Informe de inspección del camión: Carga máxima: {capacityTons} kg, Ejes: {axlesCount}.";
        }

        public override int getServiceIntervalKm()
        {
            // Implementación del intervalo de servicio para un camión
            return 15000;
        }
    }
}
