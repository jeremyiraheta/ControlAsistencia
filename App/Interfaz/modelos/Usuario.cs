using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz.modelos
{
    /// <summary>
    /// Entidad de Usuario
    /// </summary>
    public class Usuario
    {
        public int codemp { get; set; }
        public int codcli { get; set; }
        public char estado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string departamento { get; set; }
        public bool admin { get; set; }
        public Usuario()
        {

        }
    }
}
