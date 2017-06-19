// <copyright file="T_FahrplanauskunftMainWindow.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.UI.Windows.Editor.Test
{
    /// <summary>
    /// Test-Klasse für die Klasse FahrplanauskunftMainWindow
    /// </summary>
    [TestClass]
    public class T_FahrplanauskunftMainWindow
    {
        /// <summary>
        /// Test, ob der ResourceHelper initiiert ist
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftMainWindow_ResourceManager_ist_gesetzt()
        {
            FahrplanauskunftMainWindow window = new FahrplanauskunftMainWindow();
            Assert.IsNotNull(window.ResourceHelper);
        }

        /// <summary>
        /// Test, ob die Resource auf dem TabPage-Control tabPageLinie mit englischer Ressource gesetzt ist
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftMainWindow_SetzeRessourcen_en_US_TabItemLinie()
        {
            const string expected = "Line";

            CultureInfo currentCultureInfo = new CultureInfo(Thread.CurrentThread.CurrentUICulture.LCID);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            FahrplanauskunftMainWindow window = new FahrplanauskunftMainWindow();

            string actual = window.TabItemLinieText;

            Thread.CurrentThread.CurrentUICulture = currentCultureInfo;

            Assert.AreEqual(expected, actual);
        }
    }
}
