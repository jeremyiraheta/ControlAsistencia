using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSControl.modelos
{
    class Permisos
    {
        public int CODPER { get; set; }
        public int CODEMP { get; set; }
        public string FECHA { get; set; }
        public char TIPO { get; set; }
        public string DESCRIPCION { get; set; }
        public string HORAINICIAL { get; set; }
        public string HORAFINAL { get; set; }
        public char ESTADO { get; set; }

    }
}
