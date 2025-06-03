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
    public class CN_Autocompletar
    {
        private CD_Autocompletar objcdAutocompletar = new CD_Autocompletar();
        public StudentData BuscarDatosEstudiante(string cedula, out string Mensaje)
        {
            return objcdAutocompletar.BuscarDatosEstudiante(cedula, out Mensaje);
        }
        public List<StudentData> ListarTodos()
        {
            return new CD_Autocompletar().ListarTodos();
        }
    }
}
