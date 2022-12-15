using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sana_Last_Na_to
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.wwwww
        /// </summary>
        [STAThread]

        // in starting the program the start screen will appear once it run
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreen());
        }
    }
}
