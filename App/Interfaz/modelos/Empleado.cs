using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interfaz.modelos
{
    /// <summary>
    /// Descripción breve de Empleados
    /// </summary>
    public class Empleado
    {
        public int codemp { get; set; }
        public int coddpto { get; set; }
        public int codcli { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefonos { get; set; }
        public string correo { get; set; }
        public string nacimiento { get; set; }
        public string genero { get; set; }
        public string direccion { get; set; }
        public string dui { get; set; }
        public string nit { get; set; }
        public string afp { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public bool activo { get; set; }
        public Empleado()
        {

        }
        public string nacimientoformat
        {
            get
            {
                try
                {
                    return nacimiento.Split(new char[] { '-', 'T' })[2] + "/" + nacimiento.Split(new char[] { '-' })[1] + "/" + nacimiento.Split(new char[] { '-' })[0];
                }
                catch (Exception)
                {
                    return nacimiento;
                }
            }
        } 
    }
}