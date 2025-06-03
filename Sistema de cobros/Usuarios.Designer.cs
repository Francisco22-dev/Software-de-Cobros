namespace Sistema_de_cobros
{
    partial class Usuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NombreU = new System.Windows.Forms.TextBox();
            this.NroDoc = new System.Windows.Forms.TextBox();
            this.Contraseña1 = new System.Windows.Forms.TextBox();
            this.Contraseña2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.GuardarUsuario = new FontAwesome.Sharp.IconButton();
            this.Editar = new FontAwesome.Sharp.IconButton();
            this.Delete = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboBuscarpor = new System.Windows.Forms.ComboBox();
            this.txtbus = new System.Windows.Forms.TextBox();
            this.Busqueda = new FontAwesome.Sharp.IconButton();
            this.Limpiar = new FontAwesome.Sharp.IconButton();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 451);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detalles del Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre del Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Número de Cédula:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contraseña:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Confirmar Contraseña:";
            // 
            // NombreU
            // 
            this.NombreU.Location = new System.Drawing.Point(12, 75);
            this.NombreU.Name = "NombreU";
            this.NombreU.Size = new System.Drawing.Size(259, 20);
            this.NombreU.TabIndex = 6;
            // 
            // NroDoc
            // 
            this.NroDoc.Location = new System.Drawing.Point(12, 121);
            this.NroDoc.Name = "NroDoc";
            this.NroDoc.Size = new System.Drawing.Size(259, 20);
            this.NroDoc.TabIndex = 7;
            // 
            // Contraseña1
            // 
            this.Contraseña1.Location = new System.Drawing.Point(12, 164);
            this.Contraseña1.Name = "Contraseña1";
            this.Contraseña1.PasswordChar = '*';
            this.Contraseña1.Size = new System.Drawing.Size(259, 20);
            this.Contraseña1.TabIndex = 8;
            // 
            // Contraseña2
            // 
            this.Contraseña2.Location = new System.Drawing.Point(12, 207);
            this.Contraseña2.Name = "Contraseña2";
            this.Contraseña2.PasswordChar = '*';
            this.Contraseña2.Size = new System.Drawing.Size(259, 20);
            this.Contraseña2.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Rol:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Estado:";
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(12, 247);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(259, 21);
            this.cboRol.TabIndex = 12;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(12, 293);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(259, 21);
            this.cboEstado.TabIndex = 13;
            // 
            // GuardarUsuario
            // 
            this.GuardarUsuario.BackColor = System.Drawing.Color.Green;
            this.GuardarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GuardarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.GuardarUsuario.FlatAppearance.BorderSize = 2;
            this.GuardarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuardarUsuario.ForeColor = System.Drawing.Color.White;
            this.GuardarUsuario.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            this.GuardarUsuario.IconColor = System.Drawing.Color.White;
            this.GuardarUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.GuardarUsuario.IconSize = 21;
            this.GuardarUsuario.Location = new System.Drawing.Point(12, 320);
            this.GuardarUsuario.Name = "GuardarUsuario";
            this.GuardarUsuario.Size = new System.Drawing.Size(259, 34);
            this.GuardarUsuario.TabIndex = 61;
            this.GuardarUsuario.Text = "Guardar";
            this.GuardarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GuardarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GuardarUsuario.UseVisualStyleBackColor = false;
            this.GuardarUsuario.Click += new System.EventHandler(this.GuardarUsuario_Click);
            // 
            // Editar
            // 
            this.Editar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Editar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Editar.FlatAppearance.BorderSize = 2;
            this.Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editar.ForeColor = System.Drawing.Color.White;
            this.Editar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.Editar.IconColor = System.Drawing.Color.White;
            this.Editar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Editar.IconSize = 21;
            this.Editar.Location = new System.Drawing.Point(12, 360);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(259, 34);
            this.Editar.TabIndex = 62;
            this.Editar.Text = "Limpiar";
            this.Editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Editar.UseVisualStyleBackColor = false;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Firebrick;
            this.Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Delete.FlatAppearance.BorderSize = 2;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.Delete.IconColor = System.Drawing.Color.White;
            this.Delete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Delete.IconSize = 21;
            this.Delete.Location = new System.Drawing.Point(12, 400);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(259, 34);
            this.Delete.TabIndex = 63;
            this.Delete.Text = "Eliminar";
            this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(316, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(619, 51);
            this.label9.TabIndex = 64;
            this.label9.Text = "Lista de Usuarios:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.idUsuario,
            this.NroDocumento,
            this.NombreCompleto,
            this.Clave,
            this.idRol,
            this.Rol,
            this.Estado,
            this.EstadoValor});
            this.dataGridView1.Location = new System.Drawing.Point(316, 75);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(619, 359);
            this.dataGridView1.TabIndex = 65;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(248, 52);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(23, 20);
            this.ID.TabIndex = 66;
            this.ID.Text = "0";
            this.ID.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(567, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Buscar por:";
            // 
            // cboBuscarpor
            // 
            this.cboBuscarpor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarpor.FormattingEnabled = true;
            this.cboBuscarpor.Location = new System.Drawing.Point(634, 49);
            this.cboBuscarpor.Name = "cboBuscarpor";
            this.cboBuscarpor.Size = new System.Drawing.Size(120, 21);
            this.cboBuscarpor.TabIndex = 68;
            // 
            // txtbus
            // 
            this.txtbus.Location = new System.Drawing.Point(760, 49);
            this.txtbus.Name = "txtbus";
            this.txtbus.Size = new System.Drawing.Size(111, 20);
            this.txtbus.TabIndex = 69;
            // 
            // Busqueda
            // 
            this.Busqueda.BackColor = System.Drawing.Color.White;
            this.Busqueda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Busqueda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.Busqueda.IconColor = System.Drawing.Color.Black;
            this.Busqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Busqueda.IconSize = 15;
            this.Busqueda.Location = new System.Drawing.Point(877, 49);
            this.Busqueda.Name = "Busqueda";
            this.Busqueda.Size = new System.Drawing.Size(23, 20);
            this.Busqueda.TabIndex = 71;
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
            this.Limpiar.Location = new System.Drawing.Point(906, 49);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(23, 20);
            this.Limpiar.TabIndex = 70;
            this.Limpiar.UseVisualStyleBackColor = false;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click_1);
            // 
            // txtindice
            // 
            this.txtindice.Location = new System.Drawing.Point(219, 52);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(23, 20);
            this.txtindice.TabIndex = 72;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 30;
            // 
            // idUsuario
            // 
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // NroDocumento
            // 
            this.NroDocumento.HeaderText = "Número de Cédula";
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.ReadOnly = true;
            this.NroDocumento.Width = 180;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre del Usuario";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 180;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Visible = false;
            // 
            // idRol
            // 
            this.idRol.HeaderText = "idRol";
            this.idRol.Name = "idRol";
            this.idRol.ReadOnly = true;
            this.idRol.Visible = false;
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.Busqueda);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.txtbus);
            this.Controls.Add(this.cboBuscarpor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.GuardarUsuario);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboRol);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Contraseña2);
            this.Controls.Add(this.Contraseña1);
            this.Controls.Add(this.NroDoc);
            this.Controls.Add(this.NombreU);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox NombreU;
        private System.Windows.Forms.TextBox NroDoc;
        private System.Windows.Forms.TextBox Contraseña1;
        private System.Windows.Forms.TextBox Contraseña2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.ComboBox cboEstado;
        private FontAwesome.Sharp.IconButton GuardarUsuario;
        private FontAwesome.Sharp.IconButton Editar;
        private FontAwesome.Sharp.IconButton Delete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboBuscarpor;
        private System.Windows.Forms.TextBox txtbus;
        private FontAwesome.Sharp.IconButton Busqueda;
        private FontAwesome.Sharp.IconButton Limpiar;
        private System.Windows.Forms.TextBox txtindice;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
    }
}