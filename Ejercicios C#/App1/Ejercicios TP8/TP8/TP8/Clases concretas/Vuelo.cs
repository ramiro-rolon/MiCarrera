using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    // Ejercicio 6
    public class Vuelo : ServicioViaje, ICalificable
    {
        private string Aerolinea;
        private ClaseVuelo ClaseVuelo;
        private List<int> calificaciones;
        public override int ID { get; set; }
        public override string Nombre { get; set; }
        public override decimal PrecioBase { get ; set ; }
        public Vuelo(string aerolinea, ClaseVuelo claseVuelo, int iD, string nombre, decimal precioBase)
        {
            Aerolinea = aerolinea;
            ClaseVuelo = claseVuelo;
            ID = iD;
            Nombre = nombre;
            PrecioBase = precioBase;
            calificaciones = new List<int>();
        }
        public override decimal CalcularPrecioTotal()
        {
            if (this.ClaseVuelo == ClaseVuelo.Economica)
            {
                return this.PrecioBase;
            }
            else if (this.ClaseVuelo == ClaseVuelo.Ejecutiva)
            { 
                return this.PrecioBase * 1.2m;
            }
            else
            {
                return this.PrecioBase * 1.4m;
            }
        }

        public void AgregarCalificacion(int cal)
        {
            calificaciones.Add(cal);
        }

        public double ObtenerPromedioCalificaciones()
        {
            double acumulador = 0;
            foreach (int i in calificaciones)
            {
                acumulador += i;
            }

            if (acumulador == 0 || calificaciones.Count == 0) { return 0; }

            return acumulador / calificaciones.Count();
        }

        public string GetAerolinea()
        {
            return this.Aerolinea;
        }

        public ClaseVuelo GetClaseVuelo()
        {
            return this.ClaseVuelo;
        }

        //Ejercicio 9 Redefinicion del ToString
        public override string ToString()
        {
            return $"Nombre: {this.Nombre}\nTipo: {this.GetType()}\nID: {this.ID}\nClase de Vuelo: {this.ClaseVuelo}\nPrecio Base: ${this.PrecioBase}\nPrecio Total: ${this.CalcularPrecioTotal()}\nPromedio de Calificaciones: {this.ObtenerPromedioCalificaciones()}\n..................................................................";
        }

    }
}
