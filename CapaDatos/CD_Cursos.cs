using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Cursos
    {
        public List<CE_Cursos> Listar()
        {
            List<CE_Cursos> lista = new List<CE_Cursos>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idCursos,NombreCurso from Cursos");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CE_Cursos()
                            {
                                idCursos = Convert.ToInt32(dr["idCursos"]),
                                NombreCurso = dr["NombreCurso"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CE_Cursos>();
                }
            }
            return lista;


        }
        
    }
}
