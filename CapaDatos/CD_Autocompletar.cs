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
    public class CD_Autocompletar
    {
        /// <summary>
        /// Busca los datos del estudiante a partir de la cédula usando el stored procedure sp_GetStudentData.
        /// </summary>
        /// <param name="cedula">Cédula del estudiante</param>
        /// <param name="Mensaje">Mensaje de error, en caso de ocurrir</param>
        /// <returns>Instancia de CE_Estudiante con los datos encontrados o null si no encuentra nada</returns>
        public StudentData BuscarDatosEstudiante(string cedula, out string Mensaje)
        {
            StudentData objEstudiante = null;
            Mensaje = string.Empty;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetStudentData", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            objEstudiante = new StudentData
                            {
                                Cedula = dr["Cedula"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Dia = dr["Dia"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    objEstudiante = null;
                    Mensaje = ex.Message;
                }
            }

            return objEstudiante;
        }
        public List<StudentData> ListarTodos()
        {
            List<StudentData> lista = new List<StudentData>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT Cedula, NombreCompleto, NombreCurso, Hora, Dia FROM Estudiantes", oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new StudentData
                            {
                                Cedula = dr["Cedula"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Dia = dr["Dia"].ToString()
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<StudentData>();
                }
            }

            return lista;
        }

    }
}

