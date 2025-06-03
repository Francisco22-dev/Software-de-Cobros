using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Sistema_de_cobros.Utilidades;
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
    public partial class RegisUni: Form
    {
        public RegisUni()
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

        }
        private void RegisUni_Load(object sender, EventArgs e)
        {
            List<Concepto> listaConcepto = new CN_Concepto().Listar();

            foreach (Concepto item in listaConcepto)
            {
                cboFormato.Items.Add(new OpcionCombo() { Valor = item.idConcepto, Texto = item.Descripcion });
            }
            cboFormato.DisplayMember = "Texto";
            cboFormato.ValueMember = "Valor";

            for (int i = 0; i < cboFormato.Items.Count; i++)
            {
                OpcionCombo opc = (OpcionCombo)cboFormato.Items[i];
                if (opc.Valor.Equals(4))
                {
                    cboFormato.SelectedIndex = i;
                    break;
                }
            }

            List<TallaCam> listaCami = new CN_TallaCam().Listar();

            foreach (TallaCam item in listaCami)
            {
                cboCamisa.Items.Add(new OpcionCombo() { Valor = item.idTipoCam, Texto = item.Talla });
            }
            cboCamisa.DisplayMember = "Texto";
            cboCamisa.ValueMember = "Valor";
            cboCamisa.SelectedIndex = 0;

            List<TallaPan> listaPant = new CN_TallaPan().Listar();

            foreach (TallaPan item in listaPant)
            {
                cboPantalon.Items.Add(new OpcionCombo() { Valor = item.idTipoPan, Texto = item.Talla });
            }
            cboPantalon.DisplayMember = "Texto";
            cboPantalon.ValueMember = "Valor";
            cboPantalon.SelectedIndex = 0;

            List<CE_Cursos> listaCurso = new CD_Cursos().Listar();
            cboCursos.DataSource = listaCurso;
            cboCursos.DisplayMember = "NombreCurso";
            cboCursos.ValueMember = "idCursos";

            List<Tipos> listaTipo = new Tipos_de_Pago().Listar();
            cboTipos.DataSource = listaTipo;
            cboTipos.DisplayMember = "Tipo";
            cboTipos.ValueMember = "idTipos";

            List<TallaCam> listaCam = new CD_TallaCam().Listar();
            cboCamisa.DataSource = listaCam;
            cboCamisa.DisplayMember = "Talla";
            cboCamisa.ValueMember = "idTipoCam";

            List<TallaPan> listaPan = new CD_TallaPan().Listar();
            cboPantalon.DataSource = listaPan;
            cboPantalon.DisplayMember = "Talla";
            cboPantalon.ValueMember = "idTipoPan";

            // Llenar autocompletado con todos los nombres de estudiantes
            var autoCompleteData = new AutoCompleteStringCollection();
            List<StudentData> estudiantes = new CN_Autocompletar().ListarTodos();
            foreach (var est in estudiantes)
            {
                autoCompleteData.Add(est.NombreCompleto);
            }
            NombresCompletos.AutoCompleteCustomSource = autoCompleteData;

            dgvReciboU.Columns.Add("Curso", "Curso");
            dgvReciboU.Columns.Add("Camisa", "Camisa");
            dgvReciboU.Columns.Add("Pantalon", "Pantalón");
            dgvReciboU.Columns.Add("Tipo", "Forma de pago");
            dgvReciboU.Columns.Add("Bancos", "Bancos");
            dgvReciboU.Columns.Add("Referencia", "Referencia");
            dgvReciboU.Columns.Add("Monto", "Monto");
        }

        private bool ValidarTextBox()
        {
            // Lista de TextBox para validar
            List<TextBox> textBoxes = new List<TextBox> { NombresCompletos, Cedula_ins, MontoTotal};

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

        private void GuardarUniforme_Click(object sender, EventArgs e)
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

                DataTable Regis = new DataTable();

                /*Registro.Columns.Add("idEstudiantes", typeof(int));*/
                Regis.Columns.Add("NombreCompleto", typeof(string));
                Regis.Columns.Add("Cedula", typeof(string));
                Regis.Columns.Add("idTipoCam", typeof(int));
                Regis.Columns.Add("idTipoPan", typeof(int));
                Regis.Columns.Add("idCursos", typeof(int));
                Regis.Columns.Add("MontoTotal", typeof(string));
                Regis.Columns.Add("idTipos", typeof(int));
                Regis.Columns.Add("Bancos", typeof(string));
                Regis.Columns.Add("Referencia", typeof(string));
                Regis.Columns.Add("FechaPago", typeof(DateTime));
                Regis.Columns.Add("idConcepto", typeof(int));
                Regis.Columns.Add("Recibo", typeof(string));

                DataRow row = Regis.NewRow();
                /*row["idEstudiantes"] = 0; // Dejar como 0 ya que se generará en la base de datos*/
                row["NombreCompleto"] = NombresCompletos.Text;
                row["Cedula"] = Cedula_ins.Text;
                row["idTipoCam"] = Convert.ToInt32(cboCamisa.SelectedValue);
                row["idTipoPan"] = Convert.ToInt32(cboPantalon.SelectedValue);
                row["idCursos"] = Convert.ToInt32(cboCursos.SelectedValue);
                row["MontoTotal"] = MontoTotal.Text;
                row["idTipos"] = Convert.ToInt32(cboTipos.SelectedValue);
                row["Bancos"] = Bancotxt.Text;
                row["Referencia"] = Referencia.Text;
                row["FechaPago"] = DateTime.Now;
                row["idConcepto"] = 4;
                row["Recibo"] = numeroRecibo;
                Regis.Rows.Add(row);

                Uniformes uniform = new Uniformes
                {
                    oEstudiantes = new Estudiantes { NombreCompleto = NombresCompletos.Text },
                    Cedula = Cedula_ins.Text,
                    oTallaCam = new TallaCam { idTipoCam = Convert.ToInt32(cboCamisa.SelectedValue) },
                    oTallaPan = new TallaPan { idTipoPan = Convert.ToInt32(cboPantalon.SelectedValue) },
                    oCursos = new CE_Cursos { idCursos = Convert.ToInt32(cboCursos.SelectedValue) },
                    MontoTotal = MontoTotal.Text,
                    oTipo = new Tipos { idTipos = Convert.ToInt32(cboTipos.SelectedValue) },
                    Banco = Bancotxt.Text,
                    Referencia = Referencia.Text,
                    FechaPago = DateTime.Now,
                    oConcepto = new Concepto { idConcepto = 4 },
                    Recibo = numeroRecibo
                };

                bool resultado = new CN_RegisUni().RegistrarUni(uniform, Regis, out string mensaje);

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
                    int indice_fila = dgvReciboU.Rows.Add();
                    DataGridViewRow row1 = dgvReciboU.Rows[indice_fila];

                    row1.Cells["Curso"].Value = cboCursos.Text;
                    row1.Cells["Camisa"].Value = cboCamisa.Text;
                    row1.Cells["Pantalon"].Value = cboPantalon.Text;
                    row1.Cells["Tipo"].Value = cboTipos.Text;
                    row1.Cells["Bancos"].Value = Bancotxt.Text;
                    row1.Cells["Referencia"].Value = Referencia.Text;
                    row1.Cells["Monto"].Value = MontoTotal.Text;

                  
                    if (((Convert.ToInt32(cboTipos.SelectedValue)) == 3) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 4) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 5) || ((Convert.ToInt32(cboTipos.SelectedValue)) == 7))
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
                        factura += "Pago de uniforme" + "\n";
                        factura += "Curso: " + cboCursos.Text + "\n";
                        factura += "Talla de camisa: " + cboCamisa.Text + "\n";
                        factura += "Talla de pantalon: " + cboPantalon.Text + "\n";
                        factura += "Tipo de pago: " + cboTipos.Text + "\n";
                        factura += "Tipo de pago: " + Bancotxt.Text + "\n";
                        factura += "Tipo de pago: " + Referencia.Text + "\n\n";
                        factura += "Total: " + MontoTotal.Text + "\n\n";
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
                        factura += "Pago de uniforme" + "\n";
                        factura += "Curso: " + cboCursos.Text + "\n";
                        factura += "Talla de camisa: " + cboCamisa.Text + "\n";
                        factura += "Talla de pantalon: " + cboPantalon.Text + "\n";
                        factura += "Tipo de pago: " + cboTipos.Text + "\n\n";
                        factura += "Total: " + MontoTotal.Text + "\n\n";
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


                    // 2. Preparar el SaveFileDialog para el PDF
                    System.Windows.Forms.SaveFileDialog savefile = new System.Windows.Forms.SaveFileDialog();
                    savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

                    // 3. Obtener el número de recibo
                    CN_NumeroR numeroManager = new CN_NumeroR(Conexion.cadena);

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
                        foreach (DataGridViewRow fila in dgvReciboU.Rows)
                        {
                            // Si la fila está vacía o la celda "Curso" es nula, se omite la fila.
                            if (fila.Cells["Camisa"].Value == null)
                                continue;

                            // Usar el operador null-coalescing para asignar cadena vacía si es null.

                            string dia = fila.Cells["Curso"].Value?.ToString() ?? "";
                            string curso = fila.Cells["Camisa"].Value?.ToString() ?? "";
                            string horario = fila.Cells["Pantalon"].Value?.ToString() ?? "";
                            string tipo = fila.Cells["Tipo"].Value?.ToString() ?? "";
                            string banco = fila.Cells["Bancos"].Value?.ToString() ?? "";
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
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Curso:</span> {dia}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Camisa:</span> {curso}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Pantalon:</span> {horario}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Tipo de pago:</span> {tipo}</div>";
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
                        foreach (DataGridViewRow fila in dgvReciboU.Rows)
                        {
                            // Si la fila está vacía o la celda "Curso" es nula, se omite la fila.
                            if (fila.Cells["Camisa"].Value == null)
                                continue;

                            // Usar el operador null-coalescing para asignar cadena vacía si es null.

                            string dia = fila.Cells["Curso"].Value?.ToString() ?? "";
                            string curso = fila.Cells["Camisa"].Value?.ToString() ?? "";
                            string horario = fila.Cells["Pantalon"].Value?.ToString() ?? "";
                            string tipo = fila.Cells["Tipo"].Value?.ToString() ?? "";
                            string montoStr = fila.Cells["Monto"].Value?.ToString() ?? "0";

                            // Conversión segura a decimal para sumar el monto.
                            decimal monto;
                            if (!decimal.TryParse(montoStr, out monto))
                            {
                                monto = 0m;
                            }

                            totalMonto += monto;

                            detallesHTML += "<div class=\"invoice-item\">";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Curso:</span> {dia}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Camisa:</span> {curso}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Pantalon:</span> {horario}</div>";
                            detallesHTML += $"  <div class=\"field\"><span class=\"label\">Tipo de pago:</span> {tipo}</div>";
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

                        dgvReciboU.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + mensaje,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            }
        

        private void Atras_Click(object sender, EventArgs e)
        {
            this.Close();
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
