﻿

namespace Interfaz.modelos
{
		public class Permiso
{
    public int codper { get; set; }
    public int codemp { get; set; }
    public int codcli { get; set; }
    public string fecha { get; set; }
    public char tipo { get; set; }
    public string descripcion { get; set; }
    public string horainicial { get; set; }
    public string horafinal { get; set; }
    public char estado { get; set; }
    public bool attch { get; set; }
    public Permiso()
    {

    }
    public string formatTipo()
    {
        switch(tipo)
        {
            case 'P': return "PARTICULAR";
            case 'S': return "SALUD";
            case 'O': return "OFICIAL";
        }
        return "";
    }
} /**/
	}