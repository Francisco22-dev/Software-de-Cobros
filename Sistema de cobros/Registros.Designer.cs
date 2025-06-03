namespace Sistema_de_cobros
{
    partial class Registros
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
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.FechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCursos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Busqueda = new FontAwesome.Sharp.IconButton();
            this.Limpiar = new FontAwesome.Sharp.IconButton();
            this.Buscar = new FontAwesome.Sharp.IconButton();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Día = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(918, 89);
            this.label1.TabIndex = 8;
            // 
            // FechaInicio
            // 
            this.FechaInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FechaInicio.CustomFormat = "DD/MM/YYYY";
            this.FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicio.Location = new System.Drawing.Point(126, 56);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(95, 20);
            this.FechaInicio.TabIndex = 9;
            this.FechaInicio.Value = new System.DateTime(2024, 9, 1, 0, 0, 0, 0);
            // 
            // FechaFin
            // 
            this.FechaFin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FechaFin.CustomFormat = "DD/MM/YYYY";
            this.FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFin.Location = new System.Drawing.Point(326, 56);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(95, 20);
            this.FechaFin.TabIndex = 9;
            this.FechaFin.Value = new System.DateTime(2025, 3, 10, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Registros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(37, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha de Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(247, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha Actual:";
            // 
            // cboCursos
            // 
            this.cboCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCursos.FormattingEnabled = true;
            this.cboCursos.Location = new System.Drawing.Point(500, 56);
            this.cboCursos.Name = "cboCursos";
            this.cboCursos.Size = new System.Drawing.Size(200, 21);
            this.cboCursos.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(457, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Curso:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(13, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(915, 312);
            this.label6.TabIndex = 17;
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.AllowUserToOrderColumns = true;
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaRegistro,
            this.Cedula,
            this.NombreCompleto,
            this.Curso,
            this.Horario,
            this.Día,
            this.MontoTotal,
            this.TipoPago,
            this.Concepto,
            this.Banco,
            this.Referencia,
            this.Estado,
            this.NumeroClase,
            this.Recibo,
            this.FechaVencimiento});
            this.dgvRegistros.Location = new System.Drawing.Point(40, 148);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.Size = new System.Drawing.Size(863, 261);
            this.dgvRegistros.TabIndex = 18;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(665, 122);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(174, 20);
            this.txtCedula.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(580, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 22;
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
            this.Busqueda.Location = new System.Drawing.Point(845, 122);
            this.Busqueda.Name = "Busqueda";
            this.Busqueda.Size = new System.Drawing.Size(23, 20);
            this.Busqueda.TabIndex = 21;
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
            this.Limpiar.Location = new System.Drawing.Point(874, 122);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(23, 20);
            this.Limpiar.TabIndex = 19;
            this.Limpiar.UseVisualStyleBackColor = false;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Buscar
            // 
            this.Buscar.BackColor = System.Drawing.Color.White;
            this.Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Buscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Buscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.Buscar.IconColor = System.Drawing.Color.Black;
            this.Buscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Buscar.IconSize = 15;
            this.Buscar.Location = new System.Drawing.Point(706, 57);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(69, 20);
            this.Buscar.TabIndex = 16;
            this.Buscar.Text = "Buscar";
            this.Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Buscar.UseVisualStyleBackColor = false;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
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
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            // 
            // Curso
            // 
            this.Curso.HeaderText = "Curso";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            this.Curso.Visible = false;
            // 
            // Horario
            // 
            this.Horario.HeaderText = "Horario";
            this.Horario.Name = "Horario";
            this.Horario.ReadOnly = true;
            // 
            // Día
            // 
            this.Día.HeaderText = "Día";
            this.Día.Name = "Día";
            this.Día.ReadOnly = true;
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "MontoTotal";
            this.MontoTotal.Name = "MontoTotal";
            this.MontoTotal.ReadOnly = true;
            // 
            // TipoPago
            // 
            this.TipoPago.HeaderText = "TipoPago";
            this.TipoPago.Name = "TipoPago";
            this.TipoPago.ReadOnly = true;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
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
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // NumeroClase
            // 
            this.NumeroClase.HeaderText = "Número de la clase";
            this.NumeroClase.Name = "NumeroClase";
            this.NumeroClase.ReadOnly = true;
            // 
            // Recibo
            // 
            this.Recibo.HeaderText = "Número de recibo";
            this.Recibo.Name = "Recibo";
            this.Recibo.ReadOnly = true;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "Fecha de Pago";
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            // 
            // Registros
            // 
            this.AcceptButton = this.Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Limpiar;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Busqueda);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCursos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.FechaInicio);
            this.Controls.Add(this.label1);
            this.Name = "Registros";
            this.Text = "Registros";
            this.Load += new System.EventHandler(this.Registros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.DateTimePicker FechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCursos;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton Buscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private FontAwesome.Sharp.IconButton Limpiar;
        private System.Windows.Forms.TextBox txtCedula;
        private FontAwesome.Sharp.IconButton Busqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Día;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
    }
}