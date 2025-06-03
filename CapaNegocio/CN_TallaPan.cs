using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TallaPan
    {
        private CD_TallaPan objcd_Pan = new CD_TallaPan();

        public List<TallaPan> Listar()
        {
            return objcd_Pan.Listar();
        }
    }
}
