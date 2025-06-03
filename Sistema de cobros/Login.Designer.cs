namespace Sistema_de_cobros
{
    partial class Login
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
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btningresar = new FontAwesome.Sharp.IconButton();
            this.Btncancelar = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.NroDocumento = new System.Windows.Forms.TextBox();
            this.panelLicencia = new System.Windows.Forms.Panel();
            this.btnValidarLicencia = new System.Windows.Forms.Button();
            this.txtCodigoLicencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLicencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 209);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(228, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sistema de Cobros";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(232, 125);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(182, 20);
            this.txtClave.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(229, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contraseña:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Sistema_de_cobros.Properties.Resources.Logo_de_Cevenca;
            this.pictureBox1.Location = new System.Drawing.Point(30, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btningresar
            // 
            this.btningresar.BackColor = System.Drawing.Color.Navy;
            this.btningresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btningresar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btningresar.FlatAppearance.BorderSize = 2;
            this.btningresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btningresar.ForeColor = System.Drawing.Color.White;
            this.btningresar.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btningresar.IconColor = System.Drawing.Color.White;
            this.btningresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btningresar.IconSize = 21;
            this.btningresar.Location = new System.Drawing.Point(232, 151);
            this.btningresar.Name = "btningresar";
            this.btningresar.Size = new System.Drawing.Size(86, 36);
            this.btningresar.TabIndex = 9;
            this.btningresar.Text = "Ingresar";
            this.btningresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btningresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btningresar.UseVisualStyleBackColor = false;
            this.btningresar.Click += new System.EventHandler(this.btningresar_Click);
            // 
            // Btncancelar
            // 
            this.Btncancelar.BackColor = System.Drawing.Color.Firebrick;
            this.Btncancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btncancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btncancelar.FlatAppearance.BorderSize = 2;
            this.Btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btncancelar.ForeColor = System.Drawing.Color.White;
            this.Btncancelar.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.Btncancelar.IconColor = System.Drawing.Color.White;
            this.Btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btncancelar.IconSize = 21;
            this.Btncancelar.Location = new System.Drawing.Point(339, 151);
            this.Btncancelar.Name = "Btncancelar";
            this.Btncancelar.Size = new System.Drawing.Size(91, 36);
            this.Btncancelar.TabIndex = 10;
            this.Btncancelar.Text = "Cancelar";
            this.Btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btncancelar.UseVisualStyleBackColor = false;
            this.Btncancelar.Click += new System.EventHandler(this.Btncancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(229, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nro de Documento:";
            // 
            // NroDocumento
            // 
            this.NroDocumento.Location = new System.Drawing.Point(232, 75);
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.PasswordChar = '*';
            this.NroDocumento.Size = new System.Drawing.Size(182, 20);
            this.NroDocumento.TabIndex = 12;
            // 
            // panelLicencia
            // 
            this.panelLicencia.Controls.Add(this.btnValidarLicencia);
            this.panelLicencia.Controls.Add(this.txtCodigoLicencia);
            this.panelLicencia.Controls.Add(this.label5);
            this.panelLicencia.Location = new System.Drawing.Point(139, 48);
            this.panelLicencia.Name = "panelLicencia";
            this.panelLicencia.Size = new System.Drawing.Size(200, 100);
            this.panelLicencia.TabIndex = 13;
            this.panelLicencia.Visible = false;
            this.panelLicencia.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLicencia_Paint);
            // 
            // btnValidarLicencia
            // 
            this.btnValidarLicencia.Location = new System.Drawing.Point(58, 68);
            this.btnValidarLicencia.Name = "btnValidarLicencia";
            this.btnValidarLicencia.Size = new System.Drawing.Size(75, 23);
            this.btnValidarLicencia.TabIndex = 2;
            this.btnValidarLicencia.Text = "Validar";
            this.btnValidarLicencia.UseVisualStyleBackColor = true;
            this.btnValidarLicencia.Click += new System.EventHandler(this.btnValidarLicencia_Click);
            // 
            // txtCodigoLicencia
            // 
            this.txtCodigoLicencia.Location = new System.Drawing.Point(22, 42);
            this.txtCodigoLicencia.Name = "txtCodigoLicencia";
            this.txtCodigoLicencia.Size = new System.Drawing.Size(152, 20);
            this.txtCodigoLicencia.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "El programa necesita mantenimiento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AcceptButton = this.btningresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.CancelButton = this.Btncancelar;
            this.ClientSize = new System.Drawing.Size(480, 209);
            this.Controls.Add(this.panelLicencia);
            this.Controls.Add(this.NroDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btncancelar);
            this.Controls.Add(this.btningresar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLicencia.ResumeLayout(false);
            this.panelLicencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btningresar;
        private FontAwesome.Sharp.IconButton Btncancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NroDocumento;
        private System.Windows.Forms.Panel panelLicencia;
        private System.Windows.Forms.TextBox txtCodigoLicencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnValidarLicencia;
    }
}