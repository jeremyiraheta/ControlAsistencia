using System;

namespace Interfaz.modelos
{
    public class Ubicacion
    {
        public int codemp { get; set; }
        public int codcli { get; set; }
        public string fecha { get; set; }
        public string horaentrada { get; set; }
        public string horasalida { get; set; }
        public double latinicial { get; set; }
        public double longinicial { get; set; }
        public string direccioninicial { get; set; }

        public double latfinal { get; set; }
        public double longfinal { get; set; }
        public string direccionfinal { get; set; }
        public decimal total { get; set; }





       




        public Ubicacion()
        {

        }

        public string nacimientoformat
        {
            get
            {
                try
                {
                    return fecha.Split(new char[] { '-', 'T' })[2] + "/" + fecha.Split(new char[] { '-' })[1] + "/" + fecha.Split(new char[] { '-' })[0];
                }
                catch (Exception)
                {
                    return fecha;
                }
            }
        }


    }
}