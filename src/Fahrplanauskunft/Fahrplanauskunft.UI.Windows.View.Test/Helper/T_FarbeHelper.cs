// <copyright file="T_FarbeHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.UI.Windows.View.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.UI.Windows.View.Test.Helper
{
    [TestClass]
    public class T_FarbeHelper
    {
        [TestMethod]
        [TestCategory("FarbeHelper")]
        public void FarbeHelper_Farbe_FFFFFF_Schriftfarbe_000000()
        {
            string expected = "#000000";
            string actual = FarbeHelper.BerechneVordergrundfarbeAnhandHintergrundfarbe(farbe: "#FFFFFF");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("FarbeHelper")]
        public void FarbeHelper_Farbe_000000_Schriftfarbe_FFFFFF()
        {
            string expected = "#FFFFFF";
            string actual = FarbeHelper.BerechneVordergrundfarbeAnhandHintergrundfarbe(farbe: "#000000");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("FarbeHelper")]
        public void FarbeHelper_Ungueltige_Farabe_23_gibt_Farbe_000000_zurueck()
        {
            string expected = "#000000";
            string actual = FarbeHelper.BerechneVordergrundfarbeAnhandHintergrundfarbe(farbe: "#23");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FarbeHelper_Farbe_8519FB_Schriftfarbe_FFFFFF()
        {
            string expected = "#FFFFFF";
            string actual = FarbeHelper.BerechneVordergrundfarbeAnhandHintergrundfarbe(farbe: "#8519FB");

            Assert.AreEqual(expected, actual);
        }
    }
}
