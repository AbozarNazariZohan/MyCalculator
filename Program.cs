using System;
using System.Windows.Forms;

namespace SpecialCalculator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // It builds a file to keep previous calculations
            UniversalSetting.CreateFile();



            Application.Run(new Form1());


        }
    }
}



