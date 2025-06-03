using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permisos objcdpermi = new CD_Permisos();

        public List<Permiso> Listar(int idUsuario)
        {
            return objcdpermi.Listar(idUsuario);
        }
    }
}
