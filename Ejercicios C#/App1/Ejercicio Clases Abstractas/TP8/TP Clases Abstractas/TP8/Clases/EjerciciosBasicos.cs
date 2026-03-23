using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_enum
    {
    public class EjerciciosBasicos
    {
        public abstract class Forma
        {
            public abstract double CalcularPerimetro();
        }

        public class Rectangulo : Forma
        {
            public double ancho { get; set; }
            public double alto { get; set; }
            public Rectangulo(double A, double B)
            {
                this.ancho = A;
                this.alto = B;
            }

            public override double CalcularPerimetro()
            {
                return (2 * ancho) + (2 * alto);
            }
        }

        public class Cuadrado : Forma
        {
            public double lado { get; set; }
            public Cuadrado(double lado)
            {
                this.lado = lado;
            }
            public override double CalcularPerimetro()
            {
                return lado * 4;
            }
        }

        public class Triangulo : Forma
        {
            public double ladoA { get; set; }
            public double ladoB { get; set; }
            public double ladoC { get; set; }

            public override double CalcularPerimetro()
            {
                return ladoA + ladoB + ladoC;
            }
        }
    }

    public abstract class Dispositivo {
        public abstract void Encender();
        public abstract void Apagar();
    }

    public class Television : Dispositivo
    {
        public override void Encender()
        {
            Console.WriteLine("OAAAA ENCENDISTE EL TELE MY BROTHER");
        }
        public override void Apagar()
        {
            Console.WriteLine ("AOOO CHAU CHAU *pantalla negra*");
        }
    }
    public class Telefono : Dispositivo
    {
        public override void Encender()
        {
            Console.WriteLine("HELLO MOTO");
        }
        public override void Apagar()
        {
            Console.WriteLine("GOODBYE MOTO");
        }
    }
}
