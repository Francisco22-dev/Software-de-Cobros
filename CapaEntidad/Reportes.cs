using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reportes
    {
        public string FechaRegistro { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Curso { get; set; }
        public string Horario { get; set; }
        public string Día { get; set; }
        public string MontoTotal { get; set; }
        public string TipoPago { get; set; }
        public string Concepto { get; set; }
        public string Banco { get; set; }
        public string Referencia { get; set; }
        public bool Estado { get; set; }
        public string NumeroClase { get; set; }
        public string Recibo { get; set; }
        public string FechaVencimiento { get; set; }
        public int idEstado { get; set; }
    }
}
