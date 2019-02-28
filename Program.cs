using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Caesar_TestFaker
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Watermark());
        }
    }
}
