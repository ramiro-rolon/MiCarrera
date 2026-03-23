using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_enum
{
    public abstract class ComponenteUI
    {
        public abstract void Dibujar();
    }

    public class Boton : ComponenteUI
    {
        public override void Dibujar()
        {
            Console.WriteLine("[BOTON]");
        }
    }
    public class CajaTexto : ComponenteUI
    {
        public override void Dibujar()
        {
            Console.WriteLine("[Caja de Texto]");
        }
    }
    public class Etiqueta : ComponenteUI
    {
        public override void Dibujar()
        {
            Console.WriteLine("[Etiqueta]");
        }
    }
}
