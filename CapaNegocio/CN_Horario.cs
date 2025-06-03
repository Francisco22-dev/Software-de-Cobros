using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Horario
    {
        private CD_HORARIOS objcd_Horarios = new CD_HORARIOS();

        public List<Horarios> Listar()
        {
            return objcd_Horarios.Listar();
        }
    }
}
