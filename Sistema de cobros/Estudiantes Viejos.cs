using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_de_cobros
{
    public partial class Estudiantes_Viejos : Form
    {
        public Estudiantes_Viejos()
        {
            InitializeComponent();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarTextBox()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { NombresCompletos, Cedula_ins, Telefono, Correodgv };

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

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (ValidarTextBox())
            {

                DataTable Registro = new DataTable();

                Registro.Columns.Add("NombreCompleto", typeof(string));
                Registro.Columns.Add("Cedula", typeof(string));
                Registro.Columns.Add("Telefono", typeof(string));
                Registro.Columns.Add("Correo", typeof(string));

                DataRow row = Registro.NewRow();
                row["NombreCompleto"] = NombresCompletos.Text;
                row["Cedula"] = Cedula_ins.Text;
                row["Telefono"] = Telefono.Text;
                row["Correo"] = Correodgv.Text;
                Registro.Rows.Add(row);

                Estudiantes estudiante = new Estudiantes
                {
                    NombreCompleto = NombresCompletos.Text,
                    Cedula = Cedula_ins.Text,
                    Telefono = Telefono.Text,
                    Correo = Correodgv.Text
                };

                bool resultado = new CN_Registro().Registrar_Estudiantes_Viejos(estudiante, Registro, out string mensaje);

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
