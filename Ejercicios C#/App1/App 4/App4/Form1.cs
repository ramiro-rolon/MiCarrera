using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace App4
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboCiudad.SelectedIndex = -1;
            for (int i = 0; i < clbIntereses.Items.Count; i++) 
            {
                clbIntereses.SetItemChecked(i, false);
            }
            txtNombre.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProviderCampos.Clear();

            bool valido = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProviderCampos.SetError(txtNombre, "El nombre no puede estar vacío");
            }

            int edad_ = 0;

            if (DateTime.Now.Month > dtpNacimiento.Value.Month)
            {
                edad_ = DateTime.Now.Year - dtpNacimiento.Value.Year;
            }
            else if (DateTime.Now.Month == dtpNacimiento.Value.Month)
            {
                if (DateTime.Now.Day > dtpNacimiento.Value.Day)
                {
                    edad_ = DateTime.Now.Year - dtpNacimiento.Value.Year;
                }
            }
            else
            {
                edad_ = DateTime.Now.Year - dtpNacimiento.Value.Year - 1;
            }

            txtEdad.Text = edad_.ToString();

            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                valido = false;
                errorProviderCampos.SetError(txtEdad, "La no puede estar vacía");
            }
            else
            {
                // Este if medio que esta al pedo porque ya deshabilite el txt de edad para que se ponga de una
                // con el DateTimePicker pero me dio pereza borrarlo

                if (!int.TryParse(txtEdad.Text, out int edad))
                {
                    valido = false;
                    errorProviderCampos.SetError(txtEdad, "La edad debe ser un numero");
                }
                else
                {
                    if (edad < 12 || edad > 99)
                    {
                        valido = false;
                        errorProviderCampos.SetError(txtEdad, "Inserte una edad válida");
                    }
                }
            }

            if (cboCiudad.SelectedIndex == -1)
            {
                valido = false;
                errorProviderCampos.SetError(cboCiudad, "Debe seleccionar una ciudad");
            }

            string[] dominiosValidos = { "@gmail.com", "@hotmail.com", "@outlook.com" };
            bool emailValido = txtEmail.Text.Contains("@") && dominiosValidos.Any(d => txtEmail.Text.EndsWith(d));
            if (!emailValido || string.IsNullOrEmpty(txtEmail.Text)) 
            {
                valido = false;
                errorProviderCampos.SetError(txtEmail, "Debe ingresar un mail valido");
            }

            if (clbIntereses.CheckedItems.Count == 0) 
            {
                valido = false;
                errorProviderCampos.SetError(clbIntereses, "Debe seleccionar al menos un interes");
            }

            if (valido)
            {
                Persona personita = new Persona(txtNombre.Text, int.Parse(txtEdad.Text), cboCiudad.Text, dtpNacimiento.Value, txtEmail.Text);
                foreach (var item in clbIntereses.CheckedItems)
                {
                    personita.AgregarIntereses(item.ToString());
                }
                lstPersonas.Items.Add(personita);
                LimpiarCampos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialogPersonas.Filter = "ARCHIVO JSON|*.json";
            saveFileDialogPersonas.Title = "Guardar Personas";
           
            
            List<Persona> lista = new List<Persona>();
            foreach (var persona in lstPersonas.Items)
            {
                if (persona is Persona personita)
                {
                    lista.Add(personita);
                }
            }
            if (saveFileDialogPersonas.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(lista);
                File.WriteAllText(saveFileDialogPersonas.FileName, json);
                MessageBox.Show("Lista guardada exitosamente");
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            openFileDialogPersonas.Filter = "ARCHIVO JSON |*.json"; // El asterisco es importante
            openFileDialogPersonas.Title = "Abrir archivo de personas";

            if(openFileDialogPersonas.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialogPersonas.FileName;
                string contenido = File.ReadAllText(rutaArchivo);

                List<Persona> listarda = new List<Persona>();

                listarda = JsonSerializer.Deserialize<List<Persona>>(contenido);
                foreach(Persona personita in listarda)
                {
                    //lstPersonas.Items.Add(personita);
                    dgvPersonas.Rows.Add(
                        personita.nombre,
                        personita.edad,
                        personita.ciudad,
                        personita.FechaNacimiento.ToShortDateString(),
                        personita.email,
                        string.Join(", ", personita.Intereses)
                    );
                }

                /* Opcion sin tener que armar yo las columnas

                dgvPersonas.DataSource = listarda;
                */

                MessageBox.Show("Carga exitosa");

            }
        }
    }
}
