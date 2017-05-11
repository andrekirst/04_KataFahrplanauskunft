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
        /// Wenn der Parameter obj den Wert Null hat, muss die Methode den Wert false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Parameter_obj_Ist_Null()
        {
            bool expected = false;
            bool actual = EqualsHelper.EqualBase<Linie>(null, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn der Parameter obj einen anderen Typ hat, als es der Typ T vorgibt, muss die Methode false zurückgegeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Paramter_obj_falscher_Typ()
        {
            Haltestelle haltestelle = new Haltestelle();

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(haltestelle, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn der Parameter custom Null ist, muss die Methode false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Paramter_custom_Ist_Null()
        {
            Linie linie = new Linie();

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(linie, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn der Parameter obj den Wert Null hat, muss die Methode den Wert false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Equatable_Parameter_obj_Ist_Null()
        {
            bool expected = false;
            bool actual = EqualsHelper.EqualBase<Linie>(null, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn der Parameter obj einen anderen Typ hat, als es der Typ T vorgibt, muss die Methode false zurückgegeben
        /// </summary>
        [TestMethod, TestCategory("EqualsHelper")]
        public void EqualsHelper_Equatable_Paramter_obj_falscher_Typ()
        {
            Haltestelle haltestelle = new Haltestelle();

            bool expected = false;

            bool actual = EqualsHelper.EqualBase<Linie>(haltestelle, null);

            Assert.AreEqual(expected, actual);
        }

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
            Linie linie = new Linie("Linie 1", "L1");
            Linie linie2 = new Linie("Linie 2", "L2");

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
            Linie linie = new Linie("Linie 1", "L1");
            Linie linie2 = new Linie("Linie 1", "L1");

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
