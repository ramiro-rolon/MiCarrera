using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    // Ejercicio 4
    class Alojamiento : ServicioViaje, ICalificable
    {
        public override int ID { get; set; }
        public override string Nombre { get; set; }
        public override decimal PrecioBase {  get; set; }
        private TipoAlojamiento TipoAlojamiento;
        private int CantidadHuespedes;
        private List<int> calificaciones;
        public Alojamiento(int id, string nombre, decimal PrecioBase, TipoAlojamiento tipoAlojamiento, int cantidadHuespedes)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.PrecioBase = PrecioBase;
            this.TipoAlojamiento = tipoAlojamiento;
            this.CantidadHuespedes = cantidadHuespedes;
            calificaciones = new List<int>();
        }
        public override decimal CalcularPrecioTotal()
        {
            return (decimal)this.PrecioBase + 0.10m * CantidadHuespedes * this.PrecioBase ; 
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

            return acumulador/calificaciones.Count;
        }

        public int GetCantHuespedes()
        {
            return this.CantidadHuespedes;
        }

        public TipoAlojamiento GetTipoAlojamiento() 
        {
            return this.TipoAlojamiento;
        }

        // Ejercicio 9 Redefinicion del ToString
        public override string ToString()
        {
            return $"Nombre: {this.Nombre}\nTipo: {this.GetType()}\nID: {this.ID}\nClase de Vuelo: {this.TipoAlojamiento}\nPrecio Base: ${this.PrecioBase}\nPrecio Total: ${this.CalcularPrecioTotal()}\nPromedio de Calificaciones: {this.ObtenerPromedioCalificaciones()}\n..................................................................";
        }
    }
}
