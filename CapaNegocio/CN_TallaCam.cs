using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TallaCam
    {
        private CD_TallaCam objcd_Cami = new CD_TallaCam();

        public List<TallaCam> Listar()
        {
            return objcd_Cami.Listar();
        }
    }
}
