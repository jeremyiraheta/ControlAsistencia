using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WSControl
{
    public partial class ControlService : ServiceBase
    {
        const string api = "http://localhost:8000/";
        HttpClient client = null;
        public ControlService()
        {
            InitializeComponent();
        }
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }
        protected override void OnStart(string[] args)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(api);
            while (true)
            {
                Console.WriteLine("Guardando hora salida....");
                System.Threading.Thread.Sleep(60000);
            }
        }

        protected override void OnStop()
        {
        }       

        private void c_systray_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            new ListadoPermisos().Show();
        }

        
    }
}
