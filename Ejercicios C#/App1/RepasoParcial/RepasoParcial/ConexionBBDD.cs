using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace RepasoParcial
{
    internal class ConexionBD
    {
        private MySqlConnection conexion;
        public string cadenaConexion;


        public ConexionBD()
        {
            cadenaConexion = "server=localhost;database=repaso;uid=root;pwd=;";
            conexion = new MySqlConnection(cadenaConexion);
        }

        // Método para abrir la conexión
        public bool Conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void Desconectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Método para obtener la conexión actual (por si necesitás usarla en un comando)
        public MySqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
