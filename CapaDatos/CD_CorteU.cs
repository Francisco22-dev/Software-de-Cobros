using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_CorteU
    {
        public List<CorteUni> DatosU(DateTime fechaHoy)
        {
            List<CorteUni> lista = new List<CorteUni>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReportedeUniformesC", oconexion);
                    cmd.Parameters.AddWithValue("@fechaHoy", fechaHoy);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CorteUni()
                            {
                                FechaRegistro1 = dr["FechaRegistro"].ToString(),
                                idEstudiante = Convert.ToInt32(dr["idEstudiantes"].ToString()),
                                Cedula1 = dr["Cedula"].ToString(),
                                NombreCompleto1 = dr["NombreCompleto"].ToString(),
                                Curso1 = dr["Curso"].ToString(),
                                MontoTotal1 = dr["MontoTotal"].ToString(),
                                TipoPago1 = dr["TipoPago"].ToString(),
                                Concepto1 = dr["Concepto"].ToString(),
                                Banco1 = dr["Banco"].ToString(),
                                Referencia1 = dr["Referencia"].ToString(),
                                Recibo1 = dr["Recibo"].ToString(),
                                Estado1 = Convert.ToBoolean(dr["Estado"].ToString())

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    lista = new List<CorteUni>();
                }
            }
            return lista;
        }
    }
}
