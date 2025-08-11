using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace CapaDatos
{
    public class CD_Registro
    {
        /*public int obtenercorrelativo()
        {
            int idcorrelativo = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) +1 from Pagos");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
                return idcorrelativo;
            }

        }  */
        public bool Registrar(Estudiantes obj, DataTable Pagos, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Inscripciones", oconexion);
                    /*cmd.Parameters.AddWithValue("@idEstudiantes", obj.idEstudiantes);*/
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@idCursos", obj.oCursos.idCursos);
                    cmd.Parameters.AddWithValue("@idHorario", obj.oHorario.idHorario);
                    cmd.Parameters.AddWithValue("@Montoini", obj.Montoini);
                    cmd.Parameters.AddWithValue("@idDias", obj.oDia.idDias);
                    cmd.Parameters.AddWithValue("@fechacreacion", obj.fechacreacion);
                    cmd.Parameters.AddWithValue("@idTipos", obj.oTipo.idTipos);
                    cmd.Parameters.AddWithValue("@Referencia", obj.Referencia);
                    cmd.Parameters.AddWithValue("@Bancos", obj.Bancos);
                    cmd.Parameters.AddWithValue("@idConcepto", obj.oConcepto.idConcepto);
                    cmd.Parameters.AddWithValue("@Recibo", obj.Recibo);
                    cmd.Parameters.AddWithValue("@Pago", obj.Pago);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
                return Respuesta;
            }
        }


            public bool Registrar_Estudiantes_Viejos(Estudiantes obj, DataTable Pagos, out string Mensaje)
            {
                bool Respuesta = false;
                Mensaje = string.Empty;
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InscripcionesViejos", oconexion);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
                return Respuesta;
            }
        }
    }
}
