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
using WSControl.modelos;

namespace WSControl
{
    public partial class ControlService : ServiceBase
    {
        const int TICK_MIN = 1;
        private static int codemp = 0;
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
            API registros= new API();
            c_systray.Visible = true;
            codemp = Login.codemp;
            var task = Task.Run(() => registros.post($"registros/{codemp}"));
            task.Wait();
            Thread thread = new Thread(mon);
            thread.Start();
        }
        /// <summary>
        /// Punto de terminacion del servicio
        /// </summary>
        protected override void OnStop()
        {
            API api = new API();
            var task = Task.Run(() => api.put($"registros/{codemp}"));
            task.Wait();
        }       
        /// <summary>
        /// Evento que se activa al clicar en el icono de la barra de notificacion de windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_systray_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {            
            Main.Instance.Show();
        }
        /// <summary>
        /// Demonio principal para registrar las horas de salida cada minuto
        /// </summary>
        public static async void mon()
        {
            API api = new API();
            while(true)
            {
                try
                {
                    await api.put($"registros/{codemp}");
                }
                catch (Exception)
                {
                }
                Thread.Sleep(TICK_MIN * 1000 * 60);
            }
        }
    }
}
