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
    public class CN_RegisUni
    {
        private CD_RegisUni objcdRegistroUni = new CD_RegisUni();

        public bool RegistrarUni(Uniformes obj, DataTable Regis, out string Mensaje)
        {
            return objcdRegistroUni.RegistrarUni(obj, Regis, out Mensaje);
        }
    }
}
