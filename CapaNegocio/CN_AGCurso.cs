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
    public class CN_AGCurso
    {
        private CD_AGCurso objcdRegistrarCurso = new CD_AGCurso();
        public bool RegistrarCurso(CE_Cursos obj, DataTable pagos, out string Mensaje)
        {
            return objcdRegistrarCurso.RegistrarCurso(obj, pagos, out Mensaje);
        }
    }
}
