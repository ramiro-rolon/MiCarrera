using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
    public partial class frmAgregarTarea : Form
    {
        public frmAgregarTarea()
        {
            InitializeComponent();
        }

        private void frmAgregarTarea_Load(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();
            try
            {
                conexion.Conectar();

                string query = "SELECT concat(nombre, ' ', apellido) as nombre_completo FROM Empleados";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion.ObtenerConexion());
                DataTable empleados = new DataTable();
                adapter.Fill(empleados);
                cboEmpleados.DataSource = empleados;
                cboEmpleados.DisplayMember = "nombre_completo";
                cboEmpleados.SelectedIndex = -1;

                string query2 = "SELECT id_tarea FROM Tareas ORDER BY id_tarea desc LIMIT 1";
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(query2, conexion.ObtenerConexion());
                txtTarea.Text = (int.Parse(adapter2.SelectCommand.ExecuteScalar().ToString()) + 1).ToString();

                conexion.Desconectar();
            }
            catch
            {
                MessageBox.Show("Error al conectar con la base de datos.");
            }
        }

        private void cboEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtEmpleado.Text = (cboEmpleados.SelectedIndex + 1).ToString();
            }
            catch
            {
                MessageBox.Show("Error al cargar los datos del empleado.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmAgregarTarea.ActiveForm.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                ConexionBD conexion = new ConexionBD();
                conexion.Conectar();
                string query = "INSERT INTO Tareas (id_proyecto, id_empleado_2, descripcion," +
                    "horas_estimadas, horas_trabajadas)VALUES(@id_proyecto, @id_empleado, @descripcion," +
                    " @horas_estimadas, @horas_trabajadas)";
                MySqlCommand comando = new MySqlCommand(query, conexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_proyecto", int.Parse(txtProyecto.Text));
                comando.Parameters.AddWithValue("@id_empleado", int.Parse(txtEmpleado.Text));
                comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                comando.Parameters.AddWithValue("@horas_estimadas", int.Parse(txtHsEstimadas.Text));
                comando.Parameters.AddWithValue("@horas_trabajadas", int.Parse(txtHsTrabajadas.Text));
                comando.ExecuteNonQuery();
                conexion.Desconectar();
                MessageBox.Show("Tarea guardada con éxito.");
                btnSalir_Click(sender, e);
            }
            catch(Exception ex) {
                MessageBox.Show("Error al guardar la tarea." + ex.Message);
            }
        }
    }
}
