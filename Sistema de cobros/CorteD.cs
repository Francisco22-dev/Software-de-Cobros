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
using static CapaEntidad.HTML;

namespace Sistema_de_cobros
{
    public partial class CorteD: Form
    {
        public CorteD()
        {
            InitializeComponent();
        }

        private void CorteD_Load(object sender, EventArgs e)
        {
            dgvCorteD.AutoGenerateColumns = false;

            CargarDatos();
            CargarDatos1();

            // Declaramos las variables para acumular cada suma
            decimal totalBs = 0;
            decimal totalDivisa = 0;
            decimal totalDivis = 0;
            decimal totalbs = 0;
            decimal pagomovilCounter = 0;
            decimal transferenciaCounter = 0;
            decimal efectivoCounter = 0;
            decimal depositoCounter = 0;
            decimal tarjetaCounter = 0;
            decimal totalDivisaelectro = 0;
            decimal totalDiviselec = 0;

            // Contador para "Pago mensual"
            int pagoMensualCounter = 0;
            int pagoQuincenalCounter = 0;
            int InscripcionesCounter = 0;
           

            foreach (DataGridViewRow row in dgvCorteD.Rows)
            {
                if (!row.IsNewRow && row.Visible)
                {
                    if (row.Cells["MontoTotal"].Value != null && row.Cells["Concepto"].Value != null && row.Cells["TipoPago"].Value != null)
                    {
                        if (decimal.TryParse(row.Cells["MontoTotal"].Value.ToString(), out decimal monto))
                        {
                            string concepto = row.Cells["Concepto"].Value.ToString().Trim().ToLower();
                            string tipo = row.Cells["TipoPago"].Value.ToString().Trim().ToLower();

                            if (concepto == "pago mensual")
                            {
                                // Solo sumar el monto de la primera fila de cada grupo de 4
                                if (pagoMensualCounter == 0)
                                {
                                    if (tipo == "divisa en efectivo")
                                    {
                                        totalDivisa += monto;
                                    }
                                    if (tipo == "divisa electronica")
                                    {
                                        totalDivisaelectro += monto;
                                    }
                                    else if (tipo == "bolivares en efectivo" ||
                                             tipo == "transferencia" ||
                                             tipo == "deposito" ||
                                             tipo == "pago movil" ||
                                             tipo == "punto")
                                    {
                                        totalBs += monto;
                                    }
                                    if (tipo == "pago movil")
                                    {
                                        pagomovilCounter += monto;
                                    }
                                    else if (tipo == "transferencia")
                                    {
                                        transferenciaCounter += monto;
                                    }
                                    else if (tipo == "bolivares en efectivo")
                                    {
                                        efectivoCounter += monto;
                                    }
                                    else if (tipo == "deposito")
                                    {
                                        depositoCounter += monto;
                                    }
                                    else if (tipo == "punto")
                                    {
                                        tarjetaCounter += monto;
                                    }
                                }
                                pagoMensualCounter++;
                                if (pagoMensualCounter == 4)
                                    pagoMensualCounter = 0;
                                // Reinicia el contador de quincenal si cambia el concepto
                                pagoQuincenalCounter = 0;
                            }
                            else if (concepto == "pago quincenal")
                            {
                                // Solo sumar el monto de la primera fila de cada grupo de 2
                                if (pagoQuincenalCounter == 0)
                                {
                                    if (tipo == "divisa en efectivo")
                                    {
                                        totalDivisa += monto;
                                    }
                                    if (tipo == "divisa electronica")
                                    {
                                        totalDivisaelectro += monto;
                                    }
                                    else if (tipo == "bolivares en efectivo" ||
                                             tipo == "transferencia" ||
                                             tipo == "deposito" ||
                                             tipo == "pago movil" ||
                                             tipo == "punto")
                                    {
                                        totalBs += monto;
                                    }
                                    if (tipo == "pago movil")
                                    {
                                        pagomovilCounter += monto;
                                    }
                                    else if (tipo == "transferencia")
                                    {
                                        transferenciaCounter += monto;
                                    }
                                    else if (tipo == "bolivares en efectivo")
                                    {
                                        efectivoCounter+=monto;
                                    }
                                    else if (tipo == "deposito")
                                    {
                                        depositoCounter += monto;
                                    }
                                    else if (tipo == "punto")
                                    {
                                        tarjetaCounter += monto;
                                    }
                                }
                                pagoQuincenalCounter++;
                                if (pagoQuincenalCounter == 2)
                                    pagoQuincenalCounter = 0;
                                // Reinicia el contador de mensual si cambia el concepto
                                pagoMensualCounter = 0;
                            }
                            else if (concepto == "inscripción")
                            {
                                InscripcionesCounter++;
                                if (tipo == "divisa en efectivo")
                                {
                                    totalDivisa += monto;
                                }
                                if (tipo == "divisa electronica")
                                {
                                    totalDivisaelectro += monto;
                                }
                                else if (tipo == "bolivares en efectivo" ||
                                         tipo == "transferencia" ||
                                         tipo == "deposito" ||
                                         tipo == "pago movil" ||
                                         tipo == "punto")
                                {
                                    totalBs += monto;
                                }
                                if (tipo == "pago movil")
                                {
                                    pagomovilCounter += monto;
                                }
                                else if (tipo == "transferencia")
                                {
                                    transferenciaCounter += monto;
                                }
                                else if (tipo == "bolivares en efectivo")
                                {
                                    efectivoCounter += monto;
                                }
                                else if (tipo == "deposito")
                                {
                                    depositoCounter += monto;
                                }
                                else if (tipo == "punto")
                                {
                                    tarjetaCounter += monto;
                                }
                            }
                            else
                            {
                                // Para otros conceptos, sumar normalmente según el tipo de pago
                                if (tipo == "divisa en efectivo")
                                {
                                    totalDivisa += monto;
                                }
                                if (tipo == "divisa electronica")
                                {
                                    totalDivisaelectro += monto;
                                }
                                else if (tipo == "bolivares en efectivo" ||
                                         tipo == "transferencia" ||
                                         tipo == "deposito" ||
                                         tipo == "pago movil" ||
                                         tipo == "punto")
                                {
                                    totalBs += monto;
                                }
                                // Reinicia ambos contadores si cambia el concepto
                                pagoMensualCounter = 0;
                                pagoQuincenalCounter = 0;

                                if (tipo == "pago movil")
                                {
                                    pagomovilCounter += monto;
                                }
                                else if (tipo == "transferencia")
                                {
                                    transferenciaCounter += monto;
                                }
                                else if (tipo == "bolivares en efectivo")
                                {
                                    efectivoCounter += monto;
                                }
                                else if (tipo == "deposito")
                                {
                                    depositoCounter += monto;
                                }
                                else if (tipo == "punto")
                                {
                                    tarjetaCounter += monto;
                                }
                            }
                        }
                    }     }    }
            
            labelBs.Text = "Total de Pagos en Bolívares: " + totalBs.ToString("N2");
            labelDivisa.Text = "Total de Pagos en Divisa en efectivo: " + totalDivisa.ToString();
            D2.Text = "Total de Pagos en Divisa Electrónica: " + totalDivisaelectro.ToString();

            foreach (DataGridViewRow row in dgvUniC.Rows)
            {
                // Evitamos la fila nueva que se usa para la edición
                if (!row.IsNewRow && row.Visible)
                {
                    // Verificamos que en ambas columnas existan valores
                    if (row.Cells["MontoTotal1"].Value != null && row.Cells["TipoPago1"].Value != null)
                    {
                        // Se intenta convertir el valor de MontoTotal a decimal
                        if (decimal.TryParse(row.Cells["MontoTotal1"].Value.ToString(), out decimal monto))
                        {
                            // Obtenemos el tipo de pago y lo estandarizamos a minúsculas
                            string tipo = row.Cells["TipoPago1"].Value.ToString().Trim().ToLower();

                            // Acumulamos dependiendo del tipo de pago
                            if (tipo == "divisa en efectivo")
                            {
                                totalDivis += monto;
                            }
                            if (tipo == "divisa electronica")
                            {
                                totalDiviselec += monto;
                            }
                            else if (tipo == "bolivares en efectivo" ||
                                     tipo == "transferencia" ||
                                     tipo == "deposito" ||
                                     tipo == "pago movil" ||
                                     tipo == "punto")

                            {
                                totalbs += monto;
                            }
                            if (tipo == "pago movil")
                            {
                                pagomovilCounter += monto;
                            }
                            else if (tipo == "transferencia")
                            {
                                transferenciaCounter += monto;
                            }
                            else if (tipo == "bolivares en efectivo")
                            {
                                efectivoCounter += monto;
                            }
                            else if (tipo == "deposito")
                            {
                                depositoCounter += monto;
                            }
                            else if (tipo == "punto")
                            {
                                tarjetaCounter += monto;
                            }
                        }
                    }
                }
            }

            Bs.Text = "Total de Pagos en Bolívares: " + totalbs.ToString("N2");
            Divisa.Text = "Total de Pagos en Divisa en efectivo: " + totalDivis.ToString();
            D1.Text = "Total de Pagos en Divisa Electrónica: " + totalDiviselec.ToString();

            GBS.Text = "Total General de Pagos en Bolívares: " + (totalBs + totalbs).ToString();
            GD.Text = "Total General de Pagos en Divisa en efectivo: " + (totalDivisa + totalDivis).ToString();
            DivisaElectronica.Text = "Total de Pagos en Divisa Electrónica: " + (totalDivisaelectro + totalDiviselec).ToString();
            decimal Totalmaximo = totalBs + totalbs;
            decimal Totalmaximo1 = totalDivisa + totalDivis;
            TotalBS.Text = Convert.ToString(Totalmaximo);
            TotalDivisa.Text = Convert.ToString(Totalmaximo1);
            inscripcionesCounter.Text = Convert.ToString(InscripcionesCounter);
            PagoMovil.Text = Convert.ToString(pagomovilCounter);
            Transfe.Text = Convert.ToString(transferenciaCounter);
            Deposito.Text = Convert.ToString(depositoCounter);
            Efec.Text = Convert.ToString(efectivoCounter);
            Tarjeta.Text = Convert.ToString(tarjetaCounter);   
            decimal Totalmaximo2 = totalDivisaelectro + totalDiviselec;
            DivisaElectronica1.Text = Convert.ToString(Totalmaximo2);
            ReportePDF.Columns.Add("Curso", "Curso");
            ReportePDF.Columns.Add("Horario", "Horario");
            ReportePDF.Columns.Add("Dia", "Día de clases");
            ReportePDF.Columns.Add("Tipo", "Forma de pago");
            ReportePDF.Columns.Add("Tipo1", "Tipo de pago");
            ReportePDF.Columns.Add("Monto", "Monto BS");
            ReportePDF.Columns.Add("Monto2", "Monto Divisa");
            ReportePDF.Columns.Add("Monto3", "Monto Divisa Electrónica");
        }

