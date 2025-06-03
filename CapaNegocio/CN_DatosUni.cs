using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_DatosUni
    {
        private CD_DatosUni objcd_DatoU = new CD_DatosUni();

        public List<DatosUni> DatosU()
        {
            return objcd_DatoU.DatosU();
        }
    }
}
