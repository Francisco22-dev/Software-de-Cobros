using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_NumeroR
    {
        // Variable privada para llevar el contador en memoria
        private int contador;

        // Instancia del repository para acceder a la base de datos
        private CD_NumeroR repository;

        /// <summary>
        /// Constructor que recibe la cadena de conexión (usada desde Conexion.cadena)
        /// y carga el valor actual del contador.
        /// </summary>
        public CN_NumeroR(string connectionString)
        {
            repository = new CD_NumeroR(connectionString);
            contador = repository.LoadCounter();
        }

        /// <summary>
        /// Devuelve el número formateado en 8 dígitos, incrementa el contador 
        /// y actualiza el valor en la base de datos.
        /// Ejemplo: "00000001"
        /// </summary>
        /// <returns>El número formateado</returns>
        public string ObtenerNumeroFormateado()
        {
            string numeroFormateado = contador.ToString("D8");
            contador++;
            repository.SaveCounter(contador);
            return numeroFormateado;
        }
    }
}
