namespace RepasoFinal
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
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            btnNuevo = new Button();
            btnGuardarJSON = new Button();
            btnCargarJSON = new Button();
            btnEliminar = new Button();
            btnFiltrar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFiltrar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnCargarJSON);
            panel1.Controls.Add(btnGuardarJSON);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(27, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 113);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(761, 325);
            dataGridView1.TabIndex = 1;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(685, 77);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(103, 34);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "button1";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardarJSON
            // 
            btnGuardarJSON.Location = new Point(584, 77);
            btnGuardarJSON.Name = "btnGuardarJSON";
            btnGuardarJSON.Size = new Size(75, 23);
            btnGuardarJSON.TabIndex = 3;
            btnGuardarJSON.Text = "button2";
            btnGuardarJSON.UseVisualStyleBackColor = true;
            // 
            // btnCargarJSON
            // 
            btnCargarJSON.Location = new Point(505, 72);
            btnCargarJSON.Name = "btnCargarJSON";
            btnCargarJSON.Size = new Size(75, 23);
            btnCargarJSON.TabIndex = 4;
            btnCargarJSON.Text = "button3";
            btnCargarJSON.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(330, 64);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "button4";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(221, 68);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "button5";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "frmPrincipal";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnFiltrar;
        private Button btnEliminar;
        private Button btnCargarJSON;
        private Button btnGuardarJSON;
        private Button btnNuevo;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
    }
}
