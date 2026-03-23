namespace App4
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.errorProviderCampos = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lstPersonas = new System.Windows.Forms.ListBox();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intereses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarUnaPersona = new System.Windows.Forms.Button();
            this.clbIntereses = new System.Windows.Forms.CheckedListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialogPersonas = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogPersonas = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Edad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ciudad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(472, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Intereses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(391, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha de Nacimiento";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(115, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 26);
            this.txtNombre.TabIndex = 7;
            this.toolTip.SetToolTip(this.txtNombre, "Debe ingresar un nombre");
            // 
            // txtEdad
            // 
            this.txtEdad.Enabled = false;
            this.txtEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(115, 78);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(195, 26);
            this.txtEdad.TabIndex = 8;
            this.toolTip.SetToolTip(this.txtEdad, "Debe ingresar una edad");
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(115, 111);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 26);
            this.txtEmail.TabIndex = 9;
            this.toolTip.SetToolTip(this.txtEmail, "Debe ingresar un email");
            // 
            // cboCiudad
            // 
            this.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Items.AddRange(new object[] {
            "Mar del Plata",
            "Buenos Aires",
            "Santa Clara"});
            this.cboCiudad.Location = new System.Drawing.Point(115, 164);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(194, 21);
            this.cboCiudad.TabIndex = 10;
            this.toolTip.SetToolTip(this.cboCiudad, "Seleccione una ciudad");
            // 
            // errorProviderCampos
            // 
            this.errorProviderCampos.ContainerControl = this;
            // 
            // dtpNacimiento
            // 
            this.dtpNacimiento.Location = new System.Drawing.Point(556, 117);
            this.dtpNacimiento.Name = "dtpNacimiento";
            this.dtpNacimiento.Size = new System.Drawing.Size(235, 20);
            this.dtpNacimiento.TabIndex = 12;
            this.toolTip.SetToolTip(this.dtpNacimiento, "Seleccione su fecha de nacimiento");
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(719, 192);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(71, 22);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(590, 430);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(102, 27);
            this.btnAbrir.TabIndex = 14;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(732, 430);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 27);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lstPersonas
            // 
            this.lstPersonas.FormattingEnabled = true;
            this.lstPersonas.Location = new System.Drawing.Point(115, 220);
            this.lstPersonas.Name = "lstPersonas";
            this.lstPersonas.Size = new System.Drawing.Size(675, 82);
            this.lstPersonas.TabIndex = 16;
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.edad,
            this.ciudad,
            this.fechaNac,
            this.email,
            this.intereses});
            this.dgvPersonas.Location = new System.Drawing.Point(115, 323);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPersonas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPersonas.Size = new System.Drawing.Size(676, 72);
            this.dgvPersonas.TabIndex = 17;
            // 
            // nombre
            // 
            this.nombre.FillWeight = 83.45177F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // edad
            // 
            this.edad.FillWeight = 83.45177F;
            this.edad.HeaderText = "Edad";
            this.edad.Name = "edad";
            this.edad.ReadOnly = true;
            // 
            // ciudad
            // 
            this.ciudad.FillWeight = 83.45177F;
            this.ciudad.HeaderText = "Ciudad";
            this.ciudad.Name = "ciudad";
            this.ciudad.ReadOnly = true;
            // 
            // fechaNac
            // 
            this.fechaNac.FillWeight = 182.7411F;
            this.fechaNac.HeaderText = "Fecha de nacimiento";
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.ReadOnly = true;
            // 
            // email
            // 
            this.email.FillWeight = 83.45177F;
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // intereses
            // 
            this.intereses.FillWeight = 83.45177F;
            this.intereses.HeaderText = "Intereses";
            this.intereses.Name = "intereses";
            this.intereses.ReadOnly = true;
            // 
            // btnGuardarUnaPersona
            // 
            this.btnGuardarUnaPersona.Location = new System.Drawing.Point(70, 424);
            this.btnGuardarUnaPersona.Name = "btnGuardarUnaPersona";
            this.btnGuardarUnaPersona.Size = new System.Drawing.Size(239, 32);
            this.btnGuardarUnaPersona.TabIndex = 18;
            this.btnGuardarUnaPersona.Text = "Guardar 1 Persona";
            this.btnGuardarUnaPersona.UseVisualStyleBackColor = true;
            // 
            // clbIntereses
            // 
            this.clbIntereses.FormattingEnabled = true;
            this.clbIntereses.Items.AddRange(new object[] {
            "IA",
            "Medicina",
            "Musica"});
            this.clbIntereses.Location = new System.Drawing.Point(564, 48);
            this.clbIntereses.Name = "clbIntereses";
            this.clbIntereses.Size = new System.Drawing.Size(227, 49);
            this.clbIntereses.TabIndex = 19;
            this.toolTip.SetToolTip(this.clbIntereses, "Chequee los intereses que tenga");
            // 
            // openFileDialogPersonas
            // 
            this.openFileDialogPersonas.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 478);
            this.Controls.Add(this.clbIntereses);
            this.Controls.Add(this.btnGuardarUnaPersona);
            this.Controls.Add(this.dgvPersonas);
            this.Controls.Add(this.lstPersonas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtpNacimiento);
            this.Controls.Add(this.cboCiudad);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.ErrorProvider errorProviderCampos;
        private System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.Button btnGuardarUnaPersona;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.ListBox lstPersonas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckedListBox clbIntereses;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPersonas;
        private System.Windows.Forms.OpenFileDialog openFileDialogPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn intereses;
    }
}

