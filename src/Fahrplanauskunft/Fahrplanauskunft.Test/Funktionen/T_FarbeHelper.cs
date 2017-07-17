// <copyright file="T_FarbeHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Funktionen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Test-Klasse für FarbeHelper
    /// </summary>
    [TestClass]
    public class T_FarbeHelper
    {
        /// <summary>
        /// Test, dass der Wert #000000 eine gültige Farbe ist
        /// </summary>
        [TestMethod]
        public void FarbeHelper_Farbe_000000_Ist_gueltig()
        {
            bool expected = true;
            bool actual = FarbeHelper.IstFarbeGueltig(farbe: "#000000");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass der Wert #0Z0 keine gültige Farbe ist
        /// </summary>
        [TestMethod]
        public void FarbeHelper_Farbe_0Z0_Ist_ungueltig()
        {
            bool expected = false;
            bool actual = FarbeHelper.IstFarbeGueltig(farbe: "#0Z0");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass der Wert #abc000 eine gültige Farbe ist
        /// </summary>
        [TestMethod]
        public void FarbeHelper_Farbe_abc000_ist_gueltig()
        {
            bool expected = true;
            bool actual = FarbeHelper.IstFarbeGueltig(farbe: "#abc000");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass der Wert #ABC000 eine gültige Farbe ist
        /// </summary>
        [TestMethod]
        public void FarbeHelper_Farbe_ABC000_ist_gueltig()
        {
            bool expected = true;
            bool actual = FarbeHelper.IstFarbeGueltig(farbe: "#ABC000");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass der Wert NULL keine gültige Farbe ist
        /// </summary>
        [TestMethod]
        public void FarbeHelper_Farbe_NULL_ist_ungueltig()
        {
            bool expected = false;
            bool actual = FarbeHelper.IstFarbeGueltig(farbe: null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass der Wert <see cref="string.Empty"/> keine gültige Farbe ist
        /// </summary>
        [TestMethod]
        public void FarbeHelper_Farbe_string_Empty_ist_ungueltig()
        {
            bool expected = false;
            bool actual = FarbeHelper.IstFarbeGueltig(farbe: string.Empty);

            Assert.AreEqual(expected, actual);
        }
    }
}
