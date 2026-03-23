using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_TP3
{
    // Ejercicio 2
    internal static class Utilidades
    {
        //Metodo Buscar empleado 
        public static Empleado BuscarEmpleado(Empleado [] empleados, string nombre) 
        {
            foreach (Empleado empleado in empleados) //por cada elemento del tipo Empleado en el array "empleados", creo un "empleado"
            {
                if (empleado.Nombre.Equals(nombre)) // tomo el elemento empleado y comparo su Nombre con el nombre que paso por parametro (a traves del Equals)
                {
                    return empleado; // Si da true, retorno el empleado
                }
            }
            return null; // si o si le tengo que poner esto, en caso de no retornar nada
        }
        // Metodo para devolver el empleado con sueldo mas alto
        public static Empleado SueldoAlto(Empleado[] empleados)
        {
            decimal sueldoAlto = 0; // Variable auxiliar para comparar sueldos
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Sueldo > sueldoAlto)
                {
                    sueldoAlto = empleado.Sueldo; // Dejo establecido cual es el sueldo mas alto
                }
            }
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Sueldo == sueldoAlto) // Recorro de nuevo el array hasta encontrar al que tiene el sueldo mas alto
                    return empleado;
            }
            return null;
        }
        // Metodo para sacar el promedio de la edad
        public static double PromedioEdad(Empleado[] empleados) 
        {
            int totalEdad = 0;

            foreach (var empleado in empleados)
            {
                totalEdad += empleado.Edad;
            }

            return (double)totalEdad/(double)empleados.Length;
        }
    }
}