        private void CargarDatos()
        {
            List<Reportes> lista = new List<Reportes>();

            lista = new CN_Corte().Registro(
                fechaHoy: DateTime.Today
                );
            dgvCorteD.Rows.Clear();

            foreach (Reportes r in lista)
            {
                dgvCorteD.Rows.Add(new object[] {
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
                    r.Recibo,
                    r.Estado,
                    r.NumeroClase,                    
                    r.FechaVencimiento
              });
            }
        }

        private void CargarDatos1()
        {
            List<CorteUni> lista = new List<CorteUni>();

            lista = new CN_CorteU().DatosU(
               fechaHoy: DateTime.Today
               );

            dgvUniC.Rows.Clear();

            foreach (CorteUni r in lista)
            {
                dgvUniC.Rows.Add(new object[] {
                r.idEstudiante,
                r.FechaRegistro1,
                r.Cedula1,
                r.NombreCompleto1,
                r.Curso1,
                r.MontoTotal1,
                r.TipoPago1,
                r.Concepto1,
                r.Banco1,
                r.Referencia1,
                r.Recibo1,
                r.Estado1
              });
            }
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            // 1. Agregar la fila a la DataGridView
            int indice_fila = ReportePDF.Rows.Add();
            DataGridViewRow row1 = ReportePDF.Rows[indice_fila];

            row1.Cells["Curso"].Value = PagoMovil.Text;
            row1.Cells["Horario"].Value = Efec.Text;
            row1.Cells["Dia"].Value = Transfe.Text;
            row1.Cells["Tipo"].Value = Deposito.Text;
            row1.Cells["Tipo1"].Value = Tarjeta.Text;
            row1.Cells["Monto"].Value = TotalBS.Text;
            row1.Cells["Monto2"].Value = TotalDivisa.Text;
            row1.Cells["Monto3"].Value = DivisaElectronica1.Text;

            // 2. Preparar el SaveFileDialog para el PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            // 4. Cargar y procesar la plantilla HTML
            string PaginaHTML_Texto = Sistema_de_cobros.Properties.Resources.Plantilla_Reporte.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("<br>", "<br />");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("<meta charset=\"UTF-8\">", "<meta charset=\"UTF-8\" />");

            // Reemplazos de cabecera
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Numero", inscripcionesCounter.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            // 5. Construir dinámicamente el bloque de detalles para cada registro
            string detallesHTML = string.Empty;
            decimal totalMonto = 0m;
            decimal totalMonto2 = 0m;
            decimal totalMonto3 = 0m;

            foreach (DataGridViewRow fila in ReportePDF.Rows)
            {
                if (fila.IsNewRow) continue; // Evita la fila vacía

                detallesHTML += "<div class=\"invoice-item\">";
                detallesHTML += "  <div class=\"field\"><span class=\"label\">Pago Móvil:</span> " + (fila.Cells["Curso"].Value != null ? fila.Cells["Curso"].Value.ToString() : "") + "</div>";
                detallesHTML += "  <div class=\"field\"><span class=\"label\">Efectivo:</span> " + (fila.Cells["Horario"].Value != null ? fila.Cells["Horario"].Value.ToString() : "") + "</div>";
                detallesHTML += "  <div class=\"field\"><span class=\"label\">Transferencia:</span> " + (fila.Cells["Dia"].Value != null ? fila.Cells["Dia"].Value.ToString() : "") + "</div>";
                detallesHTML += "  <div class=\"field\"><span class=\"label\">Depósito:</span> " + (fila.Cells["Tipo"].Value != null ? fila.Cells["Tipo"].Value.ToString() : "") + "</div>";
                detallesHTML += "  <div class=\"field\"><span class=\"label\">Punto de venta:</span> " + (fila.Cells["Tipo1"].Value != null ? fila.Cells["Tipo1"].Value.ToString() : "") + "</div>";
                detallesHTML += "</div>";

                // Sumamos el monto (se asume que es un valor convertible a decimal)
                decimal monto;
                decimal monto2;
                decimal monto3;
                if (fila.Cells["Monto"].Value != null && Decimal.TryParse(fila.Cells["Monto"].Value.ToString(), out monto))
                {
                    totalMonto += monto;
                }
                if (fila.Cells["Monto2"].Value != null && Decimal.TryParse(fila.Cells["Monto2"].Value.ToString(), out monto2))
                {
                    totalMonto2 += monto2;
                }
                if (fila.Cells["Monto3"].Value != null && Decimal.TryParse(fila.Cells["Monto3"].Value.ToString(), out monto3))
                {
                    totalMonto3 += monto3;
                }
            }

            // Reemplazar el marcador de detalles en la plantilla HTML
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DETALLES", detallesHTML);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@BS", totalMonto.ToString("F2"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DIVISA", totalMonto2.ToString("F2"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ELECTRO", totalMonto3.ToString("F2"));

            // 6. Mostrar el diálogo para guardar el PDF y generar el mismo
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(new iTextSharp.text.Rectangle(300f, 450f), 0, 0, 0, 0);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    // Utiliza la clase NonClosingStringReader:
                    NonClosingStringReader sr = new NonClosingStringReader(PaginaHTML_Texto);
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    sr.Dispose();

                    pdfDoc.Close();
                    stream.Close();
                }

                ReportePDF.Rows.Clear();
            }
        }
    }
}
