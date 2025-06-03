using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pagos
    {
        public int idPagos { get; set; }
        public Estudiantes oEstudiantes { get; set; }
        public CE_Cursos oCursos { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string MontoTotal { get; set; }
        public bool Estado { get; set; }
        public DateTime fechacreacion { get; set; }
        public Tipos oTipo { get; set; }
        public string Bancos { get; set; }
        public string Referencia { get; set; }
        public Concepto oConcepto { get; set; }
        public Horarios oHorario { get; set; }
        public Dias oDia { get; set; }
        public string NumeroClase { get; set; }
        public string Recibo { get; set; }

    }
}
