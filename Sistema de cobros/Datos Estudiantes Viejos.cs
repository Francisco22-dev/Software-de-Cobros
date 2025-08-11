using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_cobros
{
    public partial class Datos_Estudiantes_Viejos: Form
    {
        public Datos_Estudiantes_Viejos()
        {
            InitializeComponent();
        }

        private void Busqueda_Click(object sender, EventArgs e)
        {
            string filtroCedula = txtCedula.Text;
            if (string.IsNullOrWhiteSpace(filtroCedula))
            {
                MessageBox.Show("Por favor ingrese una cédula para filtrar.");
                return;
            }

            foreach (DataGridViewRow row in dgvEstu.Rows)
            {
                if (row.Cells["Cedula"].Value != null && row.Cells["Cedula"].Value.ToString().Contains(filtroCedula))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "";

            foreach (DataGridViewRow row in dgvEstu.Rows)
            {
                row.Visible = true;
            }
        }

        private void Datos_Estudiantes_Viejos_Load(object sender, EventArgs e)
        {
            dgvEstu.AutoGenerateColumns = false;

            CargarDatos();
        }

        private void CargarDatos()
        {
            List<Datos> lista = new CN_DatosEstu().DatitosViejitos();

            dgvEstu.Rows.Clear();

            foreach (Datos r in lista)
            {
                dgvEstu.Rows.Add(new object[] {
                r.idEstudiantes,
                r.Cedula,
                r.NombreCompleto,
                r.Telefono,
                r.Nota
              });
            }
        }
    }
}
