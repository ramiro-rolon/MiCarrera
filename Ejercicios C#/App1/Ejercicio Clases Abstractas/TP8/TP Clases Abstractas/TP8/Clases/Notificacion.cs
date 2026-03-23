using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_enum
{
    public abstract class Notificacion
    {
        public abstract string Mensaje();
        public abstract void Enviar();
    }

    public class EmailNotificacion : Notificacion
    {
        public override string Mensaje()
        {
            return "Email Nuevo";
        }
        public override void Enviar()
        {
            Console.WriteLine(this.Mensaje());
        }
    }

    public class SMSNotificacion : Notificacion {
        public override string Mensaje() {
            return "Nuevo Mensaje";
        }
        public override void Enviar()
        {
            Console.WriteLine(this.Mensaje());
        }
    }
}
