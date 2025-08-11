namespace Sistema_de_cobros
{
    partial class Sistema_de_Cobros
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.Título = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Usuarios = new FontAwesome.Sharp.IconMenuItem();
            this.Inscripciones = new FontAwesome.Sharp.IconMenuItem();
            this.ingresarEstudiantesViejos = new System.Windows.Forms.ToolStripMenuItem();
            this.Pagos = new FontAwesome.Sharp.IconMenuItem();
            this.Uniformes = new FontAwesome.Sharp.IconMenuItem();
            this.Registros = new FontAwesome.Sharp.IconMenuItem();
            this.registrosDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosDeEstudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Uniform = new FontAwesome.Sharp.IconMenuItem();
            this.datosDeEstudiantesAntiguosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Corte = new FontAwesome.Sharp.IconMenuItem();
            this.Funciones = new FontAwesome.Sharp.IconMenuItem();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Graficas = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(943, 61);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // Título
            // 
            this.Título.AutoSize = true;
            this.Título.BackColor = System.Drawing.Color.DodgerBlue;
            this.Título.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Título.ForeColor = System.Drawing.Color.White;
            this.Título.Location = new System.Drawing.Point(31, 18);
            this.Título.Name = "Título";
            this.Título.Size = new System.Drawing.Size(270, 30);
            this.Título.TabIndex = 2;
            this.Título.Text = "Sistema de Cobros";
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 134);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(943, 447);
            this.Contenedor.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Usuarios,
            this.Inscripciones,
            this.Pagos,
            this.Uniformes,
            this.Registros,
            this.Corte,
            this.Graficas,
            this.Funciones});
            this.menuStrip1.Location = new System.Drawing.Point(0, 61);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 73);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Usuarios
            // 
            this.Usuarios.AutoSize = false;
            this.Usuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.Usuarios.IconColor = System.Drawing.Color.Black;
            this.Usuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Usuarios.IconSize = 50;
            this.Usuarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Usuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(80, 69);
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // Inscripciones
            // 
            this.Inscripciones.AutoSize = false;
            this.Inscripciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarEstudiantesViejos});
            this.Inscripciones.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.Inscripciones.IconColor = System.Drawing.Color.Black;
            this.Inscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Inscripciones.IconSize = 50;
            this.Inscripciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Inscripciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Inscripciones.Name = "Inscripciones";
            this.Inscripciones.Size = new System.Drawing.Size(80, 69);
            this.Inscripciones.Text = "Inscripciones";
            this.Inscripciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Inscripciones.Click += new System.EventHandler(this.Inscripciones_Click);
            // 
            // ingresarEstudiantesViejos
            // 
            this.ingresarEstudiantesViejos.Name = "ingresarEstudiantesViejos";
            this.ingresarEstudiantesViejos.Size = new System.Drawing.Size(212, 22);
            this.ingresarEstudiantesViejos.Text = "Ingresar estudiantes viejos";
            this.ingresarEstudiantesViejos.Click += new System.EventHandler(this.ingresarEstudiantesViejosToolStripMenuItem_Click);
            // 
            // Pagos
            // 
            this.Pagos.AutoSize = false;
            this.Pagos.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.Pagos.IconColor = System.Drawing.Color.Black;
            this.Pagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Pagos.IconSize = 50;
            this.Pagos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Pagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Pagos.Name = "Pagos";
            this.Pagos.Size = new System.Drawing.Size(122, 69);
            this.Pagos.Text = "Registro de pagos";
            this.Pagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Pagos.Click += new System.EventHandler(this.Pagos_Click);
            // 
            // Uniformes
            // 
            this.Uniformes.AutoSize = false;
            this.Uniformes.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.Uniformes.IconColor = System.Drawing.Color.Black;
            this.Uniformes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Uniformes.IconSize = 50;
            this.Uniformes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Uniformes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Uniformes.Name = "Uniformes";
            this.Uniformes.Size = new System.Drawing.Size(122, 69);
            this.Uniformes.Text = "Registro de Uniformes";
            this.Uniformes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Uniformes.Click += new System.EventHandler(this.Uniformes_Click);
            // 
            // Registros
            // 
            this.Registros.AutoSize = false;
            this.Registros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrosDePagosToolStripMenuItem,
            this.datosDeEstudiantesToolStripMenuItem,
            this.Uniform,
            this.datosDeEstudiantesAntiguosToolStripMenuItem});
            this.Registros.IconChar = FontAwesome.Sharp.IconChar.CircleDollarToSlot;
            this.Registros.IconColor = System.Drawing.Color.Black;
            this.Registros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Registros.IconSize = 50;
            this.Registros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Registros.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Registros.Name = "Registros";
            this.Registros.Size = new System.Drawing.Size(80, 69);
            this.Registros.Text = "Registros";
            this.Registros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Registros.Click += new System.EventHandler(this.Registros_Click);
            // 
            // registrosDePagosToolStripMenuItem
            // 
            this.registrosDePagosToolStripMenuItem.Name = "registrosDePagosToolStripMenuItem";
            this.registrosDePagosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.registrosDePagosToolStripMenuItem.Text = "Registros de pagos";
            this.registrosDePagosToolStripMenuItem.Click += new System.EventHandler(this.registrosDePagosToolStripMenuItem_Click);
            // 
            // datosDeEstudiantesToolStripMenuItem
            // 
            this.datosDeEstudiantesToolStripMenuItem.Name = "datosDeEstudiantesToolStripMenuItem";
            this.datosDeEstudiantesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.datosDeEstudiantesToolStripMenuItem.Text = "Datos de estudiantes";
            this.datosDeEstudiantesToolStripMenuItem.Click += new System.EventHandler(this.datosDeEstudiantesToolStripMenuItem_Click);
            // 
            // Uniform
            // 
            this.Uniform.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Uniform.IconColor = System.Drawing.Color.Black;
            this.Uniform.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Uniform.Name = "Uniform";
            this.Uniform.Size = new System.Drawing.Size(232, 22);
            this.Uniform.Text = "Uniformes";
            this.Uniform.Click += new System.EventHandler(this.Uniform_Click);
            // 
            // datosDeEstudiantesAntiguosToolStripMenuItem
            // 
            this.datosDeEstudiantesAntiguosToolStripMenuItem.Name = "datosDeEstudiantesAntiguosToolStripMenuItem";
            this.datosDeEstudiantesAntiguosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.datosDeEstudiantesAntiguosToolStripMenuItem.Text = "Datos de estudiantes antiguos";
            this.datosDeEstudiantesAntiguosToolStripMenuItem.Click += new System.EventHandler(this.datosDeEstudiantesAntiguosToolStripMenuItem_Click);
            // 
            // Corte
            // 
            this.Corte.AutoSize = false;
            this.Corte.IconChar = FontAwesome.Sharp.IconChar.StackOverflow;
            this.Corte.IconColor = System.Drawing.Color.Black;
            this.Corte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Corte.IconSize = 50;
            this.Corte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Corte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Corte.Name = "Corte";
            this.Corte.Size = new System.Drawing.Size(80, 69);
            this.Corte.Text = "Corte Diario";
            this.Corte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Corte.Click += new System.EventHandler(this.Corte_Click);
            // 
            // Funciones
            // 
            this.Funciones.AutoSize = false;
            this.Funciones.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.Funciones.IconColor = System.Drawing.Color.Black;
            this.Funciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Funciones.IconSize = 50;
            this.Funciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Funciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Funciones.Name = "Funciones";
            this.Funciones.Size = new System.Drawing.Size(80, 69);
            this.Funciones.Text = "Funciones";
            this.Funciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Funciones.Click += new System.EventHandler(this.Funciones_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.White;
            this.Logo.Image = global::Sistema_de_cobros.Properties.Resources.Logo_de_Cevenca;
            this.Logo.Location = new System.Drawing.Point(860, 61);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(83, 73);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 4;
            this.Logo.TabStop = false;
            // 
            // Graficas
            // 
            this.Graficas.AutoSize = false;
            this.Graficas.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.Graficas.IconColor = System.Drawing.Color.Black;
            this.Graficas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Graficas.IconSize = 50;
            this.Graficas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Graficas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Graficas.Name = "Graficas";
            this.Graficas.Size = new System.Drawing.Size(80, 69);
            this.Graficas.Text = "Gráfica";
            this.Graficas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Graficas.Click += new System.EventHandler(this.Graficas_Click);
            // 
            // Sistema_de_Cobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 581);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.Título);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sistema_de_Cobros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema_de_Cobros";
            this.Load += new System.EventHandler(this.Sistema_de_Cobros_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label Título;
        private System.Windows.Forms.Panel Contenedor;
        private FontAwesome.Sharp.IconMenuItem Registros;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox Logo;
        private FontAwesome.Sharp.IconMenuItem Inscripciones;
        private System.Windows.Forms.ToolStripMenuItem registrosDePagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosDeEstudiantesToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem Pagos;
        private FontAwesome.Sharp.IconMenuItem Uniformes;
        private FontAwesome.Sharp.IconMenuItem Uniform;
        private FontAwesome.Sharp.IconMenuItem Corte;
        private FontAwesome.Sharp.IconMenuItem Funciones;
        private FontAwesome.Sharp.IconMenuItem Usuarios;
        private System.Windows.Forms.ToolStripMenuItem ingresarEstudiantesViejos;
        private System.Windows.Forms.ToolStripMenuItem datosDeEstudiantesAntiguosToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem Graficas;
    }
}

