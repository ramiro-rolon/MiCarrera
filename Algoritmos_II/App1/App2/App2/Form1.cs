using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2
{
    public partial class frmTP1: Form
    {
        public frmTP1()
        {
            InitializeComponent();
        }
        private bool ValidarInscripcion()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)){
                MessageBox.Show("No puede no haber un nombre inscripto");
                return false;
            }
            int edad;
            if (!int.TryParse(txtEdad.Text, out edad))
            {
                MessageBox.Show("Error: por favor ingrese una edad valida");
                txtEdad.Text = "";
                txtEdad.Focus();
                return false;
            }
            if (edad < 12 || edad > 99)
            {
                MessageBox.Show("La edad no puede ser menor a 12 ni mayor a 99");
                txtEdad.Text = "";
                txtEdad.Focus();
                return false;
            }
            if (cboTaller.TabIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un taller");
                cboTaller.Focus();
                return false;
            }
            if (rbtMañana.Checked == false && rbtTarde.Checked == false)
            {
                MessageBox.Show("Debe seleccionar un turno");
                return false;
            }

            if (chkAcepto.Checked == false)
            {
                MessageBox.Show("Debe aceptar Terminos Y Condiciones");
                return false;
            }
            return true;
        }

        private void AgregarALista(Inscripcion inscripto)
        {
            lstInscriptos.Items.Add(inscripto.Datos());
        }
        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarInscripcion())
                {
                    return;
                }
                int edad = int.Parse(txtEdad.Text);

                string turno = rbtMañana.Checked ? "Mañana" : "Tarde";

                // Aca se supone que llega sin errores.

                Inscripcion inscripcion = new Inscripcion(txtNombre.Text, edad, cboTaller.Text, turno);

                AgregarALista(inscripcion);
                txtNombre.Text = "";
                txtNombre.Focus();
                txtEdad.Text = "";
                cboTaller.SelectedIndex = -1;
                rbtMañana.Checked = false;
                rbtTarde.Checked = false;
                chkAcepto.Checked = false;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTP1_Load(object sender, EventArgs e)
        {
            cboTaller.Items.Add("ELECTRICISTA");
            cboTaller.Items.Add("BARTENDER");
            cboTaller.Items.Add("PANADERO");
            cboTaller.Items.Add("MESSI");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
