using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class LicenseManager
    {
        private DateTime lastUnlockDate;

        public LicenseManager()
        {
            // Carga la fecha de desbloqueo desde la base de datos
            lastUnlockDate = LoadLastUnlockDate();
        }

        // Comprueba si la licencia aún es válida (es decir, si aún no ha pasado un mes)
        public bool IsLicenseValid()
        {
            DateTime expirationDate = lastUnlockDate.AddMonths(2);
            return DateTime.Now <= expirationDate;
        }

        // Valida el código ingresado por el usuario
        public bool ValidateLicenseCode(string inputCode)
        {
            string validCode = GetLicenseCodeFromDb();
            return inputCode.Equals(validCode, StringComparison.Ordinal);
        }

        // Actualiza la fecha de desbloqueo en la base de datos y en la instancia actual
        public void UpdateUnlockDate(DateTime newDate)
        {
            lastUnlockDate = newDate;
            SaveLastUnlockDate(newDate);
        }

        // Método que obtiene la última fecha de desbloqueo de la base de datos
        private DateTime LoadLastUnlockDate()
        {
            DateTime date = DateTime.Now; // Valor por defecto
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                string query = "SELECT FechaUltimoDesbloqueo FROM Licencias"; // Ajusta el query según tu estructura
                using (SqlCommand cmd = new SqlCommand(query, oconexion))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        date = Convert.ToDateTime(result);
                    }
                }
            }
            return date;
        }

        // Método para guardar la nueva fecha de desbloqueo en la base de datos
        private void SaveLastUnlockDate(DateTime date)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                string query = "UPDATE Licencias SET FechaUltimoDesbloqueo = @date"; // Ajusta el query según tu estructura
                using (SqlCommand cmd = new SqlCommand(query, oconexion))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método que obtiene la combinación (código de licencia) almacenada en la base de datos
        private string GetLicenseCodeFromDb()
        {
            string code = string.Empty;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                string query = "SELECT Codigo FROM Licencias"; // Ajusta el query según tu estructura
                using (SqlCommand cmd = new SqlCommand(query, oconexion))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        code = result.ToString();
                    }
                }
            }
            return code;
        }
    }
}
