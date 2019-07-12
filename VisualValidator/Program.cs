﻿using System;
using System.Windows.Forms;

namespace VisualValidator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using var mainForm = new Form1();
            Application.Run(mainForm);
        }
    }
}
