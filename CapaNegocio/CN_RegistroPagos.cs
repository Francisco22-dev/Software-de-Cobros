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
    public class CN_RegistroPagos
    {
        private CD_RegistrarPagos objcdRegistrarPago = new CD_RegistrarPagos();
        public bool RegistrarPago(Pagos obj, DataTable pagos, out string Mensaje)
        {
            return objcdRegistrarPago.RegistrarPago(obj, pagos, out Mensaje);
        }
    }
}
