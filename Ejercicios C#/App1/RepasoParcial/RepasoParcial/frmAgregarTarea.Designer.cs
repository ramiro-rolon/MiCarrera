namespace RepasoParcial
{
    partial class frmAgregarTarea
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnGuardar = new Button();
            btnSalir = new Button();
            cboEmpleados = new ComboBox();
            txtHsTrabajadas = new TextBox();
            txtHsEstimadas = new TextBox();
            txtDescripcion = new TextBox();
            txtEmpleado = new TextBox();
            txtProyecto = new TextBox();
            txtTarea = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(cboEmpleados);
            panel1.Controls.Add(txtHsTrabajadas);
            panel1.Controls.Add(txtHsEstimadas);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(txtEmpleado);
            panel1.Controls.Add(txtProyecto);
            panel1.Controls.Add(txtTarea);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 450);
            panel1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(162, 390);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(106, 34);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(293, 390);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(110, 34);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cboEmpleados
            // 
            cboEmpleados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmpleados.FormattingEnabled = true;
            cboEmpleados.Location = new Point(286, 127);
            cboEmpleados.Name = "cboEmpleados";
            cboEmpleados.Size = new Size(117, 23);
            cboEmpleados.TabIndex = 12;
            cboEmpleados.SelectedIndexChanged += cboEmpleados_SelectedIndexChanged;
            // 
            // txtHsTrabajadas
            // 
            txtHsTrabajadas.Location = new Point(185, 275);
            txtHsTrabajadas.Name = "txtHsTrabajadas";
            txtHsTrabajadas.Size = new Size(83, 23);
            txtHsTrabajadas.TabIndex = 11;
            // 
            // txtHsEstimadas
            // 
            txtHsEstimadas.Location = new Point(185, 244);
            txtHsEstimadas.Name = "txtHsEstimadas";
            txtHsEstimadas.Size = new Size(83, 23);
            txtHsEstimadas.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(185, 199);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(218, 23);
            txtDescripcion.TabIndex = 9;
            // 
            // txtEmpleado
            // 
            txtEmpleado.Enabled = false;
            txtEmpleado.Location = new Point(185, 126);
            txtEmpleado.Name = "txtEmpleado";
            txtEmpleado.Size = new Size(83, 23);
            txtEmpleado.TabIndex = 8;
            // 
            // txtProyecto
            // 
            txtProyecto.Location = new Point(185, 92);
            txtProyecto.Name = "txtProyecto";
            txtProyecto.Size = new Size(83, 23);
            txtProyecto.TabIndex = 7;
            // 
            // txtTarea
            // 
            txtTarea.Enabled = false;
            txtTarea.Location = new Point(185, 53);
            txtTarea.Name = "txtTarea";
            txtTarea.Size = new Size(83, 23);
            txtTarea.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 283);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 5;
            label6.Text = "Hs Trabajadas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 244);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 4;
            label5.Text = "Hs Estimadas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 199);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 3;
            label4.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 126);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 2;
            label3.Text = "ID Empleardo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 92);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "ID Proyecto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 53);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "ID Tarea";
            // 
            // frmAgregarTarea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 450);
            Controls.Add(panel1);
            Name = "frmAgregarTarea";
            Text = "Agregar Tarea";
            Load += frmAgregarTarea_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSalir;
        private ComboBox cboEmpleados;
        private TextBox txtHsTrabajadas;
        private TextBox txtHsEstimadas;
        private TextBox txtDescripcion;
        private TextBox txtEmpleado;
        private TextBox txtProyecto;
        private TextBox txtTarea;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnGuardar;
    }
}