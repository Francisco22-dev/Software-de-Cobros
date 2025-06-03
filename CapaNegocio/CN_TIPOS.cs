using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TIPOS
    {
        private Tipos_de_Pago objcd_Tipos = new Tipos_de_Pago();

        public List<Tipos> Listar()
        {
            return objcd_Tipos.Listar();
        }
    }
}
