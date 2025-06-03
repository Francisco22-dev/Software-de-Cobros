using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objcd_Reporte = new CD_Reporte();

        public List<Reportes> Registro(DateTime fechaInicio, DateTime fechaFin, int idCurso)
        {
            return objcd_Reporte.Registro(fechaInicio, fechaFin, idCurso);
        }

        private CD_Reporte objcd_ReportePendientes = new CD_Reporte();

        public List<Reportes> RegistroPendientesHoy(DateTime fechaHoy, int idCurso)
        {
            return objcd_ReportePendientes.RegistroPendientesHoy(fechaHoy, idCurso);
        }

    }


}
