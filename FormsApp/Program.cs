using System;
using System.Windows.Forms;
using FormsApp.Authorization;
using FormsApp.Administrator;
using FormsApp.Test;

namespace FormsApp
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

            /// <summary>
            /// Entry point
            /// </summary>
            Application.Run(new AuthForm());

            /// <summary>
            /// Admin part point for debug and exploration
            /// </summary>
            //Application.Run(new AdminForm());

            /// <summary>
            /// Test part point for debug and exploration
            /// </summary>
            //Application.Run(new StartTestForm());
        }
    }
}
