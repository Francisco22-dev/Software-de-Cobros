using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_NumeroP
    {
        // Variable privada para llevar el contador en memoria
        private int contador;

        // Instancia del repository para acceder a la base de datos
        private CD_NumeroP repository;

        /// <summary>
        /// Constructor que recibe el connectionString, inicializa el repository 
        /// y carga el contador desde la base de datos.
        /// </summary>
        public CN_NumeroP(string connectionString)
        {
            repository = new CD_NumeroP(connectionString);
            contador = repository.LoadCounter();
        }

        /// <summary>
        /// Devuelve el número formateado en 8 dígitos, incrementa el contador 
        /// y lo guarda en la base de datos.
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
