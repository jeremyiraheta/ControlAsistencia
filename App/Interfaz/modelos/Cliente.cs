using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz.modelos
{
    public class Cliente
    {
        public int codcli { set; get; }
        public string nombre { set; get; }
        public string url { set; get; }
        public string urlnom { set; get; }
        public string correo_contacto { set; get; }
        public string telefono_contacto { set; get; }
        public string direccion { get; set; }
        public string fecha_registro { set; get; }
        public string fecha_fin_servicio { set; get; }
        public int plan { set; get; }
        public bool capturarpantalla { set; get; }
        public bool capturarprocesos { set; get; }
        public bool capturarhistorialnav { set; get; }
        public string loginbackground { set; get; }
        public int zonahoraria { set; get; }
        public string pais { set; get; }
        public int invervalo { set; get; }
        public float porctcapt { set; get; }
        public bool activo { set; get; }
        public bool attch { set; get; }

        public Cliente()
        {

        }

        public string fecha_registro_format
        {
            get
            {
                try
                {
                    return fecha_registro.Split(new char[] { '-', 'T' })[2] + "/" + fecha_registro.Split(new char[] { '-' })[1] + "/" + fecha_registro.Split(new char[] { '-' })[0];
                }
                catch (Exception)
                {
                    return fecha_registro;
                }
            }
        }

        public string fecha_fin_servicio_format
        {
            get
            {
                try
                {
                    return fecha_fin_servicio.Split(new char[] { '-', 'T' })[2] + "/" + fecha_fin_servicio.Split(new char[] { '-' })[1] + "/" + fecha_fin_servicio.Split(new char[] { '-' })[0];
                }
                catch (Exception)
                {
                    return fecha_fin_servicio;
                }
            }
        }
    }
}
