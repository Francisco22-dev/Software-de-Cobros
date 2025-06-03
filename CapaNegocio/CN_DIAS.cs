using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_DIAS
    {
        private CD_DIAS objcd_Dias = new CD_DIAS();

        public List<Dias> Listar()
        {
            return objcd_Dias.Listar();
        }
    }
}
