using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CapaDatos
{
    public class CDUsuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT u.idUsuario,u.NroDocumento,u.NombreCompleto,u.Clave,u.Estado,r.idrol,r.descripcion from Usuario u ");
                    query.Append("inner join rol r on r.idrol = u.idrol");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                NroDocumento = dr["NroDocumento"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol()
                                {
                                    idrol = Convert.ToInt32(dr["idrol"]),
                                    descripcion = dr["descripcion"].ToString()
                                }
                            });
                        }
                    }

                }catch(Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idUsuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Documento", obj.NroDocumento);                    
                    cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@idrol", obj.oRol.idrol);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.Add("@idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    idUsuariogenerado = Convert.ToInt32(cmd.Parameters["@idResultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                idUsuariogenerado = 0;
            }
            return idUsuariogenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Documento", obj.NroDocumento);
                    cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@idrol", obj.oRol.idrol);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Respuesta = false;
            }
            return Respuesta;
        }

        public bool EliminarUsuario(Usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Respuesta = false;
            }
            return Respuesta;
        }
    }
}
