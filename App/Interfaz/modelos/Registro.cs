namespace Interfaz.modelos
{
    public class Registro
    {
        public int codemp { get; set; }
        public int codcli { get; set; }
        public string fecha { get; set; }
        public string horaentrada { get; set; }
        public string horasalida { get; set; }
        public float total { get; set; }
        public Registro()
        {

        }
        public Registro(string horaentrada, string horasalida)
        {
            this.horaentrada = horaentrada;
            this.horasalida = horasalida;
        }
    } 
}