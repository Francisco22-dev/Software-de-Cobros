using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class HTML
    {
        public class NonClosingStringReader : StringReader
        {
            public NonClosingStringReader(string s) : base(s) { }

            // Anula Close para evitar que se cierre el TextReader prematuramente.
            public override void Close()
            {
                // No se realiza ninguna acción.
            }
        }
    }
}
