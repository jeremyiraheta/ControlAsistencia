using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz.modelos
{
    public class Productividad
    {
        public int codprod { set; get; }
        public int codemp { set; get; }
        public int codcli { set; get; }
        public string procesos { set; get; }
        public string histnav { set; get; }
        public string fecha { set; get; }
        public bool attch { set; get; }
        
        public Productividad()
        {

        }
    }
}
