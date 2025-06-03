namespace Sistema_de_cobros
{
    partial class FuncionesADMIN
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Duracion = new System.Windows.Forms.TextBox();
            this.NombreCurso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GuardarCurso = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCursos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreEdi = new System.Windows.Forms.TextBox();
            this.txtDuracionEdi = new System.Windows.Forms.TextBox();
            this.GuardarEdi = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Duracion);
            this.groupBox1.Controls.Add(this.NombreCurso);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevos Cursos";
            // 
            // Duracion
            // 
            this.Duracion.Location = new System.Drawing.Point(166, 46);
            this.Duracion.Name = "Duracion";
            this.Duracion.Size = new System.Drawing.Size(122, 20);
            this.Duracion.TabIndex = 3;
            this.Duracion.Text = "(Ejemplo: 3)";
            // 
            // NombreCurso
            // 
            this.NombreCurso.Location = new System.Drawing.Point(10, 46);
            this.NombreCurso.Name = "NombreCurso";
            this.NombreCurso.Size = new System.Drawing.Size(122, 20);
            this.NombreCurso.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Duración del Curso (En Meses):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Curso:";
            // 
            // GuardarCurso
            // 
            this.GuardarCurso.BackColor = System.Drawing.Color.Green;
            this.GuardarCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GuardarCurso.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.GuardarCurso.FlatAppearance.BorderSize = 2;
            this.GuardarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuardarCurso.ForeColor = System.Drawing.Color.White;
            this.GuardarCurso.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            this.GuardarCurso.IconColor = System.Drawing.Color.White;
            this.GuardarCurso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.GuardarCurso.IconSize = 21;
            this.GuardarCurso.Location = new System.Drawing.Point(99, 98);
            this.GuardarCurso.Name = "GuardarCurso";
            this.GuardarCurso.Size = new System.Drawing.Size(157, 34);
            this.GuardarCurso.TabIndex = 60;
            this.GuardarCurso.Text = "Guardar";
            this.GuardarCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GuardarCurso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GuardarCurso.UseVisualStyleBackColor = false;
            this.GuardarCurso.Click += new System.EventHandler(this.GuardarCurso_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDuracionEdi);
            this.groupBox2.Controls.Add(this.txtNombreEdi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboCursos);
            this.groupBox2.Location = new System.Drawing.Point(397, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 100);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edición de cursos";
            // 
            // cboCursos
            // 
            this.cboCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCursos.FormattingEnabled = true;
            this.cboCursos.Location = new System.Drawing.Point(6, 20);
            this.cboCursos.Name = "cboCursos";
            this.cboCursos.Size = new System.Drawing.Size(201, 21);
            this.cboCursos.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre del Curso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Duración del Curso (En Meses):";
            // 
            // txtNombreEdi
            // 
            this.txtNombreEdi.Location = new System.Drawing.Point(9, 60);
            this.txtNombreEdi.Name = "txtNombreEdi";
            this.txtNombreEdi.Size = new System.Drawing.Size(122, 20);
            this.txtNombreEdi.TabIndex = 4;
            // 
            // txtDuracionEdi
            // 
            this.txtDuracionEdi.Location = new System.Drawing.Point(178, 60);
            this.txtDuracionEdi.Name = "txtDuracionEdi";
            this.txtDuracionEdi.Size = new System.Drawing.Size(122, 20);
            this.txtDuracionEdi.TabIndex = 5;
            // 
            // GuardarEdi
            // 
            this.GuardarEdi.BackColor = System.Drawing.Color.Green;
            this.GuardarEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GuardarEdi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.GuardarEdi.FlatAppearance.BorderSize = 2;
            this.GuardarEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuardarEdi.ForeColor = System.Drawing.Color.White;
            this.GuardarEdi.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            this.GuardarEdi.IconColor = System.Drawing.Color.White;
            this.GuardarEdi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.GuardarEdi.IconSize = 21;
            this.GuardarEdi.Location = new System.Drawing.Point(490, 118);
            this.GuardarEdi.Name = "GuardarEdi";
            this.GuardarEdi.Size = new System.Drawing.Size(157, 34);
            this.GuardarEdi.TabIndex = 62;
            this.GuardarEdi.Text = "Guardar";
            this.GuardarEdi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GuardarEdi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GuardarEdi.UseVisualStyleBackColor = false;
            this.GuardarEdi.Click += new System.EventHandler(this.GuardarEdi_Click);
            // 
            // FuncionesADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.GuardarEdi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GuardarCurso);
            this.Controls.Add(this.groupBox1);
            this.Name = "FuncionesADMIN";
            this.Text = "FuncionesADMIN";
            this.Load += new System.EventHandler(this.FuncionesADMIN_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Duracion;
        private System.Windows.Forms.TextBox NombreCurso;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton GuardarCurso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCursos;
        private System.Windows.Forms.TextBox txtDuracionEdi;
        private System.Windows.Forms.TextBox txtNombreEdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton GuardarEdi;
    }
}