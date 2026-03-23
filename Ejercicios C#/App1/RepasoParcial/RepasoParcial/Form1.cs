using System;
using System.Data;
using System.Text.Json;
using MySql.Data.MySqlClient;

namespace RepasoParcial
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            dgvTareas.ContextMenuStrip = contextMenuStrip1;
            dgvEmpleados.ContextMenuStrip = contextMenuStrip2;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionBD conexion = new ConexionBD();

                if (conexion.Conectar())
                {
                    MessageBox.Show("Conexion Exitosa");


                    dgvEmpleados.DataSource = null;
                    string query = "SELECT * FROM Empleados";

                    MySqlDataAdapter AdaptadorEmpleados = new MySqlDataAdapter(query, conexion.ObtenerConexion());
                    DataTable dataTable = new DataTable();
                    AdaptadorEmpleados.Fill(dataTable);
                    dgvEmpleados.DataSource = dataTable;


                    dgvTareas.DataSource = null;
                    string queryTareas = "SELECT * FROM Tareas";

                    MySqlDataAdapter AdaptadorTareas = new MySqlDataAdapter(queryTareas, conexion.ObtenerConexion());
                    DataTable TablaTareas = new DataTable();
                    AdaptadorTareas.Fill(TablaTareas);
                    dgvTareas.DataSource = TablaTareas;

                    conexion.Desconectar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion: " + ex.Message);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dgvTareas.AutoGenerateColumns = true;
            dgvEmpleados.AutoGenerateColumns = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmPrincipal.ActiveForm.Close();
        }

        private void dgvTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Focused)
            {
                frmAgregarEmpleado frmagregarempleado = new frmAgregarEmpleado();
                frmagregarempleado.ShowDialog();
            }
            else if (dgvTareas.Focused)
            {
                frmAgregarTarea frmAgregarTarea = new frmAgregarTarea();
                frmAgregarTarea.ShowDialog();
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            dgvTareas.DataSource = null;
            dgvEmpleados.DataSource = null;
            MessageBox.Show("Desconectado");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvTareas.DataSource = null;
            dgvEmpleados.DataSource = null;
            try
            {
                ConexionBD conexion = new ConexionBD();

                if (conexion.Conectar())
                {
                    string query = "SELECT * FROM Empleados";

                    MySqlDataAdapter AdaptadorEmpleados = new MySqlDataAdapter(query, conexion.ObtenerConexion());
                    DataTable dataTable = new DataTable();
                    AdaptadorEmpleados.Fill(dataTable);
                    dgvEmpleados.DataSource = dataTable;


                    dgvTareas.DataSource = null;
                    string queryTareas = "SELECT * FROM Tareas";

                    MySqlDataAdapter AdaptadorTareas = new MySqlDataAdapter(queryTareas, conexion.ObtenerConexion());
                    DataTable TablaTareas = new DataTable();
                    AdaptadorTareas.Fill(TablaTareas);
                    dgvTareas.DataSource = TablaTareas;

                    conexion.Desconectar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de al actualizar: " + ex.Message);
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guardarArchivoJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Focused)
            {
                saveFileDialog1.Filter = "Archivos JSON (*.json)|*.json";
                saveFileDialog1.Title = "Guardar Empleados como JSON";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
                    foreach (DataGridViewRow row in dgvEmpleados.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            Dictionary<string, object> rowData = new Dictionary<string, object>();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                rowData[dgvEmpleados.Columns[cell.ColumnIndex].Name] = cell.Value;
                            }
                            data.Add(rowData);
                        }
                    }

                    string archivo = JsonSerializer.Serialize(data);
                    File.WriteAllText(saveFileDialog1.FileName, archivo);
                    MessageBox.Show("Archivo guardado correctamente.");
                }
            }
        }
    }
}
