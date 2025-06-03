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
    public partial class Uniformesdgv: Form
    {
        public Uniformesdgv()
        {
            InitializeComponent();
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            // Verificamos que se haya seleccionado al menos una fila en dgvEstu
            if (dgvUni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    // Obtenemos la ID del registro a eliminar; se asume que la columna se llama "ID"
                    int id = Convert.ToInt32(dgvUni.SelectedRows[0].Cells["idEstudiante"].Value);

                    // Reemplaza 'TU_CONEXION_STRING' por la cadena de conexión a tu base de datos.
                    using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                    {
                        // Configuramos el comando para usar el stored procedure sp_Eliminar
                        using (SqlCommand cmd = new SqlCommand("sp_Eliminar2", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Se añade el parámetro necesario; confirma que tu SP espere un parámetro llamado "@id" (o modifica el nombre)
                            cmd.Parameters.AddWithValue("@idEstudiantes", id);

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

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "";

            foreach (DataGridViewRow row in dgvUni.Rows)
            {
                row.Visible = true;
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

            foreach (DataGridViewRow row in dgvUni.Rows)
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

        private void dgvUni_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Obtén la fila actual
            DataGridViewRow fila = dgvUni.Rows[e.RowIndex];

            // Verifica que la celda "Estado" no sea nula y que sea convertible a Boolean
            if (fila.Cells["Estado"].Value != null)
            {
                // Se asume que el valor es de tipo booleano (o que se puede convertir)
                bool estado = Convert.ToBoolean(fila.Cells["Estado"].Value);

                // Si el registro está pendiente (Estado es false), pinta la fila de rojo
                if (estado == false)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    // Si deseas asignar otro color cuando no esté pendiente, configúralo;
                    // por ejemplo, en blanco:
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void Uniformesdgv_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dgvUni.AutoGenerateColumns = false;

            dgvUni.RowPrePaint += dgvUni_RowPrePaint;
        }

        private void CargarDatos()
        {
            List<DatosUni> lista = new CN_DatosUni().DatosU();

            dgvUni.Rows.Clear();

            foreach (DatosUni r in lista)
            {
                dgvUni.Rows.Add(new object[] {
                r.idEstudiante,
                r.FechaRegistro,
                r.Cedula,
                r.NombreCompleto,
                r.Curso,
                r.MontoTotal,
                r.TipoPago,
                r.Concepto,
                r.Banco,
                r.Referencia,
                r.Recibo,
                r.Estado
              });
            }
        }
    }
}
