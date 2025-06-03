using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Corte
    {
        private CD_Corte objcd_Corte = new CD_Corte();

        public List<Reportes> Registro(DateTime fechaHoy)
        {
            return objcd_Corte.Registro(fechaHoy);
        }
    }
}
