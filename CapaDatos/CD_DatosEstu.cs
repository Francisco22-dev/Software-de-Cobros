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
    public class CD_DatosEstu
    {
        public List<Datos> Datitos()
        {

            List<Datos> lista = new List<Datos>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_Estudiante", oconexion);
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Datos()
                            {
                                idEstudiantes = Convert.ToInt32(dr["idEstudiantes"].ToString()),
                                Cedula = dr["Cedula"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString()
                                
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    lista = new List<Datos>();
                }
            }
            return lista;
        }

        public List<Datos> DatitosViejitos()
        {

            List<Datos> lista = new List<Datos>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_EstudianteViejos", oconexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Datos()
                            {
                                idEstudiantes = Convert.ToInt32(dr["idEstudiantes"].ToString()),
                                Cedula = dr["Cedula"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Nota"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    lista = new List<Datos>();
                }
            }
            return lista;
        }
    }
}
