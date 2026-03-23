using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class GestorPedidos
    {
        // Inicializamos la lista de pedidos
        public List<Pedido> Pedidos = new List<Pedido>();

        // Contador, a cada CREAR NUEVO PEDIDO que se haga, se suma 1

        private int IDP = 0;
        public Pedido CrearNuevoPedido(GestorMenu gestorMenu, GestorCliente gestorCliente) // Para la creacion de un pedido es necesario usar los gestores
        {                                                                                  // de cliente y de menu, para usarlos los pasamos por parametro
            Console.WriteLine("Por favor ingrese el numero de Id del cliente");
            string id = Console.ReadLine();                           // le pido al usuario que me pase un id de cliente
            int IDC;
            if (int.TryParse(id, out IDC))                            // Validacion importante: si lo que escribio el usuario se puede parsear de string a int
            {                                                         // que entre a crear el pedido
                GestorCliente Gaston = gestorCliente;                 // <= Asigno el gestor que pase por parametro a uno que creo dentro de la funcion
                Cliente cliente = Gaston.BuscarClientePorId(IDC);     // Busco al cliente con el gestor y lo arrojo en una variable de tipo Cliente
                if (cliente == null)                                  // Me fijo si el cliente es null, si lo es que muestre un mensaje y retorne null
                {
                    Console.WriteLine($"El cliente con id {IDC} no existe");
                    return null;
                }
                int opcion = 1;
                GestorMenu Julian = gestorMenu;                         // Si el cliente existe llega hasta aca, donde arranca a generarse el pedido
                Pedido pedido = new Pedido(IDP, IDC, DateTime.Now);     // Aca creo el pedido porque ya tengo lo que necesito para crearlo
                while (opcion != 0)                                     // Entro a un while, la opcion es la que se pregunta al final, si el usuario pone 
                {                                                       // termina la estructura repetitiva
                    Console.WriteLine("Ingrese id del item que quiere agregar al pedido");
                    string idi = Console.ReadLine();                                        // Pido el id del producto, más abajo realizo la validacion
                    int IDS;                                                                // Si el producto no existe, el bucle vuelve a empezar
                    if(!int.TryParse(idi, out IDS) || Julian.BuscarPorId(IDS) == null)
                    {
                        Console.WriteLine("Lo ingresado no concuerda con ninguno de los ids de producto existentes");
                        continue;
                    }
                    Console.WriteLine("Ingrese la cantidad del item que quiere agregar al pedido"); // Pido la cantidad de unidades que quiere del
                    string cantidad = Console.ReadLine();                                           // producto y la valido
                    int cant;
                    if (!int.TryParse(cantidad, out cant))
                    {
                        Console.WriteLine("Lo que ingreso no es valido");
                        continue;
                    }
                    ItemPedido item = new ItemPedido(Julian.BuscarPorId(IDS), cant);                // Genero un item pedido con el producto y la cantidad
                    pedido.Items.Add(item);                                                         // Y lo agrego a la lista de items del pedido que ya cree
                    Console.WriteLine("Desea agregar otro item al pedido?(si la respuesta es si precione cualquier tecla distinta de 0)");
                    opcion = int.Parse(Console.ReadLine());
                }
                Pedidos.Add(pedido); // Si el usuario cerro el bucle significa que el pedido ya esta listo para encargar
                IDP++;               // Lo agrego a la lista de la gestora y aumento el contador de ids de pedidos 
                return pedido;       // y retorno el pedido realizado
            }
            else
            {
                Console.WriteLine("Lo que ingreso no cuenta como id de cliente MAMAGUEVO");
                return null;    
            }
        }

        public void ListarPedidos()
        {
            decimal total;
            foreach (Pedido pedido in Pedidos)
            {
                total = 0;
                Console.WriteLine("--------------------");
                Console.WriteLine($"Numero de pedido: {pedido.IdPedido}");
                Console.WriteLine($"Numero de cliente: {pedido.IdCliente}");
                Console.WriteLine($"Fecha del pedido: {pedido.FechaPedido}");
                Console.WriteLine($"Estado del pedido: {pedido.Estado}");
                foreach(ItemPedido item in pedido.Items)
                {
                    Console.WriteLine($"\tItem: {item.Producto.Nombre}");
                    Console.WriteLine($"\tPrecio por unidad: ${item.Producto.Precio}");
                    Console.WriteLine($"\tCantidad: {item.Cantidad}");
                    Console.WriteLine($"\tSubtotal: {item.Producto.Precio * item.Cantidad})");
                    total += item.Producto.Precio * item.Cantidad;
                }
                Console.WriteLine($"Total del pedido: {total}");
                Console.WriteLine($"-------------------");
            }
        }

        public Pedido BuscarPedidoPorId(int id)
        {
            foreach (Pedido pedido in Pedidos) { 
                if(pedido.IdPedido == id) return pedido;
            }
            return null;
        }

        public bool ModificarEstadoPedido(int id, string NuevoEstado)
        {
            Pedido prueba = BuscarPedidoPorId(id);
            if (prueba == null)
            {
                Console.WriteLine("El id de pedido que paso no existe");
                return false;
            }
            if (NuevoEstado != "Pendiente" || NuevoEstado != "Preparado" || NuevoEstado != "Entregado" || NuevoEstado != "Cancelado")
            {
                Console.WriteLine("El estado que intento pasar no forma parte de los posibles estados de un pedido");
                return false;
            }
            BuscarPedidoPorId(id).Estado = NuevoEstado;
            Console.WriteLine($"El estado del pedido {id} ha sido modificado a '{NuevoEstado}'");
            return true;
        }
    }
}
