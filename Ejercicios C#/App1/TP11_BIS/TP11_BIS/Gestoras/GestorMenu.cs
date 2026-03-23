using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11_BIS
{
    public class GestorMenu
    {
        List<ProductoMenu> Menu = new List<ProductoMenu>();

        public bool AgregarProducto(ProductoMenu productito)
        {
            foreach (ProductoMenu producto in Menu)
            {
                if (producto.IdProducto == productito.IdProducto)
                {
                    Console.WriteLine($"El producto con id {producto.IdProducto} ya ha sido ingresado");
                    return false;
                }
            }
            Menu.Add(productito);
            return true;
        }

        public void ListarProductos()
        {
            foreach(ProductoMenu producto in Menu)
            {
                producto.MostrarDatos();
            }
        }

        public ProductoMenu BuscarPorId(int id)
        {
            foreach (ProductoMenu producto in Menu)
            {
                if (producto.IdProducto == id){
                    return producto;
                }
            }
            return null;
        }
        public bool ActualizarDisponibilidad(int idproducto, bool disponible)
        {
            ProductoMenu producto = BuscarPorId(idproducto);
            if (producto == null)
            {
                Console.WriteLine($"No se encontro un producto con id {idproducto}");
                return false;
            }
            BuscarPorId(idproducto).Disponible = disponible;
            return true;
        }
    }
}
