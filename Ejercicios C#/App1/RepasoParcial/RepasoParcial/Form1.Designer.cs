namespace RepasoParcial
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tbcPrincipal = new TabControl();
            tabPage1 = new TabPage();
            dgvEmpleados = new DataGridView();
            tabPage2 = new TabPage();
            dgvTareas = new DataGridView();
            panel1 = new Panel();
            btnActualizar = new Button();
            btnSalir = new Button();
            btnDesconectar = new Button();
            btnConectar = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            agregarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            agregarToolStripMenuItem1 = new ToolStripMenuItem();
            eliminarToolStripMenuItem1 = new ToolStripMenuItem();
            modificarToolStripMenuItem1 = new ToolStripMenuItem();
            guardarArchivoJSONToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            tbcPrincipal.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTareas).BeginInit();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tbcPrincipal
            // 
            tbcPrincipal.Controls.Add(tabPage1);
            tbcPrincipal.Controls.Add(tabPage2);
            tbcPrincipal.Dock = DockStyle.Fill;
            tbcPrincipal.Location = new Point(0, 0);
            tbcPrincipal.Name = "tbcPrincipal";
            tbcPrincipal.SelectedIndex = 0;
            tbcPrincipal.Size = new Size(800, 450);
            tbcPrincipal.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvEmpleados);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Empleados";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Dock = DockStyle.Fill;
            dgvEmpleados.Location = new Point(3, 3);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.Size = new Size(786, 416);
            dgvEmpleados.TabIndex = 0;
            dgvEmpleados.CellContentClick += dgvEmpleados_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvTareas);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tareas";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTareas
            // 
            dgvTareas.AllowUserToAddRows = false;
            dgvTareas.AllowUserToDeleteRows = false;
            dgvTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTareas.Dock = DockStyle.Fill;
            dgvTareas.Location = new Point(3, 3);
            dgvTareas.Name = "dgvTareas";
            dgvTareas.ReadOnly = true;
            dgvTareas.Size = new Size(786, 416);
            dgvTareas.TabIndex = 0;
            dgvTareas.CellContentClick += dgvTareas_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnDesconectar);
            panel1.Controls.Add(btnConectar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 397);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 53);
            panel1.TabIndex = 1;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(240, 18);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(85, 23);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(694, 18);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(125, 18);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(87, 23);
            btnDesconectar.TabIndex = 1;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(12, 18);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(92, 23);
            btnConectar.TabIndex = 0;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, eliminarToolStripMenuItem, modificarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(126, 70);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(125, 22);
            agregarToolStripMenuItem.Text = "Agregar";
            agregarToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(125, 22);
            eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(125, 22);
            modificarToolStripMenuItem.Text = "Modificar";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem1, eliminarToolStripMenuItem1, modificarToolStripMenuItem1, guardarArchivoJSONToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(192, 92);
            // 
            // agregarToolStripMenuItem1
            // 
            agregarToolStripMenuItem1.Name = "agregarToolStripMenuItem1";
            agregarToolStripMenuItem1.Size = new Size(191, 22);
            agregarToolStripMenuItem1.Text = "Agregar";
            // 
            // eliminarToolStripMenuItem1
            // 
            eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            eliminarToolStripMenuItem1.Size = new Size(191, 22);
            eliminarToolStripMenuItem1.Text = "Eliminar";
            // 
            // modificarToolStripMenuItem1
            // 
            modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            modificarToolStripMenuItem1.Size = new Size(191, 22);
            modificarToolStripMenuItem1.Text = "Modificar";
            // 
            // guardarArchivoJSONToolStripMenuItem
            // 
            guardarArchivoJSONToolStripMenuItem.Name = "guardarArchivoJSONToolStripMenuItem";
            guardarArchivoJSONToolStripMenuItem.Size = new Size(191, 22);
            guardarArchivoJSONToolStripMenuItem.Text = "Guardar Archivo JSON";
            guardarArchivoJSONToolStripMenuItem.Click += guardarArchivoJSONToolStripMenuItem_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(tbcPrincipal);
            Name = "frmPrincipal";
            Text = "Repaso Parcial";
            Load += frmPrincipal_Load;
            tbcPrincipal.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTareas).EndInit();
            panel1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcPrincipal;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private DataGridView dgvEmpleados;
        private Button btnSalir;
        private Button btnDesconectar;
        private Button btnConectar;
        private DataGridView dgvTareas;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private Button btnActualizar;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem agregarToolStripMenuItem1;
        private ToolStripMenuItem eliminarToolStripMenuItem1;
        private ToolStripMenuItem modificarToolStripMenuItem1;
        private ToolStripMenuItem guardarArchivoJSONToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
    }
}
