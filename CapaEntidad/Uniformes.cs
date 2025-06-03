using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Uniformes
    {
        public Estudiantes oEstudiantes { get; set; }
        public string Cedula { get; set; }
        public TallaCam oTallaCam { get; set; }
        public TallaPan oTallaPan { get; set; }
        public CE_Cursos oCursos { get; set; }
        public Concepto oConcepto { get; set; }
        public string MontoTotal { get; set; }
        public Tipos oTipo { get; set; }
        public string Banco { get; set; }
        public string Referencia { get; set; }
        public DateTime FechaPago { get; set; }
        public string Recibo { get; set; }
    }
}
