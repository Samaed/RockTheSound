using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Server server = Server.GetInstance();
            server.Start();
            ServerSoundLibrary.GetInstance(); //Peut paraitre inutile, mais ça permet de faire l'initialisation de la library avant le premier appel de synchro
            ServerMainFrame form = ServerMainFrame.GetInstance() ;
            Application.Run(form);
            
            Application.Exit();
        }
    }
}
