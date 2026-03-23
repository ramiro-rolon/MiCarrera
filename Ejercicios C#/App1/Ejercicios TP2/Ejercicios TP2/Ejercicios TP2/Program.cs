using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_TP2
{
    /* Ejercicio 1
     
    class Empleado
    {
        private string Nombre;
        private int Edad;
        private double Sueldo;

        public void SetNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public void SetEdad(int edad)
        {
            this.Edad = edad;
        }

        public void SetSueldo(double sueldo)
        {
            this.Sueldo = sueldo;            
        }

        public string GetNombre()
        {
            return Nombre;
        }

        public int GetEdad()
        {
            return Edad;
        }
        public double GetSueldo()
        {
            return Sueldo;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Empleado Nicolas = new Empleado();
            Nicolas.SetNombre("Nicolas");
            Nicolas.SetEdad(1000000);
            Nicolas.SetSueldo(150000000);

            Console.WriteLine("Empleado: " + Nicolas.GetNombre());
            Console.WriteLine("Edad: " + Nicolas.GetEdad());
            Console.WriteLine("Sueldo: $" + Nicolas.GetSueldo());

            Empleado Ramiro = new Empleado();
            Ramiro.SetNombre("Ramiro");
            Ramiro.SetEdad(24);
            Ramiro.SetSueldo(430000);
            Console.WriteLine("Empleado: " + Ramiro.GetNombre());
            Console.WriteLine("Edad: " + Ramiro.GetEdad());
            if (Ramiro.GetSueldo() >= 500000)
            {
                Console.WriteLine("Sueldo: $" + Ramiro.GetSueldo());
            }
            else
            {
                Console.WriteLine("ERROR: ¿Cómo le van a pagar menos de $500000?");
            }
        }
    }*/

    /* Ejercicio 2 y 3 y 4?
    internal class Program
    {

        class Persona
        {
            public string Nombre;
            public int Edad;
            public Persona(string nombre, int edad)
            {
                this.Edad = edad;
                this.Nombre = nombre;
            }

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"Persona: {this.Nombre}, Edad: {this.Edad}");
            }
        }

        class Alumno : Persona
        {
            public string Curso;
            public Alumno(string nombre, int edad, string curso) : base(nombre, edad)
            {
                this.Curso = curso;
            }

            public override void MostrarInfo()
            {
                Console.WriteLine($"Alumno: {this.Nombre}, Edad: {this.Edad}, Cursa: {this.Curso}");
            }

        }

        class Profesor : Persona
        {
            public string Materia;

            public Profesor(string nombre, int edad, string materia) : base(nombre, edad)
            {
                this.Materia = materia;
            }

            public override void MostrarInfo()
            {
                Console.WriteLine($"Profesor: {this.Nombre}, Edad: {this.Edad}, Materia: {this.Materia}");
            }

            static void Main(string[] args)
            {
                Alumno julian = new Alumno("Julian", 23, "Analisis Matematico II");
                Profesor xavier = new Profesor("Xavier", 45, "Algoritmos II");
                Persona rama = new Persona("Ramiro", 56);

                julian.MostrarInfo();
                rama.MostrarInfo();
                xavier.MostrarInfo();
            }
        }
    }
    */


    /* Ejercicio 5
    internal class Program
    {

        class Persona
        {
            public string Nombre;
            public int Edad;
            public Persona(string nombre, int edad)
            {
                this.Edad = edad;
                this.Nombre = nombre;
            }

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"Persona: {this.Nombre}, Edad: {this.Edad}");
            }
        }

        class Alumno : Persona
        {
            public string Curso;
            public Alumno(string nombre, int edad, string curso) : base(nombre, edad)
            {
                this.Curso = curso;
            }

            public override void MostrarInfo()
            {
                Console.WriteLine($"Alumno: {this.Nombre}, Edad: {this.Edad}, Cursa: {this.Curso}");
            }

        }

        class Profesor : Persona
        {

            public Profesor(string nombre, int edad) : base(nombre, edad)
            {
                this.Nombre = nombre;
                this.Edad = edad;
            }
            public string Materia{ get; set; }

            public override void MostrarInfo()
            {
                Console.WriteLine($"Profesor: {this.Nombre}, Edad: {this.Edad}");
            }

            static void Main(string[] args)
            {
                Alumno julian = new Alumno("Julian", 23, "Analisis Matematico II");
                Profesor xavier = new Profesor("Xavier", 45);
                xavier.Materia="Algoritmos II";
                Persona rama = new Persona("Ramiro", 56);

                julian.MostrarInfo();
                rama.MostrarInfo();
                xavier.MostrarInfo();
                Console.WriteLine(xavier.Materia);
            }
        }
    }
    */

    /* Ejercicio 6
    internal class Program
    {

        class Persona
        {
            public string Nombre;
            public int Edad;
            public Persona(string nombre, int edad)
            {
                this.Edad = edad;
                this.Nombre = nombre;
            }

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"Persona: {this.Nombre}, Edad: {this.Edad}");
            }
        }

        class Alumno : Persona
        {
            public string Curso;
            public Alumno(string nombre, int edad, string curso) : base(nombre, edad)
            {
                this.Curso = curso;
            }

            public override void MostrarInfo()
            {
                Console.WriteLine($"Alumno: {this.Nombre}, Edad: {this.Edad}, Cursa: {this.Curso}");
            }

        }

        static void Main(string[] args)
        {
            Alumno[] alumnos = new Alumno[5];
            alumnos[0] = new Alumno("Julian", 24, "Algoritmos II");
            alumnos[1] = new Alumno("Octavio", 25, "Analisis Matematico III");
            alumnos[2] = new Alumno("Rama", 24, "Futbol Y Formaciones");
            alumnos[3] = new Alumno("Tirso", 20, "Ingenieria de Software");
            alumnos[4] = new Alumno("Renzo", 10+9, "Practicas");

            for (int i = 0; i < alumnos.Length; i++)
            {
                alumnos[i].MostrarInfo();
            }
        }
    }
    */

    // Ejercicio 7 y 8

    class Empleado
    {
        private decimal Sueldo;

        public string Nombre { get; set; }
        public int Edad { get; set; }

        public void SetSueldo(decimal sueldo)
        {
            this.Sueldo = sueldo;
        }


        public decimal GetSueldo()
        {
            return Sueldo;
        }

        public void SetBono(decimal bono) {
            if (bono < ((this.Sueldo)/20)*100) {
                Console.WriteLine("PARAAAAA");
            }
            else
            {
                this.SetBono(bono);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Empleado Nicolas = new Empleado();
            Nicolas.SetSueldo(150000000);
            Nicolas.Nombre = "Nicolas";
            Nicolas.Edad = 100;

            Console.WriteLine(Nicolas.Nombre);
            Console.WriteLine(Nicolas.Edad);
            Console.WriteLine("Sueldo: $" + Nicolas.GetSueldo());

            Empleado Ramiro = new Empleado();
            Ramiro.SetSueldo(430000);
            Ramiro.Nombre = "Ramiro";
            Ramiro.Edad = 24;
            Console.WriteLine("Empleado: " + Ramiro.Nombre);
            Console.WriteLine("Edad: " + Ramiro.Edad);
            if (Ramiro.GetSueldo() >= 500000)
            {
                Console.WriteLine("Sueldo: $" + Ramiro.GetSueldo());
            }
            else
            {
                Console.WriteLine("ERROR: ¿Cómo le van a pagar menos de $500000?");
            }
        }
    }


}
