using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cursos
    {
        private CD_Cursos objcd_cursos = new CD_Cursos();

        public List<CE_Cursos> Listar()
        {
            return objcd_cursos.Listar();
        }
    }
}
