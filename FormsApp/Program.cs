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
            Application.Run(new AuthForm());
            //Application.Run(new AdminForm());
            //Application.Run(new StartTestForm());
        }
    }
}
