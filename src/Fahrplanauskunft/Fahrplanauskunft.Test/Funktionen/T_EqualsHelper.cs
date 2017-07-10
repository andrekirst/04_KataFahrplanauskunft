// <copyright file="T_EqualsHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Test-Klasse für EqualsHelper
    /// </summary>
    [TestClass]
    public class T_EqualsHelper
    {
        /// <summary>
        /// Wenn der Parameter custom Null ist, muss die Methode false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Equatable_Paramter_custom_Ist_Null()
        {
            Linie linie = new Linie();

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(linie, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test mit einem Vergleich, bei dem die Objekte unterschiedlich sind. Es wird false erwartet
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Equatable_Ungleich()
        {
            Linie linie = new Linie(id: "L1", name: "Linie 1", ident: "L1", farbe: "#FF4500");
            Linie linie2 = new Linie(id: "L2", name: "Linie 2", ident: "L2", farbe: "#FF4501");

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(
                linie,
                () =>
                {
                    return linie.Ident == linie2.Ident && linie.Name == linie2.Name;
                });

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test mit einem Vergleich, bei dem die Objekte gleich sind. Es wird true erwartet
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Equatable_Gleich()
        {
            Linie linie = new Linie(id: "L1", name: "Linie 1", ident: "L1", farbe: "#FF4500");
            Linie linie2 = new Linie(id: "L2", name: "Linie 1", ident: "L1", farbe: "#FF4500");

            bool expected = true;

            bool actual = EqualsHelper.EqualBase<Linie>(
                linie,
                () =>
                {
                    return linie.Ident == linie2.Ident && linie.Name == linie2.Name;
                });

            Assert.AreEqual(expected, actual);
        }
    }
}
