using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_CorteU
    {
        private CD_CorteU objcd_CorteU = new CD_CorteU();

        public List<CorteUni> DatosU(DateTime fechaHoy)
        {
            return objcd_CorteU.DatosU(fechaHoy);
        }
    }
}
