using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoParcial
{
    public partial class frmAgregarEmpleado : Form
    {
        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                ConexionBD conexion = new ConexionBD();
                conexion.Conectar();
                string query = "SELECT id_empleado FROM empleados ORDER BY id_empleado desc LIMIT 1";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion.ObtenerConexion());
                txtIdEmpleado.Enabled = false;
                txtIdEmpleado.Text = (Convert.ToInt32(adapter.SelectCommand.ExecuteScalar()) + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado.ActiveForm.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try {
                ConexionBD conexion = new ConexionBD();
                conexion.Conectar();
                string query = "INSERT INTO empleados (id_empleado, nombre, apellido, email, id_departamento)" +
                    "VALUES(@id, @nombre, @apellido, @email, @id_departamento)";
                MySqlCommand comando = new MySqlCommand(query, conexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", int.Parse(txtIdEmpleado.Text));
                comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@apellido", txtApellido.Text);
                comando.Parameters.AddWithValue("@email", txtEmail.Text);
                comando.Parameters.AddWithValue("@id_departamento", int.Parse(txtIdDepartamento.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado correctamente.");
                conexion.Desconectar();
                btnSalir_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el empleado: " + ex.Message);
            }
        }
    }
}
