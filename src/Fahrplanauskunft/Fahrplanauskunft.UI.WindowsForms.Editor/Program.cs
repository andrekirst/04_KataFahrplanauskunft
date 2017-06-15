// <copyright file="Program.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace Fahrplanauskunft.UI.WindowsForms.Editor
{
    /// <summary>
    /// Startklasse für die UI
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using(Form1 form1 = new Form1())
            {
                Application.Run(form1);
            }
        }
    }
}
