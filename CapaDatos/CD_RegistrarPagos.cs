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
    public class CD_RegistrarPagos
    {
        public bool RegistrarPago(Pagos obj, DataTable pagos, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistroPagos", oconexion);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("@idCursos", obj.oCursos.idCursos);
                    cmd.Parameters.AddWithValue("@idHorario", obj.oHorario.idHorario);
                    cmd.Parameters.AddWithValue("@MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("@idDias", obj.oDia.idDias);
                    cmd.Parameters.AddWithValue("@fechacreacion", obj.fechacreacion);
                    cmd.Parameters.AddWithValue("@idTipos", obj.oTipo.idTipos);
                    cmd.Parameters.AddWithValue("@Referencia", obj.Referencia);
                    cmd.Parameters.AddWithValue("@Bancos", obj.Bancos);
                    cmd.Parameters.AddWithValue("@idConcepto", obj.oConcepto.idConcepto);
                    cmd.Parameters.AddWithValue("@NumeroClase", obj.NumeroClase);
                    cmd.Parameters.AddWithValue("@Recibo", obj.Recibo);
                    cmd.Parameters.AddWithValue("@Pago", pagos);
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
