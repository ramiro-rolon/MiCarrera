using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public List<ItemPedido> Items { get; private set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public Pedido (int idpedido, int idcliente, DateTime fechaPedido)
        {
            IdPedido = idpedido;
            IdCliente = idcliente;
            FechaPedido = fechaPedido;
            Items = new List<ItemPedido> ();
            Estado = "Pendiente";
        }
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Cantidad * item.Producto.Precio;
            }
            return total;
        }
    }
}
