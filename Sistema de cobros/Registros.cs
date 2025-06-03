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
using Sistema_de_cobros.Utilidades;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_de_cobros
{
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
        }

        private void Registros_Load(object sender, EventArgs e)
        {

            List<CE_Cursos> listaCurso = new CD_Cursos().Listar();
            cboCursos.DataSource = listaCurso;
            cboCursos.DisplayMember = "NombreCurso";
            cboCursos.ValueMember = "idCursos";

            dgvRegistros.AutoGenerateColumns = false;

            dgvRegistros.RowPrePaint += dgvRegistros_RowPrePaint;

            // Ajusta el valor inicial
            FechaFin.Value = DateTime.Today;

            // Configura un Timer para revisar cada minuto (60000 milisegundos)
            Timer timer = new Timer();
            timer.Interval = 60000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Si la fecha del DateTimePicker no es la del día actual, actualízala
            if (FechaFin.Value.Date != DateTime.Today)
            {
                FechaFin.Value = DateTime.Today;
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            CE_Cursos selectedCurso = cboCursos.SelectedItem as CE_Cursos;
            if (selectedCurso == null)
            {
                Console.WriteLine("El elemento seleccionado no es un CE_Cursos válido.");
                return;
            }

            int idCurso = selectedCurso.idCursos;

            DateTime fechaInicio = FechaInicio.Value.Date;
            DateTime fechaFin = FechaFin.Value.Date;

            Console.WriteLine("FechaInicio: " + fechaInicio);
            Console.WriteLine("FechaFin: " + fechaFin);

            DateTime fechaHoy = fechaFin;

            List<Reportes> lista = new List<Reportes>();

            lista = new CN_Reporte().Registro(
                fechaInicio,
                fechaFin,
                idCurso
                );

            Console.WriteLine("FechaInicio: " + FechaInicio.Value.ToString("dd/MM/yyyy"));
            Console.WriteLine("FechaFin: " + FechaFin.Value.ToString("dd/MM/yyyy"));
            Console.WriteLine("ID del Curso: " + idCurso);
            
            Console.WriteLine("Número de registros encontrados: " + lista.Count);

            dgvRegistros.Rows.Clear();
            
            foreach (Reportes r in lista)
            {
                dgvRegistros.Rows.Add(new object[] {
                    r.FechaRegistro,
                    r.Cedula,
                    r.NombreCompleto,
                    r.Curso,
                    r.Horario,
                    r.Día,
                    r.MontoTotal,
                    r.TipoPago,
                    r.Concepto,
                    r.Banco,
                    r.Referencia,
                    r.Estado,
                    r.NumeroClase,
                    r.Recibo,
                    r.FechaVencimiento
                });
            }

            List<Reportes> listaPendientesHoy = new CN_Reporte().RegistroPendientesHoy(fechaHoy, idCurso);
            foreach (Reportes r in listaPendientesHoy)
            {
                dgvRegistros.Rows.Add(new object[] {
            r.FechaRegistro,
            r.Cedula,
            r.NombreCompleto,
            r.Curso,
            r.Horario,
            r.Día,
            r.MontoTotal,
            r.TipoPago,
            r.Concepto,
            r.Banco,
            r.Referencia,
            r.Estado,
            r.NumeroClase,
            r.Recibo,
            r.FechaVencimiento
            });
            }

        }

        private void dgvRegistros_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Obtén la fila actual
            DataGridViewRow fila = dgvRegistros.Rows[e.RowIndex];

            // Verifica que la celda "Estado" no sea nula y que sea convertible a Boolean
            if (fila.Cells["Estado"].Value != null)
            {
                // Se asume que el valor es de tipo booleano (o que se puede convertir)
                bool estado = Convert.ToBoolean(fila.Cells["Estado"].Value);

                // Si el registro está pendiente (Estado es false), pinta la fila de rojo
                if (estado == false)
                {
                    fila.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    // Si deseas asignar otro color cuando no esté pendiente, configúralo;
                    // por ejemplo, en blanco:
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRegistros.Rows)
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

            foreach (DataGridViewRow row in dgvRegistros.Rows)
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

    }
}
