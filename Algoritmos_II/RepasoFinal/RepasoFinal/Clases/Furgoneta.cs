using RepasoFinal.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoFinal.Clases
{
    internal class Furgoneta :Vehiculo
    {
        private double volumenM3;
        private bool hasRefrigeration;
        public Furgoneta(string licensePlate, string brand, string model, double baseCost, tipoCombustible fuelType, EstadoVehiculo status, double volumenM3, bool hasRefrigeration)
            : base(licensePlate, brand, model, baseCost, fuelType, status)
        {
            this.volumenM3 = volumenM3;
            this.hasRefrigeration = hasRefrigeration;
        }
        public double getVolumenM3()
        {
            return volumenM3;
        }
        public bool getHasRefrigeration()
        {
            return hasRefrigeration;
        }
        public override double calculateMaintenanceCost()
        {
            // Implementación específica para calcular el costo de mantenimiento de la furgoneta
            return getBaseCost() + (hasRefrigeration ? 400 : 250);
        }
        public override int getServiceIntervalKm()
        {
            // Implementación específica para obtener el intervalo de servicio de la furgoneta
            return 10000;
        }
        public override string generateInspectionReport()
        {
            // Implementación específica para generar un informe de inspección de la furgoneta
            return $"Informe de inspección de la furgoneta {getLicensePlate()} - Volumen: {volumenM3} m3, Refrigeración: {hasRefrigeration}";
        }
    }
}
