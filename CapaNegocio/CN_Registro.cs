using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Registro
    {
        private CD_Registro objcdRegistro = new CD_Registro();

        /*public int ObtenerCorrelativo()
        {
            return objcdRegistro.obtenercorrelativo();
        }*/

        public bool Registrar(Estudiantes obj, DataTable Pagos, out string Mensaje)
        {
            return objcdRegistro.Registrar(obj, Pagos, out Mensaje);
        }

        private CD_Registro objcdRegistroViejos = new CD_Registro();

        public bool Registrar_Estudiantes_Viejos(Estudiantes obj, DataTable Pagos, out string Mensaje)
        {
            return objcdRegistroViejos.Registrar_Estudiantes_Viejos(obj, Pagos, out Mensaje);
        }
    }
}
