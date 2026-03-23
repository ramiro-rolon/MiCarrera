using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorCliente Octavio = new GestorCliente();
            GestorMenu Julian = new GestorMenu();
            GestorPedidos Ramiro = new GestorPedidos();
            int opcion = 1;
            while(opcion != 0)
            {
                Console.WriteLine("Bienvenido al sistema de pedidos");
                Console.WriteLine("Que desea realizar?");
                Console.WriteLine("1. Agregar Producto al Menu");
                Console.WriteLine("2. Listar los Productos del Menu");
                Console.WriteLine("3. Actualizar Disponibilidad del Producto");
                Console.WriteLine("4. Agregar CLiente");
                Console.WriteLine("5. Listar Clientes");
                Console.WriteLine("6. Crear Nuevo Pedido");
                Console.WriteLine("7. Listar Todos los Pedidos");
                Console.WriteLine("8. Modficar Estado de un Pedido");
                Console.WriteLine("0. Salir");

                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                    {
                    case 1:
                        Console.WriteLine("Ingrese id del Producto");
                        int idp;
                        if (!int.TryParse(Console.ReadLine(), out idp))
                        {
                            Console.WriteLine("No ingreso una opcion correcta");
                            break;
                        }
                        Console.WriteLine("Ingrese nombre del producto");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese una descripcion del producto");
                        string descripcion = Console.ReadLine();
                        Console.WriteLine("Ingrese el precio del producto");
                        decimal precio;
                        if(!decimal.TryParse(Console.ReadLine(), out precio))
                        {
                            Console.WriteLine("No ingreso una opcion correcta");
                            break;
                        }
                        ProductoMenu productazo = new ProductoMenu(idp, nombre, descripcion, precio);
                        Julian.AgregarProducto(productazo);
                        break;
                    case 2:
                        Julian.ListarProductos();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el id del producto que quiere actualizar");
                        int id_buscado;
                        if(!int.TryParse(Console.ReadLine(), out id_buscado))
                        {
                            Console.WriteLine("No ingreso un id valido");
                            break;
                        }
                        Console.WriteLine("Ingrese el valor que quiere establecer: 1. No disponible o 2. Disponible");
                        Console.WriteLine("Solo ponga el numero");
                        int disponibilidad = int.Parse(Console.ReadLine());
                        Julian.ActualizarDisponibilidad(id_buscado, disponibilidad == 1 ? false : true);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese id de cliente");
                        int id_cliente;
                        if(!int.TryParse(Console.ReadLine(), out id_cliente))
                        {
                            Console.WriteLine("No ingreso un valor valido");
                            break;
                        }
                        Console.WriteLine("Ingrese el nombre del cliente");
                        string nombre_cliente = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del cliente");
                        string apellido_cliente = Console.ReadLine();
                        Cliente clientito = new Cliente(id_cliente, nombre_cliente, apellido_cliente);
                        Octavio.AgregarCliente(clientito);
                        break;
                    case 5:
                        Octavio.ListarClientes();
                        break;
                    case 6:
                        Ramiro.CrearNuevoPedido(Julian, Octavio);
                        break;
                    case 7:
                        Ramiro.ListarPedidos();
                        break;
                    case 8:
                        Console.WriteLine("Ingrese el numero de id del producto que desea modificar:");
                        int id_modificar;
                        if(!int.TryParse(Console.ReadLine(),out id_modificar))
                        {
                            Console.WriteLine("Valor ingresado no valido");
                        }
                        Console.WriteLine("Ingrese el nuevo estado del pedido, debe ser Pendiente, Preparado, Entregado o Cancelado");
                        Ramiro.ModificarEstadoPedido(id_modificar, Console.ReadLine());
                        break;
                    case 0:
                        Console.WriteLine("Gracias por utilizar nuestro sistema, hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                    }
                }
            }
        }
    }
