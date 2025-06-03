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
    public class CN_EditarCurso
    {
        private CD_EditarCurso objcdEditarCurso = new CD_EditarCurso();
        public bool EditarCurso(CE_Cursos obj, DataTable curso, out string Mensaje)
        {
            return objcdEditarCurso.EditarCurso(obj, curso, out Mensaje);
        }
    }
}
