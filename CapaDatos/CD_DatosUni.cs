using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_DatosUni
    {
        public List<DatosUni> DatosU()
        {
            List<DatosUni> lista = new List<DatosUni>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReportedeUniformes", oconexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DatosUni()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                idEstudiante = Convert.ToInt32(dr["idEstudiantes"].ToString()),
                                Cedula = dr["Cedula"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Curso = dr["Curso"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                TipoPago = dr["TipoPago"].ToString(),
                                Concepto = dr["Concepto"].ToString(),
                                Banco = dr["Banco"].ToString(),
                                Referencia = dr["Referencia"].ToString(),
                                Recibo = dr["Recibo"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"].ToString())

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    lista = new List<DatosUni>();
                }
            }
            return lista;
        }
    }
        
}