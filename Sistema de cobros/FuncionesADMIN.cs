using CapaDatos;
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
using System.Windows.Markup;

namespace Sistema_de_cobros
{
    public partial class FuncionesADMIN: Form
    {
        public FuncionesADMIN()
        {
            InitializeComponent();
        }

        private void FuncionesADMIN_Load(object sender, EventArgs e)
        {
            List<CE_Cursos> listaCurso = new CD_Cursos().Listar();
            cboCursos.DataSource = listaCurso;
            cboCursos.DisplayMember = "NombreCurso";
            cboCursos.ValueMember = "idCursos";
        }

        private void GuardarCurso_Click(object sender, EventArgs e)
        {
            if (ValidarTextBox())
            {

                DataTable RegistroCurso = new DataTable();

                RegistroCurso.Columns.Add("NombreCurso", typeof(string));
                RegistroCurso.Columns.Add("duracionCurso", typeof(int));

                DataRow row = RegistroCurso.NewRow();
                row["NombreCurso"] = NombreCurso.Text;
                row["duracionCurso"] = Convert.ToInt32(Duracion.Text);
                RegistroCurso.Rows.Add(row);

                CE_Cursos Curso = new CE_Cursos
                {
                    NombreCurso = NombreCurso.Text,
                    duracionCurso = Convert.ToInt32(Duracion.Text)
                };

                bool resultado = new CN_AGCurso().RegistrarCurso(Curso, RegistroCurso, out string mensaje);

                if (resultado)
                {
                    MessageBox.Show("Datos registrados correctamente: " + mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarTextBox()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { NombreCurso, Duracion };

            // Verificar cada TextBox
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Si algún TextBox está vacío, mostramos un mensaje y retornamos falso
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Si todos los TextBox tienen contenido, retornamos verdadero
            return true;
        }

        private bool ValidarTextBox2()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { txtDuracionEdi, txtNombreEdi };

            // Verificar cada TextBox
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Si algún TextBox está vacío, mostramos un mensaje y retornamos falso
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Si todos los TextBox tienen contenido, retornamos verdadero
            return true;
        }

        private void GuardarEdi_Click(object sender, EventArgs e)
        {
            if (ValidarTextBox2())
            {
                // Verificar que el ComboBox tenga un valor seleccionado
                if (cboCursos.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un curso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idCursoSeleccionado = Convert.ToInt32(cboCursos.SelectedValue);

                DataTable ActualizarCurso = new DataTable();

                DataTable Datos = new DataTable();

                Datos.Columns.Add("NombreCurso", typeof(string));
                Datos.Columns.Add("idCursos", typeof(int));
                Datos.Columns.Add("duracionCurso", typeof(int));

                DataRow row = Datos.NewRow();
                row["NombreCurso"] = txtNombreEdi.Text;
                row["idCursos"] = Convert.ToInt32(cboCursos.SelectedValue);
                row["duracionCurso"] = Convert.ToInt32(txtDuracionEdi.Text);
                Datos.Rows.Add(row);

                CE_Cursos curso = new CE_Cursos
                {
                    NombreCurso = txtNombreEdi.Text,
                    idCursos = idCursoSeleccionado,
                    duracionCurso = Convert.ToInt32(txtDuracionEdi.Text)
                };
                
                bool resultado = new CN_EditarCurso().EditarCurso(curso, Datos, out string mensaje);

                if (resultado)
                {
                    MessageBox.Show("Datos registrados correctamente: " + mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
