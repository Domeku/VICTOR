using System;
using System.Windows.Forms;
using REPORTES.Interfaces;
using REPORTES.Reportes;

namespace REPORTES
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new log());  // Abre pantalla de login
        }
    }
}
