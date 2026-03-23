using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_enum
{
    public abstract class CuentaBancaria
    {
        public abstract double Saldo { get; set; }
        public abstract void Depositar(double cantidad);
        public abstract void Retirar(double cantidad);
    }

    public class CuentaCorriente : CuentaBancaria 
    {
        public override double Saldo
        {
            get => Saldo;
            set => Saldo = value;
        }

        public override void Depositar(double cantidad)
        {
            Saldo += cantidad;
        }
        public override void Retirar(double cantidad)
        {
            Saldo -= cantidad;
        }
    }

    public class CuentaDeAhorros : CuentaBancaria {

        public override double Saldo
        {
            get => Saldo;
            set => Saldo = value;
        }

        public override void Depositar(double cantidad)
        {
            Saldo += cantidad;
        }
        public override void Retirar(double cantidad)
        {
            if (Saldo > cantidad)
            {
                Saldo -= cantidad;
            }
            else
            {
                Console.WriteLine("No tiene saldo para realizar la transaccion");
            }
        }
    }
}
