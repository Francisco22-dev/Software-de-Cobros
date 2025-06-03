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
    public class CD_TallaCam
    {
        public List<TallaCam> Listar()
        {
            List<TallaCam> listaCam = new List<TallaCam>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idTipoCam,Talla from Camisa");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaCam.Add(new TallaCam()
                            {
                                idTipoCam = Convert.ToInt32(dr["idTipoCam"]),
                                Talla = dr["Talla"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    listaCam = new List<TallaCam>();
                }
            }
            return listaCam;


        }
    }
}
