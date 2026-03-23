using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ejercicios_enum;

namespace TP8
{
    public abstract class Documento
    {
        public abstract string Nombre { get; set; }
        public TipoDocumento Tipo{ get; set;}
        public abstract void Abrir();
        public virtual string ObtenerInformacion() { return Nombre + " " + Tipo; }
    }

    public class DocumentoPDF : Documento
    {
        public override string Nombre
        {
            get;
            set;
        }

        public DocumentoPDF(string nombre)
        {
            this.Nombre = nombre;
            this.Tipo = TipoDocumento.PDF;
        }
        public override void Abrir() {
            Console.WriteLine("ABRIO EL PDF");
        }
        public override string ObtenerInformacion()
        {
            return ($"INFO DEL PDF\nNombre: {this.Nombre}\nTipo: {this.Tipo}");
        }
    }

    public class DocumentoTXT : Documento
    {
        public override string Nombre
        {
            get;
            set;
        }

        public DocumentoTXT(string nombre) { 
            this.Nombre = nombre;
            this.Tipo = TipoDocumento.TXT;
        }

        public override void Abrir()
        {
            Console.WriteLine("ABRIO EL TXT");
        }

        public override string ObtenerInformacion()
        {
            return ($"INFO DEL TXT\nNombre: {this.Nombre}\nTipo: {this.Tipo}");
        }
    }

    public class DocumentoDOCX : Documento
    {
        public override string Nombre
        {
            get;
            set;
        }
        public DocumentoDOCX(string nombre)
        {
            this.Nombre= nombre;
            this.Tipo= TipoDocumento.DOCX;
        }

        public override void Abrir() {
            Console.WriteLine("ABRIO EL DOCX");
        }
        public override string ObtenerInformacion()
        {
            return $"INFO DEL DOCX\nNombre: {this.Nombre}\nTipo: {this.Tipo}";
        }
    }
}
