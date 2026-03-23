using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Ejercicio_1;


class EjerciciosPOO
{
    /* Ejercicio 1 y 2
       class Libro 
        {
        public string Titulo;
        public string Autor;
        public void MostrarInformacion()
        {
            Console.WriteLine(this.Titulo);
            Console.WriteLine(this.Autor);
        }
    }
static void Main(string[] args)
{
    Libro JDT = new Libro();
    JDT.Titulo = "Juego de Tronos";
    JDT.Autor = "George R. R. Martin";
    JDT.MostrarInformacion();
}*/

    /* Ejercicio 3

    class Libro
    {
        private string Titulo;
        private string Autor;
        public string GetTitulo()
        {
            return this.Titulo;
        }

        public void SetTitulo(string titulo)
        {
           this.Titulo = titulo;
        }

        public string GetAutor()
        {
            return this.Autor;
        }

        public void SetAutor(string autor)
        {
            this.Autor = autor;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Libro donquijote = new Libro();
            donquijote.SetTitulo("Don Quijote");
            donquijote.SetAutor("Nico Gay");

            Console.WriteLine(donquijote.GetAutor()); 
           
        }
    }
    */


    /*Ejercicio 4
   class Libro
   {
       public string Titulo;
       public string Autor;

       public Libro(string titulo, string autor) {
           this.Titulo = titulo;
           this.Autor = autor;
       }

   }

   class Program
   {
       static void Main(string[] args)
       {
           Libro rivadavia = new Libro("rivadavia", "manolo");
           Console.WriteLine(rivadavia.Titulo);
           Console.WriteLine(rivadavia.Autor);
       }
   }*/


    /* Ejercicio 5
    class Publicacion
    {
        public string Titulo;
        public string Autor;
    }
    
    class Libro: Publicacion
    {
        public string ISBN;
    }

    class Revista: Publicacion
    {
        public int Numero;
    }

    
        static void Main(string[] args)
        {
            Revista revista = new Revista();
            revista.Titulo = "Gente";
            revista.Autor = "Messi";
            revista.Numero = 10;

            Libro got = new Libro();
            got.Titulo = "Juego de Tronos";
            got.Autor = "George R. R. Martin";
            got.ISBN = "1";

            Console.WriteLine(got.Titulo);
            Console.WriteLine(got.Autor);
            Console.WriteLine(got.ISBN);

            Console.WriteLine(revista.Titulo);
            Console.WriteLine(revista.Autor);
            Console.WriteLine(revista.Numero);
        } */

    /* Ejercicio 6
     * 
    class Publicacion
    {
        public string Titulo;
        public string Autor;

        public virtual void MostrarInformacion()
        {
            Console.WriteLine(this.Titulo);
            Console.WriteLine(this.Autor);
        }
    }

    class Libro : Publicacion
    {
        public string ISBN;

        public override void MostrarInformacion()
        {
            Console.WriteLine(this.Titulo);
            Console.WriteLine(this.Autor);
            Console.WriteLine(this.ISBN);
        }
    }

    class Revista : Publicacion
    {
        public int Numero;

        public override void MostrarInformacion()
        {
            Console.WriteLine(this.Titulo);
            Console.WriteLine(this.Autor);
            Console.WriteLine(this.Numero);
        }
    }


    static void Main(string[] args)
    {
        Revista revista = new Revista();
        revista.Titulo = "ParaTi";
        revista.Autor = "Ricardo Fort";
        revista.Numero = 200;

        Libro got = new Libro();
        got.Titulo = "El señor de los Anillos";
        got.Autor = "Tolkien";
        got.ISBN = "5";

        revista.MostrarInformacion();
        got.MostrarInformacion();


    }*/

    /* Ejercicio 7

    class Publicacion
    {
        protected string Titulo;
        protected string Autor;
    }

    class Libro : Publicacion
    {
        private string ISBN;

        public void SetInfo(string Titulo, string Autor, string ISBN){
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.ISBN = ISBN;
        }
        public string GetTitulo()
        {
            return this.Titulo;
        }

        public string GetAutor()
        {
            return this.Autor;
        }
        public string GetISBN()
        {
            return this.ISBN;
        }
    }



    static void Main(string[] args)
    {
        Libro elPrincipito = new Libro();
        elPrincipito.SetInfo("El Principito", "Saint Ettiene", "150");
        Console.WriteLine(elPrincipito.GetTitulo() + ", " + elPrincipito.GetAutor() + ", " + elPrincipito.GetISBN());
    }
    */

    /* Ejercicio 8

    class Publicacion
    {
        protected string Titulo;
        protected string Autor;
    }

    class Libro : Publicacion
    {
        private string ISBN;
        private double Precio;

        public void SetInfo(string Titulo, string Autor, string ISBN, double Precio)
        {
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.ISBN = ISBN;
            this.Precio = Precio;
        }
        public string GetTitulo()
        {
            return this.Titulo;
        }

        public string GetAutor()
        {
            return this.Autor;
        }
        public string GetISBN()
        {
            return this.ISBN;
        }

        public double GetPrecio()
        {
            if (this.Precio >= 0)
            {
                return this.Precio;
            }
            else
            {
                Console.WriteLine("Error, el monto establecido no corresponde a un valor adecuado.");
                return 0;
            }
        }
    }



    static void Main(string[] args)
    {
        Libro elPrincipito = new Libro();
        elPrincipito.SetInfo("El Principito", "Saint Ettiene", "150", 2.50);
        Console.WriteLine(elPrincipito.GetTitulo() + ", " + elPrincipito.GetAutor() + ", " + elPrincipito.GetISBN());
        Console.WriteLine(elPrincipito.GetPrecio());
    } */

    /* Ejercicio 9

    class Libro
    {
        public string Titulo;
        public string Autor;
        public string ISBN;

        public Libro(string titulo)
        {
            this.Titulo = titulo;
        }

        public Libro(string titulo, string autor, string IBSN)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.ISBN = IBSN;
        }

    }

    static void Main(string[] args)
    {
        Libro got = new Libro("Juego de Tronos");

        Libro boquita = new Libro("Boquita", "Gago", "Cavani");

        Console.WriteLine(got.Titulo);
        Console.WriteLine(boquita.Titulo + ", " + boquita.Autor + ", " + boquita.ISBN);
    }
    */

    /* Ejercicio 10

    class Libro
    {
        public string Titulo;
        public string Autor;

        public Libro(string titulo, string autor) {
            this.Titulo = titulo;
            this.Autor = autor;
        }
        public void MostrarInfo()
        {
           Console.WriteLine(this.Titulo);
            Console.WriteLine(this.Autor);  
        }

    }

    static void Main(string[] args)
    {
        Libro[] biblioteca = new Libro[5];

        biblioteca[0] = new Libro("Juego de Tronos", "George R. R. Martin");
        biblioteca[1] = new Libro("El señor de los Anillos", "Tolkien");
        biblioteca[2] = new Libro("Martin Fierro", "Jose Hernandez");
        biblioteca[3] = new Libro("El Principito", "Un Frances");
        biblioteca[4] = new Libro("Nico", "Gay");

        for (int i = 0; i < biblioteca.Length; i++) { 
            biblioteca [i].MostrarInfo();
        }
    }
    */
}