using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentación;
using FontAwesome.Sharp;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_de_cobros
{
    //Sistema creado por: Francisco Serrano.
    //Si estás leyendo esto... no deberías estar aquí.
    public partial class Sistema_de_Cobros: Form
    {
        public static Usuario UsuarioActivo;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Sistema_de_Cobros(Usuario objcdusuario)
        {
            UsuarioActivo = objcdusuario;
            InitializeComponent();
        }

        private void Sistema_de_Cobros_Load(object sender, EventArgs e)
        {
            List<Permiso> Listapermisos = new CN_Permiso().Listar(UsuarioActivo.idUsuario);

            foreach (IconMenuItem iconMenu in menuStrip1.Items)
            {
                bool tienePermiso = Listapermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if (tienePermiso == false)
                {
                    iconMenu.Visible = false;
                }
            }
        }

        private void AbrirFormulario(IconMenuItem menu, Form Formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = Formulario;
            Formulario.TopLevel = false;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Dock = DockStyle.Fill;
            Formulario.BackColor = Color.Silver;
            Contenedor.Controls.Add(Formulario);
            Formulario.Show();
            
        }

        private void Registros_Click(object sender, EventArgs e)
        {
            
        }

        private void Inscripciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new Inscripciones());
        }

        private void registrosDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Registros, new Registros());
        }

        private void datosDeEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Registros, new DatosEstudiantes());
        }

        private void Pagos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Pagos, new RegistroPagos());
        }

        private void Uniformes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Uniformes, new RegisUni());
        }

        private void Uniform_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Uniform, new Uniformesdgv());
        }

        private void Corte_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Corte, new CorteD());
        }

        private void Funciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Funciones, new FuncionesADMIN());
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Usuarios, new Usuarios());
        }

        private void ingresarEstudiantesViejosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Inscripciones, new Estudiantes_Viejos());
        }

        private void datosDeEstudiantesAntiguosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Registros, new Datos_Estudiantes_Viejos());
        }

        private void Graficas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Graficas, new Grafica());
        }
    }
}
