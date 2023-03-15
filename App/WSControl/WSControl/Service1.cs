using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Interfaz.modelos;
using Interfaz;
using System.Text;
using System.Data.SQLite;

namespace WSControl
{
    public partial class ControlService : ServiceBase
    {
        const int TICK_MIN = 1;       
        public ControlService()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Carga el servicio si no esta instalado como si fuerea una aplicacion normal
        /// </summary>
        /// <param name="args"></param>
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
        }
        /// <summary>
        /// Punto de montaje del servicio
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {            
            c_systray.Visible = true;
            Datos.tickRegistro(Login.usuario.codemp, Login.usuario.codcli, true);
            Thread threadmon = new Thread(mon);
            Thread threadprod = new Thread(prod);
            threadmon.Start();
            threadprod.Start();
            
        }
        /// <summary>
        /// Punto de terminacion del servicio
        /// </summary>
        protected override void OnStop()
        {
            Datos.tickRegistro(Login.usuario.codemp, Login.usuario.codcli, false);
        }       
        /// <summary>
        /// Evento que se activa al clicar en el icono de la barra de notificacion de windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_systray_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {            
             MainWin.Instance.Show();
        }
        /// <summary>
        /// Demonio principal para registrar las horas de salida cada minuto
        /// </summary>
        public static void mon()
        {            
            while(true)
            {
                try
                {
                    Datos.tickRegistro(Login.usuario.codemp, Login.usuario.codcli, false);
                }
                catch (Exception)
                {
                }
                Thread.Sleep(TICK_MIN * 1000 * 60);
            }
        }
        
        public static void prod()
        {
            Cliente cliente = Datos.getCliente(Login.usuario.codcli);
            if(cliente.capturarpantalla || cliente.capturarhistorialnav || cliente.capturarprocesos)
            while (true)
            {
                Thread.Sleep(1000 * 60 * cliente.invervalo);
                try
                {
                    int r = new Random().Next(0, 100);
                    if(r < cliente.porctcapt)
                    {
                            String proc = "";
                            String nav = "";
                            try
                            {
                                if (cliente.capturarprocesos) proc = listarProcesos();
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                if (cliente.capturarhistorialnav) nav = historyNav();
                            }
                            catch (Exception)
                            {
                            }
                            var prod = Datos.insertProductividad(new Productividad() { codcli = Login.usuario.codcli, codemp = Login.usuario.codemp, procesos = proc, histnav = nav });
                            if(cliente.capturarpantalla) Datos.uploadCaptura(prod.insertId, Login.usuario.codcli, capturarPantalla());
                        }
                }
                catch (Exception)
                {
                }                
            }
        }
        private static byte[] capturarPantalla()
        {
            MemoryStream memory = new MemoryStream();
            Screen scr = Screen.PrimaryScreen;
            Bitmap img = new Bitmap(scr.Bounds.Width, scr.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gr = Graphics.FromImage(img);
            gr.CopyFromScreen(scr.Bounds.Left, scr.Bounds.Top, 0, 0, scr.Bounds.Size);
            img.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            return memory.ToArray();
        }

        private static String listarProcesos()
        {
            Process[] process = Process.GetProcesses();
            StringBuilder build = new StringBuilder();
            foreach (var item in process)
            {
                try
                {
                    if(item.MainWindowTitle != null && item.MainWindowTitle.Trim().Length > 0)
                        build.AppendLine($"* Proceso: {item.ProcessName}, Nombre: {item.MainWindowTitle}, Tiempo Activo: {Math.Round(item.TotalProcessorTime.TotalMinutes, 2)} Mins");
                }
                catch (Exception)
                {
                }
            }            
            return Uri.EscapeUriString(build.ToString());
        }

        private static String historyNav()
        {
            StringBuilder build = new StringBuilder();
            String hisdir = Environment.GetEnvironmentVariable("appdata") + "\\..\\Local\\Google\\Chrome\\User Data\\Default\\History";
            String temp = Environment.GetEnvironmentVariable("temp") + "\\Historytemp";
            File.Copy(hisdir, temp);
            SQLiteConnection con = new SQLiteConnection($"Data Source={temp};Compress=True;");
            con.Open();
            int dn = DateTime.Now.Date.Day;
            int mn = DateTime.Now.Date.Month;
            int yn = DateTime.Now.Date.Year;
            SQLiteCommand cmd = new SQLiteCommand("select * from urls where last_visit_time > 0 order by last_visit_time asc", con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                long utcMicroSeconds = reader.GetInt64(5);                
                DateTime gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds);
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);
                int d = localTime.Day;
                int m = localTime.Month;
                int y = localTime.Year;                
                if(d == dn && m == mn && y == yn)
                    build.AppendLine($"URL: {reader.GetString(1)}, Titulo: {reader.GetString(2)}, Fecha: {localTime}");
            }

            File.Delete(temp);
            return Uri.EscapeUriString(build.ToString()) ;
        }
    }
}
