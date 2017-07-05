// <copyright file="T_LinieListView.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.UI.Windows.View.Linie;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Controls;

namespace Fahrplanauskunft.UI.Windows.View.Test.Linie
{
    /// <summary>
    /// Test-Klasse für LinieListView
    /// </summary>
    [TestClass]
    public class T_LinieListView
    {
        [TestMethod]
        public void LinieListView_TextBoxSuche_EscapeInputCommand_Text_Gleich_Empty()
        {
            Window w = new Window();
            w.Content = new LinieListView();

            LinieListView llv = w.Content as LinieListView;
            w.Show();
            llv.TextBoxSuche.Focus();

            llv.TextBoxSuche.Text = "B1";

            string actual = llv.TextBoxSuche.Text;
            string expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }
    }
}
