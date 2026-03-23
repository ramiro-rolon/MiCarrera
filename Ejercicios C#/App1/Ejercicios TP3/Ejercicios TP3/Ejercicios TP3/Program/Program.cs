using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Ejercicios_TP3
{
    public class Empleado
    {
        // Propiedades
        private decimal sueldo;
        public string Nombre { get; set; }
        public int Edad
        {
            get;
            set;
        }

        public decimal Sueldo{
            get => sueldo;
            set
            {
                if(value > 200000)
                {
                    this.sueldo = value;
                }
                else
                {
                    Console.WriteLine("???");
                }
            }
        } 

        // Ejercicio 4 Variables  
        public static int contador = 0;
        public static decimal TotalSueldos = 0;

        //Constructor base
        public Empleado (string nombre, int edad, decimal sueldo)
        {
            this.Sueldo = sueldo;
            this.Nombre = nombre;
            this.Edad = edad;

            contador++;
            TotalSueldos += (decimal)this.Sueldo;
        }

        // Metodo para sacar el promedio de los sueldos
        public static decimal PromedioSueldos()
        {
            if (contador > 0)
                return TotalSueldos/(decimal)contador;
            else
                return 0;
        }

        // Ejercicio 5
        public static int EdadXFecha(DateTime fecha)
        {
            if (fecha == null) 
            { 
                return 0;
            }
            else
            {
                DateTime hoy = DateTime.Today;
                return hoy.Year - fecha.Year;
            }
        }
    }

    // Clase que heredan
    public class Tecnico : Empleado
    {
        public string Especialidad { get; set; }

        //Constructor Subclase
        public Tecnico (string nombre, int edad, decimal sueldo, string especialidad) : base (nombre, edad, sueldo)
        {
            this.Especialidad = especialidad;
        }
    }

    public class Administrativo : Empleado
    {
        public string Sector {  get; set; }

        //Constructor Subclase
        public Administrativo(string nombre, int edad, decimal sueldo, string sector) : base(nombre, edad, sueldo)
        {
            this.Sector = sector;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Empleado[] empleados = new Empleado[5];

            int indice = 0;

            // Rellenamos el array
            while (indice < empleados.Length)
            {
                Console.WriteLine("Ingrese datos de los empleados");
                Console.WriteLine($"Empleado {indice}\n");
                Console.WriteLine("Nombre: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Edad: ");
                int edad = int.Parse(Console.ReadLine());

                Console.WriteLine("Sueldo: ");
                decimal sueldo = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Seleccione el tipo de empleado, 1 para Tecnico o 2 para Administrativo.\n");
                int tipo = int.Parse(Console.ReadLine());
                if (tipo == 1)
                {
                    Console.WriteLine ("Especialidad: ");
                    string especialidad = Console.ReadLine();
                    empleados[indice] = new Tecnico (nombre, edad, sueldo, especialidad);
                } else if (tipo == 2)
                {
                    Console.WriteLine("Sector: ");
                    string sector = Console.ReadLine();
                    empleados[indice] = new Administrativo(nombre, edad, sueldo, sector);
                }
                indice ++;
            }


        }
    }
}
