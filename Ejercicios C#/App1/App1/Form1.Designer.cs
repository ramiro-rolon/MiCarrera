namespace App1
{
    partial class frmEjercicio3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtGerente = new System.Windows.Forms.RadioButton();
            this.rbtSubGerente = new System.Windows.Forms.RadioButton();
            this.rbtSecretaria = new System.Windows.Forms.RadioButton();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Problema 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Salario:";
            // 
            // rbtGerente
            // 
            this.rbtGerente.AutoSize = true;
            this.rbtGerente.Location = new System.Drawing.Point(57, 238);
            this.rbtGerente.Name = "rbtGerente";
            this.rbtGerente.Size = new System.Drawing.Size(63, 17);
            this.rbtGerente.TabIndex = 3;
            this.rbtGerente.TabStop = true;
            this.rbtGerente.Text = "Gerente";
            this.rbtGerente.UseVisualStyleBackColor = true;
            // 
            // rbtSubGerente
            // 
            this.rbtSubGerente.AutoSize = true;
            this.rbtSubGerente.Location = new System.Drawing.Point(216, 238);
            this.rbtSubGerente.Name = "rbtSubGerente";
            this.rbtSubGerente.Size = new System.Drawing.Size(80, 17);
            this.rbtSubGerente.TabIndex = 4;
            this.rbtSubGerente.TabStop = true;
            this.rbtSubGerente.Text = "Subgerente";
            this.rbtSubGerente.UseVisualStyleBackColor = true;
            // 
            // rbtSecretaria
            // 
            this.rbtSecretaria.AutoSize = true;
            this.rbtSecretaria.Location = new System.Drawing.Point(365, 238);
            this.rbtSecretaria.Name = "rbtSecretaria";
            this.rbtSecretaria.Size = new System.Drawing.Size(73, 17);
            this.rbtSecretaria.TabIndex = 5;
            this.rbtSecretaria.TabStop = true;
            this.rbtSecretaria.Text = "Secretaria";
            this.rbtSecretaria.UseVisualStyleBackColor = true;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(87, 349);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(46, 25);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "holi";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(128, 135);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(94, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(365, 135);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(94, 20);
            this.txtSalario.TabIndex = 8;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(186, 310);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(149, 24);
            this.btnCalcular.TabIndex = 9;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // frmEjercicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(514, 472);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.rbtSecretaria);
            this.Controls.Add(this.rbtSubGerente);
            this.Controls.Add(this.rbtGerente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEjercicio3";
            this.Text = "Ejercicio 3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtGerente;
        private System.Windows.Forms.RadioButton rbtSubGerente;
        private System.Windows.Forms.RadioButton rbtSecretaria;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Button btnCalcular;
    }
}

