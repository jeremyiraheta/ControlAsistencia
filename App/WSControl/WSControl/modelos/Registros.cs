using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSControl.modelos
{
    class Registros
    {
        public int codemp { get; set; }
        public string fecha { get; set; }
        public string horaentrada { get; set; }
        public string horasalida { get; set; }
        public Registros()
        {

        }
        public Registros(string horaentrada, string horasalida)
        {
            this.horaentrada = horaentrada;
            this.horasalida = horasalida;
        }
    }
}
