namespace Sistema_de_cobros
{
    partial class DatosEstudiantes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.Busqueda = new FontAwesome.Sharp.IconButton();
            this.Limpiar = new FontAwesome.Sharp.IconButton();
            this.dgvEstu = new System.Windows.Forms.DataGridView();
            this.Borrar = new FontAwesome.Sharp.IconButton();
            this.idEstudiantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(918, 89);
            this.label1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Datos de los Estudiantes";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(918, 320);
            this.label3.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(590, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Buscar Cédula:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(675, 136);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(174, 20);
            this.txtCedula.TabIndex = 24;
            // 
            // Busqueda
            // 
            this.Busqueda.BackColor = System.Drawing.Color.White;
            this.Busqueda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Busqueda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.Busqueda.IconColor = System.Drawing.Color.Black;
            this.Busqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Busqueda.IconSize = 15;
            this.Busqueda.Location = new System.Drawing.Point(855, 136);
            this.Busqueda.Name = "Busqueda";
            this.Busqueda.Size = new System.Drawing.Size(23, 20);
            this.Busqueda.TabIndex = 25;
            this.Busqueda.UseVisualStyleBackColor = false;
            this.Busqueda.Click += new System.EventHandler(this.Busqueda_Click);
            // 
            // Limpiar
            // 
            this.Limpiar.BackColor = System.Drawing.Color.White;
            this.Limpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Limpiar.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.Limpiar.IconColor = System.Drawing.Color.Black;
            this.Limpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Limpiar.IconSize = 15;
            this.Limpiar.Location = new System.Drawing.Point(884, 136);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(23, 20);
            this.Limpiar.TabIndex = 23;
            this.Limpiar.UseVisualStyleBackColor = false;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // dgvEstu
            // 
            this.dgvEstu.AllowUserToAddRows = false;
            this.dgvEstu.AllowUserToOrderColumns = true;
            this.dgvEstu.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEstudiantes,
            this.Cedula,
            this.NombreCompleto,
            this.Telefono});
            this.dgvEstu.Location = new System.Drawing.Point(40, 162);
            this.dgvEstu.Name = "dgvEstu";
            this.dgvEstu.Size = new System.Drawing.Size(863, 251);
            this.dgvEstu.TabIndex = 27;
            // 
            // Borrar
            // 
            this.Borrar.BackColor = System.Drawing.Color.Firebrick;
            this.Borrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Borrar.FlatAppearance.BorderSize = 2;
            this.Borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Borrar.ForeColor = System.Drawing.Color.White;
            this.Borrar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.Borrar.IconColor = System.Drawing.Color.White;
            this.Borrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Borrar.IconSize = 15;
            this.Borrar.Location = new System.Drawing.Point(40, 126);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(150, 30);
            this.Borrar.TabIndex = 28;
            this.Borrar.Text = "Eliminar";
            this.Borrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Borrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Borrar.UseVisualStyleBackColor = false;
            this.Borrar.Click += new System.EventHandler(this.Borrar_Click);
            // 
            // idEstudiantes
            // 
            this.idEstudiantes.HeaderText = "idEstudiantes";
            this.idEstudiantes.Name = "idEstudiantes";
            this.idEstudiantes.Visible = false;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cédula";
            this.Cedula.Name = "Cedula";
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.Width = 200;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            // 
            // DatosEstudiantes
            // 
            this.AcceptButton = this.Busqueda;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.Borrar);
            this.Controls.Add(this.dgvEstu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Busqueda);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatosEstudiantes";
            this.Text = "DatosEstudiantes";
            this.Load += new System.EventHandler(this.DatosEstudiantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton Busqueda;
        private System.Windows.Forms.TextBox txtCedula;
        private FontAwesome.Sharp.IconButton Limpiar;
        private System.Windows.Forms.DataGridView dgvEstu;
        private FontAwesome.Sharp.IconButton Borrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstudiantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
    }
}