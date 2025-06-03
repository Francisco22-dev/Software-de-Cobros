using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using CapaDatos;

namespace Sistema_de_cobros
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

             LicenseManager_CN licenseManager = new LicenseManager_CN();

             if (!licenseManager.IsLicenseValid())
             {
                DeshabilitarControlesDeLogin();
            // Si la licencia ha expirado, solicita la combinación
                panelLicencia.Visible = true;

             }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (!ValidarTextBox())
            {
                return;
            }
            List<Usuario> TEST = new CNUsuario().Listar();



            Usuario ousuario = new CNUsuario().Listar().Where(u => u.Clave == txtClave.Text && u.NroDocumento == NroDocumento.Text && u.Estado).FirstOrDefault();

            if (ousuario == null)
            {
                MessageBox.Show("Clave inválida o Nro de Documento inválido, ingrese nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ousuario != null)
            {
                Sistema_de_Cobros form = new Sistema_de_Cobros(ousuario);
                form.Show();
                this.Hide();
                form.FormClosing += Form_FormClosing;
            }

        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtClave.Text = "";
            NroDocumento.Text = "";
            NroDocumento.Select();
            this.Show();
        }


        private bool ValidarTextBox()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { txtClave, NroDocumento };

            // Verificar cada TextBox
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Si algún TextBox está vacío, mostramos un mensaje y retornamos falso
                    MessageBox.Show("Por favor, ingrese la clave y/o Nro de Documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Si todos los TextBox tienen contenido, retornamos verdadero
            return true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            NroDocumento.Select();
        }

        private void HabilitarControlesDeLogin()
        {
          foreach (Control control in this.Controls)
          {
          control.Enabled = true;
        }
        }

        private void panelLicencia_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnValidarLicencia_Click(object sender, EventArgs e)
        {
            LicenseManager_CN licenseManager = new LicenseManager_CN();
            string inputCode = txtCodigoLicencia.Text;
            //Asegurarse de que se ingresó algo
            if (string.IsNullOrEmpty(inputCode))
            {
                MessageBox.Show("Debes ingresar la combinación de limpiesa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (licenseManager.ValidateLicenseCode(inputCode))
            {
           // Actualiza la fecha de desbloqueo para extender la vigencia un mes
                licenseManager.UpdateUnlockDate(DateTime.Now);
             MessageBox.Show("Código validado. La aplicación vuelve a estar funcional.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
             panelLicencia.Visible = false;
             HabilitarControlesDeLogin();
            }
            else
            {
             MessageBox.Show("El código ingresado es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // Se puede dar la opción de reintentar o salir de la aplicación.
            }

        }
        private void DeshabilitarControlesDeLogin()
        {
            foreach (Control control in this.Controls)
            {
                // Excluye el panel de licencia para que permanezca interactivo
                if (control != panelLicencia)
                {
                    control.Enabled = false;
                }
            }
        }
        
    }
}
