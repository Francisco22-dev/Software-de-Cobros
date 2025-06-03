namespace Sistema_de_cobros
{
    partial class Uniformesdgv
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
            this.Borrar = new FontAwesome.Sharp.IconButton();
            this.dgvUni = new System.Windows.Forms.DataGridView();
            this.idEstudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.Busqueda = new FontAwesome.Sharp.IconButton();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.Limpiar = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUni)).BeginInit();
            this.SuspendLayout();
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
            this.Borrar.Location = new System.Drawing.Point(40, 132);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(150, 30);
            this.Borrar.TabIndex = 37;
            this.Borrar.Text = "Eliminar";
            this.Borrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Borrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Borrar.UseVisualStyleBackColor = false;
            this.Borrar.Visible = false;
            this.Borrar.Click += new System.EventHandler(this.Borrar_Click);
            // 
            // dgvUni
            // 
            this.dgvUni.AllowUserToAddRows = false;
            this.dgvUni.AllowUserToDeleteRows = false;
            this.dgvUni.AllowUserToOrderColumns = true;
            this.dgvUni.BackgroundColor = System.Drawing.Color.White;
            this.dgvUni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEstudiante,
            this.FechaRegistro,
            this.Cedula,
            this.NombreCompleto,
            this.Curso,
            this.Total,
            this.TipoPago,
            this.Concepto,
            this.Banco,
            this.Referencia,
            this.Recibo,
            this.Estado});
            this.dgvUni.Location = new System.Drawing.Point(40, 168);
            this.dgvUni.Name = "dgvUni";
            this.dgvUni.ReadOnly = true;
            this.dgvUni.Size = new System.Drawing.Size(863, 251);
            this.dgvUni.TabIndex = 36;
            // 
            // idEstudiante
            // 
            this.idEstudiante.HeaderText = "idEstudiantes";
            this.idEstudiante.Name = "idEstudiante";
            this.idEstudiante.ReadOnly = true;
            this.idEstudiante.Visible = false;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha de Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cédula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 200;
            // 
            // Curso
            // 
            this.Curso.HeaderText = "Curso";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Monto";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // TipoPago
            // 
            this.TipoPago.HeaderText = "Tipo de Pago";
            this.TipoPago.Name = "TipoPago";
            this.TipoPago.ReadOnly = true;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Visible = false;
            // 
            // Banco
            // 
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            this.Banco.ReadOnly = true;
            // 
            // Referencia
            // 
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            // 
            // Recibo
            // 
            this.Recibo.HeaderText = "Número de recibo";
            this.Recibo.Name = "Recibo";
            this.Recibo.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(590, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Buscar Cédula:";
            // 
            // Busqueda
            // 
            this.Busqueda.BackColor = System.Drawing.Color.White;
            this.Busqueda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Busqueda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.Busqueda.IconColor = System.Drawing.Color.Black;
            this.Busqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Busqueda.IconSize = 15;
            this.Busqueda.Location = new System.Drawing.Point(855, 142);
            this.Busqueda.Name = "Busqueda";
            this.Busqueda.Size = new System.Drawing.Size(23, 20);
            this.Busqueda.TabIndex = 34;
            this.Busqueda.UseVisualStyleBackColor = false;
            this.Busqueda.Click += new System.EventHandler(this.Busqueda_Click);
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(675, 142);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(174, 20);
            this.txtCedula.TabIndex = 33;
            // 
            // Limpiar
            // 
            this.Limpiar.BackColor = System.Drawing.Color.White;
            this.Limpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Limpiar.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.Limpiar.IconColor = System.Drawing.Color.Black;
            this.Limpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Limpiar.IconSize = 15;
            this.Limpiar.Location = new System.Drawing.Point(884, 142);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(23, 20);
            this.Limpiar.TabIndex = 32;
            this.Limpiar.UseVisualStyleBackColor = false;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(918, 320);
            this.label3.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Uniformes";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(918, 89);
            this.label1.TabIndex = 29;
            // 
            // Uniformesdgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.Borrar);
            this.Controls.Add(this.dgvUni);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Busqueda);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Uniformesdgv";
            this.Text = "Uniformesdgv";
            this.Load += new System.EventHandler(this.Uniformesdgv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton Borrar;
        private System.Windows.Forms.DataGridView dgvUni;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton Busqueda;
        private System.Windows.Forms.TextBox txtCedula;
        private FontAwesome.Sharp.IconButton Limpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}