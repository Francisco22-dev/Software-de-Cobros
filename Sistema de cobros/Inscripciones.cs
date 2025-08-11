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
using System.Windows.Media;
using Sistema_de_cobros.Utilidades;
using Sistema_de_cobros;
using CapaDatos;

using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css.parser.state;
using System.util;
using iTextSharp.text.xml.xmp;
using static CapaEntidad.HTML;


namespace CapaPresentación
{
    public partial class Inscripciones : Form
    {
        public Inscripciones()
        {
            InitializeComponent();
        }

        private void cboCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            List<Concepto> listaConcepto = new CN_Concepto().Listar();

            foreach (Concepto item in listaConcepto)
            {
                cboFormato.Items.Add(new OpcionCombo() { Valor = item.idConcepto, Texto = item.Descripcion });
            }
            cboFormato.DisplayMember = "Texto";
            cboFormato.ValueMember = "Valor";
            cboFormato.SelectedIndex = 0;


            List<Horarios> listaHorario = new CN_Horario().Listar();

            foreach (Horarios item in listaHorario)
            {
                Hora.Items.Add(new OpcionCombo() { Valor = item.idHorario, Texto = item.Hora });
            }
            Hora.DisplayMember = "Texto";
            Hora.ValueMember = "Valor";
            Hora.SelectedIndex = 0;

            List<Dias> listaDia = new CN_DIAS().Listar();

            foreach (Dias item in listaDia)
            {
                cboDia.Items.Add(new OpcionCombo() { Valor = item.idDias, Texto = item.Dia });
            }
            cboDia.DisplayMember = "Texto";
            cboDia.ValueMember = "Valor";
            cboDia.SelectedIndex = 0;

            List<Tipos> listaTipos = new CN_TIPOS().Listar();

            foreach (Tipos item in listaTipos)
            {
                cboTipos.Items.Add(new OpcionCombo() { Valor = item.idTipos, Texto = item.Tipo });
            }
            cboTipos.DisplayMember = "Texto";
            cboTipos.ValueMember = "Valor";
            cboTipos.SelectedIndex = 0;

            List<CE_Cursos> listaCursos = new CN_Cursos().Listar();

            foreach (CE_Cursos item in listaCursos)
            {
                cboCursos.Items.Add(new OpcionCombo() { Valor = item.idCursos, Texto = item.NombreCurso });
            }
            cboCursos.DisplayMember = "Texto";
            cboCursos.ValueMember = "Valor";
            cboCursos.SelectedIndex = 0;

            List<CE_Cursos> listaCurso = new CD_Cursos().Listar();
            cboCursos.DataSource = listaCurso;
            cboCursos.DisplayMember = "NombreCurso";
            cboCursos.ValueMember = "idCursos";

            List<Dias> listaDias = new CD_DIAS().Listar();
            cboDia.DataSource = listaDias;
            cboDia.DisplayMember = "Dia";
            cboDia.ValueMember = "idDias";

            List<Horarios> listaHorarios = new CD_HORARIOS().Listar();
            Hora.DataSource = listaHorarios;
            Hora.DisplayMember = "Hora";
            Hora.ValueMember = "idHorario";

            List<Tipos> listaTipo = new Tipos_de_Pago().Listar();
            cboTipos.DataSource = listaTipo;
            cboTipos.DisplayMember = "Tipo";
            cboTipos.ValueMember = "idTipos";

            List<Concepto> listaConceptos = new CN_Concepto().Listar();
            cboFormato.DataSource = listaConceptos;
            cboFormato.DisplayMember = "Descripcion";
            cboFormato.ValueMember = "idConcepto";

