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
    public class CD_RegisUni
    {
        public bool RegistrarUni(Uniformes obj, DataTable Regis, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UniformesRegis", oconexion);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.oEstudiantes.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("@idTipoCam", obj.oTallaCam.idTipoCam);
                    cmd.Parameters.AddWithValue("@idTipoPan", obj.oTallaPan.idTipoPan);
                    cmd.Parameters.AddWithValue("@idCursos", obj.oCursos.idCursos);
                    cmd.Parameters.AddWithValue("@MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("@idTipos", obj.oTipo.idTipos);
                    cmd.Parameters.AddWithValue("@Banco", obj.Banco);
                    cmd.Parameters.AddWithValue("@Referencia", obj.Referencia);
                    cmd.Parameters.AddWithValue("@FechaPago", obj.FechaPago);
                    cmd.Parameters.AddWithValue("@idConcepto", obj.oConcepto.idConcepto);
                    cmd.Parameters.AddWithValue("@Recibo", obj.Recibo);
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
