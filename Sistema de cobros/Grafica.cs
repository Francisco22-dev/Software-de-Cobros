using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Globalization;

namespace Sistema_de_cobros
{
    public partial class Grafica : Form
    {
        SqlConnection oconexion = new SqlConnection(Conexion.cadena);
        SqlCommand cmd;
        SqlDataReader dr;

        private void Grafica_Load(object sender, EventArgs e)
        {
            CargarDatosGrafico();
            CargarDatosGrafico2();

        }
        public Grafica()
        {
            InitializeComponent();
        }

        ArrayList fechas = new ArrayList();
        ArrayList cantidades = new ArrayList();
        private void CargarDatosGrafico()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Legends.Add(new Legend("Monedas"));

            chart1.Palette = ChartColorPalette.BrightPastel;

            // Configuro el área para fechas en X
            var area = chart1.ChartAreas[0];
            area.AxisX.LabelStyle.Format = "yyyy-MM";
            area.AxisX.IntervalType = DateTimeIntervalType.Months;
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;

            // Traigo datos
            var dt = new DataTable();
            using (var cn = new SqlConnection(Conexion.cadena))
            using (var cmd = new SqlCommand("sp_Grafica1", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                new SqlDataAdapter(cmd).Fill(dt);
            }

            // Índices
            int ixPeriodo = dt.Columns["Periodo"].Ordinal;
            int ixNombreTipo = dt.Columns["NombreTipo"].Ordinal;
            int ixTotal = dt.Columns["TotalPagos"].Ordinal;

            // Diccionario de series por tipo de moneda
            var seriesDict = new Dictionary<string, Series>();

            foreach (DataRow row in dt.Rows)
            {
                string periodoStr = row.Field<string>(ixPeriodo);      // "yyyy-MM"
                if (!DateTime.TryParseExact(
                        periodoStr,
                        "yyyy-MM",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime fecha))
                    continue;

                // Apunto al primer día del mes
                DateTime puntoX = new DateTime(fecha.Year, fecha.Month, 1);
                string tipo = row.Field<string>(ixNombreTipo);
                double valor = (double)row.Field<decimal>(ixTotal);

                // Creo o recupero la serie
                if (!seriesDict.TryGetValue(tipo, out Series serie))
                {
                    serie = new Series(tipo)
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.DateTime,
                        IsValueShownAsLabel = true,      // muestra el Label encima
                        Legend = "Monedas",
                        Label = "#AXISLABEL"    // etiqueta el eje X (yyyy-MM)
                    };
                    serie.ToolTip = "#VALX{yyyy-MM}: #VALY";
                    chart1.Series.Add(serie);
                    seriesDict[tipo] = serie;
                }

                // Agrego el punto (X=date, Y=valor)
                serie.Points.AddXY(puntoX, valor);

            }
        }

        private void CargarDatosGrafico2()
        {
            // 1) Limpiar series y leyenda
            chart2.Series.Clear();
            chart2.Legends.Clear();
            chart2.Legends.Add(new Legend("Inscripciones"));

            // 2) Configurar eje X para año-mes
            var area = chart2.ChartAreas[0];
            area.AxisX.LabelStyle.Format = "yyyy-MM";
            area.AxisX.IntervalType = DateTimeIntervalType.Months;
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            // 3) Crear la serie
            var serie = new Series("Inscripciones")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                IsValueShownAsLabel = true,
                Label = "#VALX{yyyy-MM}: #VALY"
            };
            chart2.Series.Add(serie);

            // 4) Ejecutar SP y volcar resultados
            using (var conn = new SqlConnection(Conexion.cadena))
            using (var cmd = new SqlCommand("sp_Grafica2", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    int ixPeriodo = dr.GetOrdinal("Periodo");
                    int ixInscripciones = dr.GetOrdinal("Inscripciones");

                    while (dr.Read())
                    {
                        // Leer periodo "yyyy-MM"
                        string periodoStr = dr.GetString(ixPeriodo);
                        if (!DateTime.TryParseExact(
                                periodoStr,
                                "yyyy-MM",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime fechaMes))
                            continue;

                        // Primer día del mes para posicionar la barra
                        DateTime puntoX = new DateTime(fechaMes.Year, fechaMes.Month, 1);
                        int count = dr.GetInt32(ixInscripciones);

                        serie.Points.AddXY(puntoX, count);
                    }
                }

            }
        }
    }
}
