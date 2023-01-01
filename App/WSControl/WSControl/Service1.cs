﻿using System;
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
using System.Windows.Forms;
using System.Drawing;
using System.IO;

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
            MainWin.Instance.Show();
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
        
        public static async void prod()
        {
            API api = new API();
            while (true)
            {
                Thread.Sleep(1000 * 60 * 60);
                try
                {
                    int r = new Random().Next(0, 100);
                    if(r > 50)
                    {
                        
                    }
                }
                catch (Exception)
                {
                }                
            }
        }
        public static byte[] capturarPantalla()
        {
            MemoryStream memory = new MemoryStream();
            Screen scr = Screen.PrimaryScreen;
            Bitmap img = new Bitmap(scr.Bounds.Width, scr.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gr = Graphics.FromImage(img);
            gr.CopyFromScreen(scr.Bounds.Left, scr.Bounds.Top, 0, 0, scr.Bounds.Size);
            img.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            return memory.ToArray();
        }
    }
}
