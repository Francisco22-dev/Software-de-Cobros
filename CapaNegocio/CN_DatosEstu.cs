using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_DatosEstu
    {
        private CD_DatosEstu objcd_Dato = new CD_DatosEstu();

        public List<Datos> Datitos()
        {
            return objcd_Dato.Datitos();
        }

        private CD_DatosEstu objcd_Datoviejo = new CD_DatosEstu();

        public List<Datos> DatitosViejitos()
        {
            return objcd_Datoviejo.DatitosViejitos();
        }
    }
}
