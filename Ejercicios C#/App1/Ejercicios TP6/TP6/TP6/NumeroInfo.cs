using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP6
{
    internal class NumeroInfo
    {
        public int Numero { get; set; }
        public int Frecuencia { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is NumeroInfo k)
            {
                return (k.Frecuencia == this.Frecuencia);
            }
            return false;
        }

        public override int GetHashCode() {
            return Frecuencia.GetHashCode();
        }

        public NumeroInfo(int numero, int frecuencia) {
            Numero = numero;
            Frecuencia = frecuencia;
        }
    }
}
