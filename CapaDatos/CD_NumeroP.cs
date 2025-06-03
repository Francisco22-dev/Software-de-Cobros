using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_NumeroP
    {
        private readonly string connectionString = Conexion.cadena;

        public CD_NumeroP(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int LoadCounter()
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                // Se asume que hay una única fila en la tabla
                string query = "SELECT TOP 1 contador FROM Contador";
                using (SqlCommand command = new SqlCommand(query.ToString(), oconexion))
                {
                    oconexion.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int resultCounter))
                    {
                        return resultCounter;
                    }
                    else
                    {
                        return 1; // Valor por defecto
                    }
                }
            }
        }

        /// <summary>
        /// Guarda el valor actual del contador en la base de datos.
        /// </summary>
        public void SaveCounter(int counter)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                connection.Open();
                string query = "UPDATE Contador SET contador = @contador";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@contador", counter);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
