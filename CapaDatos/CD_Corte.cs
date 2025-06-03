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
    public class CD_Corte
    {
        public List<Reportes> Registro(DateTime fechaHoy)
        {

            List<Reportes> lista = new List<Reportes>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_Corte", oconexion);
                    cmd.Parameters.AddWithValue("@fechaHoy", fechaHoy);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reportes()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Cedula = dr["Cedula"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Curso = dr["Curso"].ToString(),
                                Horario = dr["Horario"].ToString(),
                                Día = dr["Día"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                TipoPago = dr["TipoPago"].ToString(),
                                Concepto = dr["Concepto"].ToString(),
                                Banco = dr["Banco"].ToString(),
                                Referencia = dr["Referencia"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                                NumeroClase = dr["NumeroClase"].ToString(),
                                Recibo = dr["Recibo"].ToString(),
                                FechaVencimiento = dr["FechaVencimiento"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    lista = new List<Reportes>();
                }
            }
            return lista;
        }
    }
}
