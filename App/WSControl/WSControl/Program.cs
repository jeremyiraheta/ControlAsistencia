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
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("WSControl", System.Reflection.Assembly.GetExecutingAssembly().Location);      
            if (Environment.UserInteractive)
            {
                ControlService test = new ControlService();                
                Login login = new Login();
                if(login.ShowDialog() == DialogResult.OK)
                {
                    test.TestStartupAndStop(args);
                    Application.EnableVisualStyles();
                    Application.Run();
                }               
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ControlService()
                };
                Login login = new Login();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    ServiceBase.Run(ServicesToRun);
                    Application.EnableVisualStyles();
                    Application.Run();
                }                
            }
            
        }

    }
}
