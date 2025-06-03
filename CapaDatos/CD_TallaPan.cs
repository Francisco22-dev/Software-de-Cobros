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
    public class CD_TallaPan
    {
        public List<TallaPan> Listar()
        {
            List<TallaPan> listaPan = new List<TallaPan>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idTipoPan,Talla from Pantalon");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaPan.Add(new TallaPan()
                            {
                                idTipoPan = Convert.ToInt32(dr["idTipoPan"]),
                                Talla = dr["Talla"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaPan = new List<TallaPan>();
                }
            }
            return listaPan;


        }
    }
}
