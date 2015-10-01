using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IQPlot
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Port = args[0];
                BaudRate = Convert.ToInt32(args[1]);
            }
            if(args.Length > 0)
            {
                pipeName = args[0];
            }
            System.Diagnostics.Debug.WriteLine("pipeName :" + pipeName);
            System.Diagnostics.Debug.WriteLine("23456");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IQPlotForm());
        }

        public static string Port = "COM3";
        public static int BaudRate = 9600;
        public static string pipeName = "SkytraqIQPlotPipe";
    }
}
