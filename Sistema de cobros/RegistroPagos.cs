using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static CapaEntidad.HTML;


namespace Sistema_de_cobros
{
    public partial class RegistroPagos: Form
    {
        public RegistroPagos()
        {
            InitializeComponent();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            // Configuración del autocomplete para el nombre en TextBox
            NombresCompletos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NombresCompletos.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Para los ComboBox: Configuramos que sugieran elementos de su lista
            cboCursos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCursos.AutoCompleteSource = AutoCompleteSource.ListItems;

            Hora.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Hora.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboDia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDia.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        private void RegistroPagos_Load(object sender, EventArgs e)
        {
            // Cargar cursos
            List<CE_Cursos> listaCurso = new CD_Cursos().Listar();
            cboCursos.DataSource = listaCurso;
            cboCursos.DisplayMember = "NombreCurso";
            cboCursos.ValueMember = "idCursos";

            // Cargar días
            List<Dias> listaDias = new CD_DIAS().Listar();
            cboDia.DataSource = listaDias;
            cboDia.DisplayMember = "Dia";
            cboDia.ValueMember = "idDias";

            // Cargar horarios
            List<Horarios> listaHorarios = new CD_HORARIOS().Listar();
            Hora.DataSource = listaHorarios;
            Hora.DisplayMember = "Hora";
            Hora.ValueMember = "idHorario";

            // Cargar tipos de pago
            List<Tipos> listaTipo = new Tipos_de_Pago().Listar();
            cboTipos.DataSource = listaTipo;
            cboTipos.DisplayMember = "Tipo";
            cboTipos.ValueMember = "idTipos";

            // Cargar conceptos
            List<Concepto> listaConceptos = new CN_Concepto().Listar();
            cboFormato.DataSource = listaConceptos;
            cboFormato.DisplayMember = "Descripcion";
            cboFormato.ValueMember = "idConcepto";

            // Llenar autocompletado con todos los nombres de estudiantes
            var autoCompleteData = new AutoCompleteStringCollection();
            List<StudentData> estudiantes = new CN_Autocompletar().ListarTodos();
            foreach (var est in estudiantes)
            {
                autoCompleteData.Add(est.NombreCompleto);
            }
            NombresCompletos.AutoCompleteCustomSource = autoCompleteData;

            dgvReciboP.Columns.Add("Curso", "Curso");
            dgvReciboP.Columns.Add("Horario", "Horario");
            dgvReciboP.Columns.Add("Dia", "Día");
            dgvReciboP.Columns.Add("Clase", "Clase");
            dgvReciboP.Columns.Add("Formato", "Formato");
            dgvReciboP.Columns.Add("Tipo", "Forma de pago");
            dgvReciboP.Columns.Add("Banco", "Banco");
            dgvReciboP.Columns.Add("Referencia", "Referencia");
            dgvReciboP.Columns.Add("Monto", "Monto");
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (ValidarTextBox())
            {
                
                // Verificar que el ComboBox tenga un valor seleccionado
                if (cboCursos.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un curso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idCursoSeleccionado = Convert.ToInt32(cboCursos.SelectedValue);

                CN_NumeroR numeroManagers = new CN_NumeroR(Conexion.cadena);

                string numeroRecibo = numeroManagers.ObtenerNumeroFormateado();

                DataTable RegistroPago = new DataTable();

                /*Registro.Columns.Add("idEstudiantes", typeof(int));*/
                RegistroPago.Columns.Add("NombreCompleto", typeof(string));
                RegistroPago.Columns.Add("Cedula", typeof(string));
                RegistroPago.Columns.Add("idCursos", typeof(int));
                RegistroPago.Columns.Add("idHorario", typeof(int));
                RegistroPago.Columns.Add("Montoini", typeof(string));
                RegistroPago.Columns.Add("idDias", typeof(int));
                RegistroPago.Columns.Add("fechacreacion", typeof(DateTime));
                RegistroPago.Columns.Add("idTipos", typeof(int));
                RegistroPago.Columns.Add("Referencia", typeof(string));
                RegistroPago.Columns.Add("Bancos", typeof(string));
                RegistroPago.Columns.Add("idConcepto", typeof(int));
                RegistroPago.Columns.Add("NumeroClase", typeof(string));
                RegistroPago.Columns.Add("Recibo", typeof(string));

                DataRow row = RegistroPago.NewRow();
                row["NombreCompleto"] = NombresCompletos.Text;
                row["Cedula"] = Cedula_ins.Text;
                row["idCursos"] = Convert.ToInt32(cboCursos.SelectedValue);
                row["idHorario"] = Convert.ToInt32(Hora.SelectedValue);
                row["Montoini"] = Montoini.Text;
                row["idDias"] = Convert.ToInt32(cboDia.SelectedValue);
                row["fechacreacion"] = DateTime.Now;
                row["idTipos"] = Convert.ToInt32(cboTipos.SelectedValue);
                row["Referencia"] = Referencia.Text;
                row["Bancos"] = Bancotxt.Text;
                row["idConcepto"] = Convert.ToInt32(cboFormato.SelectedValue);
                row["NumeroClase"] = txtClase.Text;
                row["Recibo"] = numeroRecibo;
                RegistroPago.Rows.Add(row);

                Pagos pago = new Pagos
                {
                    NombreCompleto = NombresCompletos.Text,
                    Cedula = Cedula_ins.Text,
                    oCursos = new CE_Cursos { idCursos = Convert.ToInt32(cboCursos.SelectedValue) },
                    oHorario = new Horarios { idHorario = Convert.ToInt32(Hora.SelectedValue) },
                    MontoTotal = Montoini.Text,
                    oDia = new Dias { idDias = Convert.ToInt32(cboDia.SelectedValue) },
                    fechacreacion = DateTime.Now,
                    oTipo = new Tipos { idTipos = Convert.ToInt32(cboTipos.SelectedValue) },
                    Referencia = Referencia.Text,
                    Bancos = Bancotxt.Text,
                    oConcepto = new Concepto { idConcepto = Convert.ToInt32(cboFormato.SelectedValue) },
                    NumeroClase = txtClase.Text,
                    Recibo = numeroRecibo
                };

                bool resultado = new CN_RegistroPagos().RegistrarPago(pago, RegistroPago, out string mensaje);

                if (resultado)
                {
                    MessageBox.Show("Datos registrados correctamente: " + mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (resultado)
                {

                    // 1. Agregar la fila a la DataGridView
                    int indice_fila = dgvReciboP.Rows.Add();
                    DataGridViewRow row1 = dgvReciboP.Rows[indice_fila];

                    row1.Cells["Curso"].Value = cboCursos.Text;
                    row1.Cells["Horario"].Value = Hora.Text;
                    row1.Cells["Dia"].Value = cboDia.Text;
                    row1.Cells["Tipo"].Value = cboTipos.Text;
                    row1.Cells["Clase"].Value = txtClase.Text;
                    row1.Cells["Formato"].Value = cboFormato.Text;
                    row1.Cells["Banco"].Value = Bancotxt.Text;
                    row1.Cells["Referencia"].Value = Referencia.Text;
                    row1.Cells["Monto"].Value = Montoini.Text;

                    
                    if ((Convert.ToInt32(cboFormato.SelectedValue))==5)
                    {
                        string factura = "";
                        factura += "       CEVENCA\n";
                        factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                        factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                        // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':
                       
                        factura += "RECIBO: " + numeroRecibo + "\n\n";
                        factura += "Estudiante: " + NombresCompletos.Text + "\n";
                        factura += "Cedula: " + Cedula_ins.Text + "\n";
                        factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                        factura += "Curso: " + cboCursos.Text + "\n";
                        factura += "Horario: " + Hora.Text + "\n";
                        factura += "Dia de clase: " + cboDia.Text + "\n";
                        factura += "Formato de pago: " + cboFormato.Text + "\n";
                        factura += "Abono que pago: " + txtClase.Text + "\n";
                        factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                        factura += "Total: " + Montoini.Text + "\n\n";
                        factura += "Gracias por su preferencia.\n";
                        factura += "Recibo generado por CEVENCA.\n";

                        byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                        string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                        byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                        string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                        factura = initCommand + factura + cutCommand;

                        string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                        bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                        if (resultadoImpresion)
                        {
                            MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (((Convert.ToInt32(cboTipos.SelectedValue)) == 3)|| ((Convert.ToInt32(cboTipos.SelectedValue)) == 4)|| ((Convert.ToInt32(cboTipos.SelectedValue)) == 5) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 7))
                        {
                            string factura = "";
                            factura += "       CEVENCA\n";
                            factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                            factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                            // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                            factura += "RECIBO: " + numeroRecibo + "\n\n";
                            factura += "Estudiante: " + NombresCompletos.Text + "\n";
                            factura += "Cedula: " + Cedula_ins.Text + "\n";
                            factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                            factura += "Curso: " + cboCursos.Text + "\n";
                            factura += "Horario: " + Hora.Text + "\n";
                            factura += "Dia de clase: " + cboDia.Text + "\n";
                            factura += "Formato de pago: " + cboFormato.Text + "\n";
                            factura += "Semana que pago: " + txtClase.Text + "\n";
                            factura += "Tipo de pago: " + cboTipos.Text + "\n";
                            factura += "Tipo de pago: " + Bancotxt.Text + "\n";
                            factura += "Tipo de pago: " + Referencia.Text + "\n\n";
                            factura += "Total: " + Montoini.Text + "\n\n";
                            factura += "Gracias por su preferencia.\n";
                            factura += "Recibo generado por CEVENCA.\n";

                            byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                            string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                            byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                            string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                            factura = initCommand + factura + cutCommand;

                            string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                            bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                            if (resultadoImpresion)
                            {
                                MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (((Convert.ToInt32(cboFormato.SelectedValue)) == 5) && ((Convert.ToInt32(cboTipos.SelectedValue)) == 3))
                            {
                                string factura = "";
                                factura += "       CEVENCA\n";
                                factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                                factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                                // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                                factura += "RECIBO: " + numeroRecibo + "\n\n";
                                factura += "Estudiante: " + NombresCompletos.Text + "\n";
                                factura += "Cedula: " + Cedula_ins.Text + "\n";
                                factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                                factura += "Curso: " + cboCursos.Text + "\n";
                                factura += "Horario: " + Hora.Text + "\n";
                                factura += "Dia de clase: " + cboDia.Text + "\n";
                                factura += "Formato de pago: " + cboFormato.Text + "\n";
                                factura += "Abono que pago: " + txtClase.Text + "\n";
                                factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                                factura += "Tipo de pago: " + Bancotxt.Text + "\n";
                                factura += "Tipo de pago: " + Referencia.Text + "\n\n";
                                factura += "Total: " + Montoini.Text + "\n\n";
                                factura += "Gracias por su preferencia.\n";
                                factura += "Recibo generado por CEVENCA.\n";

                                byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                                string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                                byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                                string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                                factura = initCommand + factura + cutCommand;

                                string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                                bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                                if (resultadoImpresion)
                                {
                                    MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                if (((Convert.ToInt32(cboFormato.SelectedValue)) == 5) && ((Convert.ToInt32(cboTipos.SelectedValue)) == 4))
                                {
                                    string factura = "";
                                    factura += "       CEVENCA\n";
                                    factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                                    factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                                    // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                                    factura += "RECIBO: " + numeroRecibo + "\n\n";
                                    factura += "Estudiante: " + NombresCompletos.Text + "\n";
                                    factura += "Cedula: " + Cedula_ins.Text + "\n";
                                    factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                                    factura += "Curso: " + cboCursos.Text + "\n";
                                    factura += "Horario: " + Hora.Text + "\n";
                                    factura += "Dia de clase: " + cboDia.Text + "\n";
                                    factura += "Formato de pago: " + cboFormato.Text + "\n";
                                    factura += "Abono que pago: " + txtClase.Text + "\n";
                                    factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                                    factura += "Tipo de pago: " + Bancotxt.Text + "\n";
                                    factura += "Tipo de pago: " + Referencia.Text + "\n\n";
                                    factura += "Total: " + Montoini.Text + "\n\n";
                                    factura += "Gracias por su preferencia.\n";
                                    factura += "Recibo generado por CEVENCA.\n";

                                    byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                                    string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                                    byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                                    string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                                    factura = initCommand + factura + cutCommand;

                                    string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                                    bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                                    if (resultadoImpresion)
                                    {
                                        MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                else
                                {
                                    if (((Convert.ToInt32(cboFormato.SelectedValue)) == 5) && ((Convert.ToInt32(cboTipos.SelectedValue)) == 5))
                                    {
                                        string factura = "";
                                        factura += "       CEVENCA\n";
                                        factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                                        factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                                        // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                                        factura += "RECIBO: " + numeroRecibo + "\n\n";
                                        factura += "Estudiante: " + NombresCompletos.Text + "\n";
                                        factura += "Cedula: " + Cedula_ins.Text + "\n";
                                        factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                                        factura += "Curso: " + cboCursos.Text + "\n";
                                        factura += "Horario: " + Hora.Text + "\n";
                                        factura += "Dia de clase: " + cboDia.Text + "\n";
                                        factura += "Formato de pago: " + cboFormato.Text + "\n";
                                        factura += "Abono que pago: " + txtClase.Text + "\n";
                                        factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                                        factura += "Tipo de pago: " + Bancotxt.Text + "\n";
                                        factura += "Tipo de pago: " + Referencia.Text + "\n\n";
                                        factura += "Total: " + Montoini.Text + "\n\n";
                                        factura += "Gracias por su preferencia.\n";
                                        factura += "Recibo generado por CEVENCA.\n";

                                        byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                                        string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                                        byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                                        string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                                        factura = initCommand + factura + cutCommand;

                                        string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                                        bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                                        if (resultadoImpresion)
                                        {
                                            MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        if (((Convert.ToInt32(cboFormato.SelectedValue)) == 5) && ((Convert.ToInt32(cboTipos.SelectedValue)) == 7))
                                        {
                                            string factura = "";
                                            factura += "       CEVENCA\n";
                                            factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                                            factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                                            // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                                            factura += "RECIBO: " + numeroRecibo + "\n\n";
                                            factura += "Estudiante: " + NombresCompletos.Text + "\n";
                                            factura += "Cedula: " + Cedula_ins.Text + "\n";
                                            factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                                            factura += "Curso: " + cboCursos.Text + "\n";
                                            factura += "Horario: " + Hora.Text + "\n";
                                            factura += "Dia de clase: " + cboDia.Text + "\n";
                                            factura += "Formato de pago: " + cboFormato.Text + "\n";
                                            factura += "Abono que pago: " + txtClase.Text + "\n";
                                            factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                                            factura += "Tipo de pago: " + Bancotxt.Text + "\n";
                                            factura += "Tipo de pago: " + Referencia.Text + "\n\n";
                                            factura += "Total: " + Montoini.Text + "\n\n";
                                            factura += "Gracias por su preferencia.\n";
                                            factura += "Recibo generado por CEVENCA.\n";

                                            byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                                            string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                                            byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                                            string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                                            factura = initCommand + factura + cutCommand;

                                            string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                                            bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                                            if (resultadoImpresion)
                                            {
                                                MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                        }
                                        else
                                        {
                                            string factura = "";
                                            factura += "       CEVENCA\n";
                                            factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                                            factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                                            // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                                            factura += "RECIBO: " + numeroRecibo + "\n\n";
                                            factura += "Estudiante: " + NombresCompletos.Text + "\n";
                                            factura += "Cedula: " + Cedula_ins.Text + "\n";
                                            factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                                            factura += "Curso: " + cboCursos.Text + "\n";
                                            factura += "Horario: " + Hora.Text + "\n";
                                            factura += "Dia de clase: " + cboDia.Text + "\n";
                                            factura += "Formato de pago: " + cboFormato.Text + "\n";
                                            factura += "Semana que pago: " + txtClase.Text + "\n";
                                            factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                                            factura += "Total: " + Montoini.Text + "\n\n";
                                            factura += "Gracias por su preferencia.\n";
                                            factura += "Recibo generado por CEVENCA.\n";

                                            byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                                            string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                                            byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                                            string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                                            factura = initCommand + factura + cutCommand;

                                            string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                                            bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                                            if (resultadoImpresion)
                                            {
                                                MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                        }
                                            
                                    }
                                    
                                }
                            }
                                
                        }
                        
                    }


                        // 2. Preparar el SaveFileDialog para el PDF
                        System.Windows.Forms.SaveFileDialog savefile = new System.Windows.Forms.SaveFileDialog();
                    savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));


                    // 4. Cargar y procesar la plantilla HTML
                    // Se asume que 'Plantilla2' es tu recurso HTML modificado (con @DETALLES)
                    string PaginaHTML_Texto = Sistema_de_cobros.Properties.Resources.Plantilla2.ToString();
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("<br>", "<br />");
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("<meta charset=\"UTF-8\">", "<meta charset=\"UTF-8\" />");

                    // Reemplazos de cabecera
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Numero", numeroRecibo);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", NombresCompletos.Text);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", Cedula_ins.Text);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                    // 5. Construir dinámicamente el bloque de detalles para cada registro
                    // Construir dinámicamente el bloque de detalles (@DETALLES)
                    string detallesHTML = string.Empty;
                    decimal totalMonto = 0m;

                    if (((Convert.ToInt32(cboTipos.SelectedValue)) == 3) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 4) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 5) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 7))
                    {
                        foreach (DataGridViewRow fila in dgvReciboP.Rows)
                        {
                            // Si la fila está vacía o la celda "Curso" es nula, se omite la fila.
                            if (fila.Cells["Curso"].Value == null)
                                continue;

                            // Usar el operador null-coalescing para asignar cadena vacía si es null.
                            string curso = fila.Cells["Curso"].Value?.ToString() ?? "";
                            string horario = fila.Cells["Horario"].Value?.ToString() ?? "";
                            string dia = fila.Cells["Dia"].Value?.ToString() ?? "";
                            string tipo = fila.Cells["Tipo"].Value?.ToString() ?? "";
                            string clase = fila.Cells["Clase"].Value?.ToString() ?? "";
                            string formato = fila.Cells["Formato"].Value?.ToString() ?? "";
                            string banco = fila.Cells["Banco"].Value?.ToString() ?? "";
                            string referencia = fila.Cells["Referencia"].Value?.ToString() ?? "";
                            string montoStr = fila.Cells["Monto"].Value?.ToString() ?? "0";

                            // Conversión segura a decimal para sumar el monto.
                            decimal monto;
                            if (!decimal.TryParse(montoStr, out monto))
                            {
                                monto = 0m;
                            }

                            totalMonto += monto;

                            detallesHTML += "<div class=\"invoice-item\">";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Curso:</span> {curso}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Horario:</span> {horario}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Día de clase:</span> {dia}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Tipo de pago:</span> {tipo}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Número de la clase:</span> {clase}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Forma de pagar:</span> {formato}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Banco:</span> {banco}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Referencia:</span> {referencia}</div>";
                            detallesHTML += "</div>";
                        }

                        // Agregar bloque de total al final de la sección
                        detallesHTML += $"<div class=\"total\">Total: {totalMonto.ToString("F2")}</div>";

                        // Reemplazar el marcador @DETALLES en el HTML
                        PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DETALLES", detallesHTML);
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in dgvReciboP.Rows)
                        {
                            // Si la fila está vacía o la celda "Curso" es nula, se omite la fila.
                            if (fila.Cells["Curso"].Value == null)
                                continue;

                            // Usar el operador null-coalescing para asignar cadena vacía si es null.
                            string curso = fila.Cells["Curso"].Value?.ToString() ?? "";
                            string horario = fila.Cells["Horario"].Value?.ToString() ?? "";
                            string dia = fila.Cells["Dia"].Value?.ToString() ?? "";
                            string tipo = fila.Cells["Tipo"].Value?.ToString() ?? "";
                            string clase = fila.Cells["Clase"].Value?.ToString() ?? "";
                            string formato = fila.Cells["Formato"].Value?.ToString() ?? "";
                            string montoStr = fila.Cells["Monto"].Value?.ToString() ?? "0";

                            // Conversión segura a decimal para sumar el monto.
                            decimal monto;
                            if (!decimal.TryParse(montoStr, out monto))
                            {
                                monto = 0m;
                            }

                            totalMonto += monto;

                            detallesHTML += "<div class=\"invoice-item\">";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Curso:</span> {curso}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Horario:</span> {horario}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Día de clase:</span> {dia}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Tipo de pago:</span> {tipo}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Número de la clase:</span> {clase}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Forma de pagar:</span> {formato}</div>";
                            detallesHTML += "</div>";
                        }

                        // Agregar bloque de total al final de la sección
                        detallesHTML += $"<div class=\"total\">Total: {totalMonto.ToString("F2")}</div>";

                        // Reemplazar el marcador @DETALLES en el HTML
                        PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DETALLES", detallesHTML);
                    }
                        

                    // 6. Mostrar el diálogo para guardar el PDF y generar el mismo
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(new iTextSharp.text.Rectangle(300f, 450f), 0, 0, 0, 0);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            pdfDoc.Add(new Phrase(""));

                            // (Opcional) Agregar imagen, si deseas incluir un banner
                            // iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Sistema_de_cobros.Properties.Resources.Logo_de_Cevenca, System.Drawing.Imaging.ImageFormat.Png);
                            // img.ScaleToFit(60, 60);
                            // img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            // img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            // pdfDoc.Add(img);

                            // Utiliza la clase NonClosingStringReader:
                            NonClosingStringReader sr = new NonClosingStringReader(PaginaHTML_Texto);
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            // Puedes llamar a Dispose al final si lo consideras, pero evita Close() prematuro.
                            sr.Dispose();

                            pdfDoc.Close();
                            stream.Close();
                        }

                        dgvReciboP.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + mensaje,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private bool ValidarTextBox()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { NombresCompletos, Cedula_ins, Montoini, txtClase};

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

        private void Busqueda_Click(object sender, EventArgs e)
        {
            string cedula = txtCedulaBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Ingresa una cédula para realizar la búsqueda.");
                return;
            }

            StudentData estudiante = new CN_Autocompletar().BuscarDatosEstudiante(cedula, out string Mensaje);

            if (estudiante != null)
            {
                Cedula_ins.Text = estudiante.Cedula;
                NombresCompletos.Text = estudiante.NombreCompleto;

                if (estudiante != null)
                {
                    Cedula_ins.Text = estudiante.Cedula;
                    NombresCompletos.Text = estudiante.NombreCompleto;

                    // Selecciona el curso, horario y día en los combos
                    cboCursos.SelectedIndex = cboCursos.FindStringExact(estudiante.NombreCurso);
                    Hora.SelectedIndex = Hora.FindStringExact(estudiante.Hora);
                    cboDia.SelectedIndex = cboDia.FindStringExact(estudiante.Dia);
                }
                
                // Opcional: actualizar el autocomplete del TextBox de nombre
                var autoCompleteData = new AutoCompleteStringCollection();
                autoCompleteData.Add(estudiante.NombreCompleto);
                NombresCompletos.AutoCompleteCustomSource = autoCompleteData;
            }
            else
            {
                MessageBox.Show("No se encontró ningún estudiante o ocurrió un error: " + Mensaje);
            }
        }
    }
}
