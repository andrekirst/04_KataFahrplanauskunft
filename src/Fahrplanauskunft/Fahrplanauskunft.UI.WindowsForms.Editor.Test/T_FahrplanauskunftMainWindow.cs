// <copyright file="T_FahrplanauskunftMainWindow.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.UI.WindowsForms.Editor.Test
{
    [TestClass]
    public class T_FahrplanauskunftMainWindow
    {
        [TestMethod]
        public void FahrplanauskunftMainWindow_ResourceManager_ist_gesetzt()
        {
            FahrplanauskunftMainWindow window = new FahrplanauskunftMainWindow();

            Assert.IsNotNull(window.ResourceHelper);
        }

        [TestMethod]
        public void FahrplanauskunftMainWindow_SetzeRessourcen_en_US_TabPageLinie()
        {
            string expected = "Line";

            CultureInfo currentCultureInfo = new CultureInfo(Thread.CurrentThread.CurrentUICulture.LCID);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            using(FahrplanauskunftMainWindow window = new FahrplanauskunftMainWindow())
            {
                string actual = window.NameTabPageLinie;

                Thread.CurrentThread.CurrentUICulture = currentCultureInfo;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void FahrplanauskunftMainWindow_TabControlObjekte_Eigenschaft_Dock_ist_Fill()
        {
            using(FahrplanauskunftMainWindow window = new FahrplanauskunftMainWindow())
            {
                DockStyle expected = DockStyle.Fill;

                DockStyle actual = window.DockStyleTabControlObjekte;

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
