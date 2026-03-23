using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class GestorCliente
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public bool AgregarCliente(Cliente cliente)
        {
            foreach (Cliente clientito in Clientes)
            {
                if (cliente.IdCliente == clientito.IdCliente) {
                    Console.WriteLine($"El cliente con id {clientito.IdCliente} ya existe");
                    return false;
                }
            }
            Clientes.Add(cliente);
            Console.WriteLine("El cliente ha sido agregado con exito");
            return true;
        }
        public Cliente BuscarClientePorId(int id)
        {
            foreach (var cliente in Clientes)
            {
                if (cliente.IdCliente == id)
                {
                    return cliente;
                }
            }
            return null;
        }
        public void ListarClientes()
        {
            foreach (Cliente cliente in Clientes)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Datos del cliente");
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Apellido: {cliente.Apellido}");
                Console.WriteLine($"ID: {cliente.IdCliente}");
                Console.WriteLine("-----------------------");
            }
        }
    }
}
