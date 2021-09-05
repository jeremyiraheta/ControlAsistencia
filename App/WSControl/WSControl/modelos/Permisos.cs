using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSControl.modelos
{
    class Permisos
    {
        public int codper { get; set; }
        public int codemp { get; set; }
        public string fecha { get; set; }
        public char tipo { get; set; }
        public string descripcion { get; set; }
        public string horainicial { get; set; }
        public string horafinal { get; set; }
        public char estado { get; set; }
        public bool attch { get; set; }
        public Permisos()
        {

        }
    }
}
