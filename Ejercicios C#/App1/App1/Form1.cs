using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class frmEjercicio3 : Form
    {
        public frmEjercicio3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double salario = double.Parse(txtSalario.Text);
                if(txtNombre.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre");
                    txtNombre.Focus();
                }
                else if (salario <= 300000)
                {
                    MessageBox.Show("El salario no puede ser menor a $300000");
                    txtSalario.Focus();
                }
                else if (rbtGerente.Checked == true)
                {
                    lblResultado.Text = $"{txtNombre.Text} es {rbtGerente.Text}\nSu salario bruto es de ${txtSalario.Text}\nSe le descuentan ${salario * 0.2}\n" +
                        $"Su sueldo neto es de ${salario - (salario * 0.2)}";
                }
                else if (rbtSubGerente.Checked == true)
                {
                    lblResultado.Text = $"{txtNombre.Text} es {rbtSubGerente.Text}\nSu salario bruto es de ${txtSalario.Text}\nSe le descuentan ${salario * 0.15}\n" +
                        $"Su sueldo neto es de ${salario - (salario * 0.15)}";
                }
                else if (rbtSecretaria.Checked == true) {
                    lblResultado.Text = $"{txtNombre.Text} forma parte de {rbtSecretaria.Text}\nSu salario bruto es de ${txtSalario.Text}\nSe le descuentan ${salario * 0.05}\n" + 
                        $"Su sueldo neto es de ${salario - (salario * 0.05)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
