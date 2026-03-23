using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{
    class Persona
    {
        public string nombre { get; set; }
        public int edad { get; set; }
        public string ciudad { get; set; }
        public List<string> Intereses { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string email { get; set; }

        public Persona(string nombre, int edad, string ciudad, DateTime fechanac, string email)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.ciudad = ciudad;
            this.FechaNacimiento = fechanac;
            this.email = email;
            Intereses = new List<string>();
        }

        public void AgregarIntereses(string interes)
        {
            Intereses.Add(interes);
        }

        public override string ToString()
        {
            return ($"Nombre: {nombre} | Edad: {edad} | Ciudad: {ciudad} | Fecha de nacimiento: {FechaNacimiento} | Email: {email} | Intereses: {string.Join(", ", Intereses)}");
        }

        public Persona() { Intereses = new List<string>(); }

        // Fue necesario hacer una sobrecarga del constructor para que funcione el boton abrir
    }
}
