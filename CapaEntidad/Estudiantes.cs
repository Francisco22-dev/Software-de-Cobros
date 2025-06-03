using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Estudiantes
    {
       /* public int idEstudiantes { get; set; }*/
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public CE_Cursos oCursos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime fechacreacion { get; set; }
        public Horarios oHorario { get; set; }
        public string Montoini { get; set; }
        public Dias oDia { get; set; }
        public Tipos oTipo { get; set; }
        public string Referencia { get; set; }
        public string Bancos { get; set; }
        public Concepto oConcepto { get; set; }
        public string Recibo  { get; set; }
    }
}
       