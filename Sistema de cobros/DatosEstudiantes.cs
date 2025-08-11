using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_cobros
{
    public partial class DatosEstudiantes: Form
    {
        public DatosEstudiantes()
        {
            InitializeComponent();
        }

        private void DatosEstudiantes_Load(object sender, EventArgs e)
        {
            dgvEstu.AutoGenerateColumns = false;

            CargarDatos();
        }

        private void CargarDatos()
        {
            List<Datos> lista = new CN_DatosEstu().Datitos();

            dgvEstu.Rows.Clear();

            foreach (Datos r in lista)
            { dgvEstu.Rows.Add(new object[] {
                r.idEstudiantes,
                r.Cedula,
                r.NombreCompleto,
                r.Telefono
              });
            }
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

        private void Borrar_Click(object sender, EventArgs e)
        {
            // Verificamos que se haya seleccionado al menos una fila en dgvEstu
            if (dgvEstu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
                return;
            }
            if (MessageBox.Show("¿Desea eliminar al estudiante?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Obtenemos la ID del registro a eliminar; se asume que la columna se llama "ID"
                    int id = Convert.ToInt32(dgvEstu.SelectedRows[0].Cells["idEstudiantes"].Value);

                    // Reemplaza 'TU_CONEXION_STRING' por la cadena de conexión a tu base de datos.
                    using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                    {
                        // Configuramos el comando para usar el stored procedure sp_Eliminar
                        using (SqlCommand cmd = new SqlCommand("Eliminacion", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Se añade el parámetro necesario; confirma que tu SP espere un parámetro llamado "@id" (o modifica el nombre)
                            cmd.Parameters.AddWithValue("@idEstudiantes", id);
                            cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                            // Abrimos la conexión y ejecutamos el comando
                            conexion.Open();
                            int filasAfectadas = cmd.ExecuteNonQuery();

                            // Validamos si el SP eliminó algún registro
                            if (filasAfectadas > 0)
                                MessageBox.Show("El registro se eliminó correctamente.");
                            else
                                MessageBox.Show("No se eliminó ningún registro. Verifica la información.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el registro: " + ex.Message);
                }
            }
                
        }

    }
}
