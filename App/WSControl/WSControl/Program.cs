using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSControl
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {            
            if (Environment.UserInteractive)
            {
                ControlService test = new ControlService();
                Application.EnableVisualStyles();
                Application.Run();
                test.TestStartupAndStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ControlService()
                };
                ServiceBase.Run(ServicesToRun);
            }
            
        }

    }
}
