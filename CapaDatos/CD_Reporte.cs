using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<Reportes> Registro(
        DateTime fechaInicio,
        DateTime fechaFin,
        DateTime fechaHoy,
        int idCurso)
        {
            var lista = new List<Reportes>();

            using (var oconexion = new SqlConnection(Conexion.cadena))
            using (var cmd = new SqlCommand("sp_ReportedeEstudiantesCompleto", oconexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@FechaHoy", fechaHoy);
                cmd.Parameters.AddWithValue("@idCurso", idCurso);

                oconexion.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Reportes
                        {
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            Cedula = dr["Cedula"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Curso = dr["Curso"].ToString(),
                            Horario = dr["Horario"].ToString(),
                            Día = dr["Día"].ToString(),           // Propiedad renombrada a 'Dia'
                            MontoTotal = dr["MontoTotal"].ToString(),
                            TipoPago = dr["TipoPago"].ToString(),
                            Concepto = dr["Concepto"].ToString(),
                            Banco = dr["Banco"].ToString(),
                            Referencia = dr["Referencia"].ToString(),
                            Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]),
                            NumeroClase = dr["NumeroClase"].ToString(),
                            Recibo = dr["Recibo"].ToString(),
                            FechaVencimiento = dr["FechaVencimiento"].ToString(),
                            idEstado = dr["idEstado"] != DBNull.Value
                                               ? Convert.ToInt32(dr["idEstado"])
                                               : 0
                        });
                    }
                }
            }

            return lista;
        }



        //public List<Reportes> RegistroPendientesHoy(DateTime fechaHoy, int idCurso)
        //{
        //    List<Reportes> listaPendientesHoy = new List<Reportes>();
        //    using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_ReportedeEstudiantesPendientesHoy", oconexion);
        //            cmd.Parameters.AddWithValue("@FechaHoy", fechaHoy);
        //            cmd.Parameters.AddWithValue("@idCurso", idCurso);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oconexion.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    listaPendientesHoy.Add(new Reportes()
        //                    {
        //                        FechaRegistro = dr["FechaRegistro"].ToString(),
        //                        Cedula = dr["Cedula"].ToString(),
        //                        NombreCompleto = dr["NombreCompleto"].ToString(),
        //                        Curso = dr["Curso"].ToString(),
        //                        Horario = dr["Horario"].ToString(),
        //                        Día = dr["Día"].ToString(),
        //                        MontoTotal = dr["MontoTotal"].ToString(),
        //                        TipoPago = dr["TipoPago"].ToString(),
        //                        Concepto = dr["Concepto"].ToString(),
        //                        Banco = dr["Banco"].ToString(),
        //                        Referencia = dr["Referencia"].ToString(),
        //                        Estado = Convert.ToBoolean(dr["Estado"]),
        //                        NumeroClase = dr["NumeroClase"].ToString(),
        //                        Recibo = dr["Recibo"].ToString(),
        //                        FechaVencimiento = dr["FechaVencimiento"].ToString(),
        //                        idEstado = Convert.ToInt32(dr["idEstado"])
        //                    });
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error: " + ex.Message);
        //            listaPendientesHoy = new List<Reportes>();
        //        }
        //    }
        //    return listaPendientesHoy;
        //}

    }
}