            dgvBoletas.Columns.Add("Curso", "Curso");
            dgvBoletas.Columns.Add("Horario", "Horario");
            dgvBoletas.Columns.Add("Dia", "Día de clases");
            dgvBoletas.Columns.Add("Tipo", "Forma de pago");
            dgvBoletas.Columns.Add("Banco", "Banco");
            dgvBoletas.Columns.Add("Referencia", "Referencia");
            dgvBoletas.Columns.Add("Monto", "Monto");
        }
        private void ImprimirFacturaDosVeces(string factura, string printerName)
        {
            for (int i = 0; i < 2; i++)
            {
                bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                if (!resultadoImpresion)
                {
                    MessageBox.Show($"Error al imprimir el recibo número {i + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else 
                {
                    MessageBox.Show($"Recibo número {i + 1} impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Método para construir la factura según el caso
        private string ConstruirFactura(string numeroRecibo, string nombres, string cedula, string curso, string horario, string dia, string formato, string tipo, string banco, string referencia, string monto)
        {
            string factura = "";
            factura += "       CEVENCA\n";
            factura += "Rif: J-30475526-0 | Registro MPPE: 0016-1904\n";
            factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
            factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
            factura += "RECIBO: " + numeroRecibo + "\n\n";
            factura += "Estudiante: " + NombresCompletos.Text + "\n";
            factura += "Cedula: " + Cedula_ins.Text + "\n";
            factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
            factura += "Curso: " + cboCursos.Text + "\n";
            factura += "Horario: " + Hora.Text + "\n";
            factura += "Dia de clase: " + cboDia.Text + "\n";
            if (CheckP1.Checked)
            {
                factura += "Formato de pago: Pago de inscripción y primera clase."+"\n";
            }
            else {
                factura += "Formato de pago: " + cboFormato.Text + "\n";
            }               
            factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
            int tipoPago = Convert.ToInt32(cboTipos.SelectedValue);
            if (tipoPago == 3 || tipoPago == 4 || tipoPago == 5 || tipoPago == 7)
            {
                factura += "Banco: " + Bancotxt.Text + "\n";
                factura += "Referencia: " + Referencia.Text + "\n\n";
            }
            factura += "Total: " + Montoini.Text + "\n\n";
            factura += "Gracias por su preferencia.\n";
            factura += "Recibo generado por CEVENCA.\n";

            byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
            string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
            byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
            string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
            factura = initCommand + factura + cutCommand;

            return factura;

        }
        private bool ValidarTextBox()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { NombresCompletos, Cedula_ins, Telefono, Montoini };

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
            if (!Cedula_ins.Text.All(char.IsDigit))
            {
                MessageBox.Show("La cédula solo debe contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string texto = Telefono.Text;

            // Permite dígitos y guiones
            if (!texto.All(c => char.IsDigit(c) || c == '-'))
            {
                MessageBox.Show(
                    "El teléfono solo debe contener números y guiones (-).",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            string Monto = Montoini.Text;
            if (!Monto.All(c => char.IsDigit(c) || c == ','))
            {
                MessageBox.Show(
                    "El monto solo debe contener números y comas (,).",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            if (!Referencia.Text.All(char.IsDigit))
            {
                MessageBox.Show("La referencia solo debe contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string Nombre = NombresCompletos.Text;
            if (!Nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show(
                    "El Nombre solo debe contener letras.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            string Banco = Bancotxt.Text;
            if (!Banco.All(c => char.IsLetterOrDigit(c) || c == '%'))
            {
                MessageBox.Show("El Banco solo debe contener letras o 100% Banco si es el caso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }

        private void Atras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click_1(object sender, EventArgs e)
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

                DataTable Registro = new DataTable();

                /*Registro.Columns.Add("idEstudiantes", typeof(int));*/
                Registro.Columns.Add("NombreCompleto", typeof(string));
                Registro.Columns.Add("Cedula", typeof(string));
                Registro.Columns.Add("Telefono", typeof(string));
                Registro.Columns.Add("idCursos", typeof(int));
                Registro.Columns.Add("idHorario", typeof(int));
                Registro.Columns.Add("Montoini", typeof(string));
                Registro.Columns.Add("idDias", typeof(int));
                Registro.Columns.Add("fechacreacion", typeof(DateTime));
                Registro.Columns.Add("idTipos", typeof(int));
                Registro.Columns.Add("Referencia", typeof(string));
                Registro.Columns.Add("Bancos", typeof(string));
                Registro.Columns.Add("idConcepto", typeof(int));
                Registro.Columns.Add("Recibo", typeof(string));
                Registro.Columns.Add("Pago", typeof(bool)); // Cambiado a booleano para CheckBox

                DataRow row = Registro.NewRow();
                /*row["idEstudiantes"] = 0; // Dejar como 0 ya que se generará en la base de datos*/
                row["NombreCompleto"] = NombresCompletos.Text;
                row["Cedula"] = Cedula_ins.Text;
                row["Telefono"] = Telefono.Text;
                row["idCursos"] = Convert.ToInt32(cboCursos.SelectedValue);
                row["idHorario"] = Convert.ToInt32(Hora.SelectedValue);
                row["Montoini"] = Montoini.Text;
                row["idDias"] = Convert.ToInt32(cboDia.SelectedValue);
                row["fechacreacion"] = DateTime.Now;
                row["idTipos"] = Convert.ToInt32(cboTipos.SelectedValue);
                row["Referencia"] = Referencia.Text;
                row["Bancos"] = Bancotxt.Text;
                row["idConcepto"] = Convert.ToInt32(cboFormato.SelectedValue);
                row["Recibo"] = numeroRecibo; 
                row["Pago"] = CheckP1.Checked;
                Registro.Rows.Add(row);

                Estudiantes estudiante = new Estudiantes
                {
                    /*idEstudiantes = 0, // Dejar como 0 ya que se generará en la base de datos*/
                    NombreCompleto = NombresCompletos.Text,
                    Cedula = Cedula_ins.Text,
                    Telefono = Telefono.Text,
                    oCursos = new CE_Cursos { idCursos = Convert.ToInt32(cboCursos.SelectedValue) },
                    oHorario = new Horarios { idHorario = Convert.ToInt32(Hora.SelectedValue) },
                    Montoini = Montoini.Text,
                    oDia = new Dias { idDias = Convert.ToInt32(cboDia.SelectedValue) },
                    fechacreacion = DateTime.Now,
                    oTipo = new Tipos { idTipos = Convert.ToInt32(cboTipos.SelectedValue) },
                    Referencia = Referencia.Text,
                    Bancos = Bancotxt.Text,
                    oConcepto = new Concepto { idConcepto = Convert.ToInt32(cboFormato.SelectedValue) },
                    Recibo = numeroRecibo,
                    Pago = Convert.ToBoolean(CheckP1.Checked ? 1 : 0)
                };

                bool resultado = new CN_Registro().Registrar(estudiante, Registro, out string mensaje);

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
                    int indice_fila = dgvBoletas.Rows.Add();
                    DataGridViewRow row1 = dgvBoletas.Rows[indice_fila];

                    row1.Cells["Curso"].Value = cboCursos.Text;
                    row1.Cells["Horario"].Value = Hora.Text;
                    row1.Cells["Dia"].Value = cboDia.Text;
                    row1.Cells["Tipo"].Value = cboTipos.Text;
                    row1.Cells["Banco"].Value = Bancotxt.Text;
                    row1.Cells["Referencia"].Value = Referencia.Text;
                    row1.Cells["Monto"].Value = Montoini.Text;

                    // Construye la factura
                    string factura = ConstruirFactura(
                        numeroRecibo,
                        NombresCompletos.Text,
                        Cedula_ins.Text,
                        cboCursos.Text,
                        Hora.Text,
                        cboDia.Text,
                        cboFormato.Text,
                        cboTipos.Text,
                        Bancotxt.Text,
                        Referencia.Text,
                        Montoini.Text
                    );

                    // Imprime la factura dos veces
                    string printerName = "POS-80"; // Cambia por el nombre real de tu impresora
                    ImprimirFacturaDosVeces(factura, printerName);

                    //if (((Convert.ToInt32(cboTipos.SelectedValue)) == 3) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 4) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 5) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 7))
                    //{
                    //    string factura = "";
                    //    factura += "       CEVENCA\n";
                    //    factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                    //    factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                    //    // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                    //    factura += "RECIBO: " + numeroRecibo + "\n\n";
                    //    factura += "Estudiante: " + NombresCompletos.Text + "\n";
                    //    factura += "Cedula: " + Cedula_ins.Text + "\n";
                    //    factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                    //    factura += "Inscripcion" + "\n";
                    //    factura += "Curso: " + cboCursos.Text + "\n";
                    //    factura += "Horario: " + Hora.Text + "\n";
                    //    factura += "Dia de clase: " + cboDia.Text + "\n";
                    //    factura += "Tipo de pago: " + cboTipos.Text + "\n";
                    //    factura += "Banco: " + Bancotxt.Text + "\n";
                    //    factura += "Referencia: " + Referencia.Text + "\n\n";
                    //    factura += "Total: " + Montoini.Text + "\n\n";
                    //    factura += "Gracias por su preferencia.\n";
                    //    factura += "Recibo generado por CEVENCA.\n";

                    //    byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                    //    string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                    //    byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                    //    string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                    //    factura = initCommand + factura + cutCommand;

                    //    string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                    //    bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                    //    if (resultadoImpresion)
                    //    {
                    //        MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //else
                    //{
                    //    string factura = "";
                    //    factura += "       CEVENCA\n";
                    //    factura += "Direccion: Av. Las Ferias, C.C. Isora," + "\npiso Mezzanina, local 07\n";
                    //    factura += "Telefonos: 0414-4281527 / 0426-2355934\n\n";
                    //    // Si tienes un número de recibo generado dinámicamente, por ejemplo desde 'numeroManager':

                    //    factura += "RECIBO: " + numeroRecibo + "\n\n";
                    //    factura += "Estudiante: " + NombresCompletos.Text + "\n";
                    //    factura += "Cedula: " + Cedula_ins.Text + "\n";
                    //    factura += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n";
                    //    factura += "Inscripcion" + "\n";
                    //    factura += "Curso: " + cboCursos.Text + "\n";
                    //    factura += "Horario: " + Hora.Text + "\n";
                    //    factura += "Dia de clase: " + cboDia.Text + "\n";
                    //    factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                    //    factura += "Total: " + Montoini.Text + "\n\n";
                    //    factura += "Gracias por su preferencia.\n";
                    //    factura += "Recibo generado por CEVENCA.\n";

                    //    byte[] initCommandBytes = new byte[] { 0x1B, 0x40 };  // Comando ESC @ (reinicia la impresora)
                    //    string initCommand = System.Text.Encoding.ASCII.GetString(initCommandBytes);
                    //    byte[] cutCommandBytes = new byte[] { 0x1D, 0x56, 0x41, 0x10 };  // Comando de corte. ¡Verifica que sea el correcto para tu modelo!
                    //    string cutCommand = System.Text.Encoding.ASCII.GetString(cutCommandBytes);
                    //    factura = initCommand + factura + cutCommand;

                    //    string printerName = "POS-80"; // Reemplaza este valor por el nombre exacto configurado en Windows.
                    //    bool resultadoImpresion = RawPrinterHelper.SendStringToPrinter(printerName, factura);
                    //    if (resultadoImpresion)
                    //    {
                    //        MessageBox.Show("Recibo impreso correctamente.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Error al imprimir el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                        

                    // 2. Preparar el SaveFileDialog para el PDF
                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.FileName = string.Format("{0}.pdf", numeroRecibo);

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
                    string detallesHTML = string.Empty;
                    decimal totalMonto = 0m;

                    if (((Convert.ToInt32(cboTipos.SelectedValue)) == 3) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 4) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 5) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 7))
                    {
                        foreach (DataGridViewRow fila in dgvBoletas.Rows)
                        {
                            detallesHTML += "<div class=\"invoice-item\">";
                            if (CheckP1.Checked)
                            {
                                detallesHTML += "  <div class=\"field\"><span class=\"label\">Formato: Pago de inscripción y primera clase</span> " + "</div>";
                            }
                            else {
                                detallesHTML += "  <div class=\"field\"><span class=\"label\">Formato: Pago de inscripción</span> " +  "</div>";
                            }
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Curso:</span> " + fila.Cells["Curso"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Horario:</span> " + fila.Cells["Horario"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Día de clase:</span> " + fila.Cells["Dia"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Tipo de pago:</span> " + fila.Cells["Tipo"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Banco:</span> " + fila.Cells["Banco"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Referencia:</span> " + fila.Cells["Referencia"].Value.ToString() + "</div>";
                            detallesHTML += "</div>";

                            // Sumamos el monto (se asume que es un valor convertible a decimal)
                            decimal monto;
                            if (Decimal.TryParse(fila.Cells["Monto"].Value.ToString(), out monto))
                            {
                                totalMonto += monto;
                            }
                        }

                        // Agregar la sección del total al final de los detalles
                        detallesHTML += $"<div class=\"total\">Total: {totalMonto.ToString("F2")}</div>";

                        // Reemplazar el marcador de detalles en la plantilla HTML
                        PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DETALLES", detallesHTML);
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in dgvBoletas.Rows)
                        {
                            detallesHTML += "<div class=\"invoice-item\">";
                            if (CheckP1.Checked)
                            {
                                detallesHTML += "  <div class=\"field\"><span class=\"label\">Formato: Pago de inscripción y primera clase</span> " + "</div>";
                            }
                            else
                            {
                                detallesHTML += "  <div class=\"field\"><span class=\"label\">Formato: Pago de inscripción</span> " + "</div>";
                            }
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Curso:</span> " + fila.Cells["Curso"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Horario:</span> " + fila.Cells["Horario"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Día de clase:</span> " + fila.Cells["Dia"].Value.ToString() + "</div>";
                            detallesHTML += "  <div class=\"field\"><span class=\"label\">Tipo de pago:</span> " + fila.Cells["Tipo"].Value.ToString() + "</div>";
                            detallesHTML += "</div>";

                            // Sumamos el monto (se asume que es un valor convertible a decimal)
                            decimal monto;
                            if (Decimal.TryParse(fila.Cells["Monto"].Value.ToString(), out monto))
                            {
                                totalMonto += monto;
                            }
                        }

                        // Agregar la sección del total al final de los detalles
                        detallesHTML += $"<div class=\"total\">Total: {totalMonto.ToString("F2")}</div>";

                        // Reemplazar el marcador de detalles en la plantilla HTML
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

                        dgvBoletas.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + mensaje,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
