﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Test-Klasse für EqualsOperatorHelper
    /// </summary>
    [TestClass]
    public class T_EqualsOperatorHelper
    {
        /// <summary>
        /// Wenn beide Objekte Null sind, dann true zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsOperatorHelper")]
        public void EqualsOperatorHelper_Parameters_Null()
        {
            bool expected = true;
            bool actual = EqualsOperatorHelper.EqualsOperatorBase<Linie>(null, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn Objekt a nicht NULL ist und Objekt b Null ist, dann false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsOperatorHelper")]
        public void EqualsOperatorHelper_Parameter_a_Ist_Null_b_Nicht_Null()
        {
            Linie linie = new Linie(name: "Linie 1", ident: "L1");

            bool expected = false;
            bool actual = EqualsOperatorHelper.EqualsOperatorBase<Linie>(linie, null);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn Objekt b nicht NULL ist und Objekt a Null ist, dann false zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsOperatorHelper")]
        public void EqualsOperatorHelper_Parameter_a_Ist_Nicht_Null_b_ist_Null()
        {
            Linie linie = new Linie(name: "Linie 1", ident: "L1");

            bool expected = false;
            bool actual = EqualsOperatorHelper.EqualsOperatorBase<Linie>(null, linie);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Wenn beide Objekte die gleiche Instanz haben, dann true zurückgeben
        /// </summary>
        [TestMethod, TestCategory("EqualsOperatorHelper")]
        public void EqualsOperatorHelper_Beide_Parameter_gleiche_Instanz()
        {
            Linie linie = new Linie(name: "Linie 1", ident: "L1");

            bool expected = true;
            bool actual = EqualsOperatorHelper.EqualsOperatorBase<Linie>(linie, linie);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Zwei Unterschiedliche Instanzen mit verschiedenen Werten geben false zurück
        /// </summary>
        [TestMethod, TestCategory("EqualsOperatorHelper")]
        public void EqualsOperatorHelper_Unterschiedliche_Instanzen_Unterschiedliche_Werte()
        {
            Linie linie1 = new Linie(name: "Linie 1", ident: "L1");
            Linie linie2 = new Linie(name: "Linie 2", ident: "L2");

            bool expected = false;
            bool actual = EqualsOperatorHelper.EqualsOperatorBase<Linie>(linie1, linie2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Zwei Unterschiedliche Instanzen mit gleichen Werten geben false zurück
        /// </summary>
        [TestMethod, TestCategory("EqualsOperatorHelper")]
        public void EqualsOperatorHelper_Unterschiedliche_Instanzen_gleiche_Werte()
        {
            Linie linie1 = new Linie(name: "Linie 1", ident: "L1");
            Linie linie2 = new Linie(name: "Linie 1", ident: "L1");

            bool expected = true;
            bool actual = EqualsOperatorHelper.EqualsOperatorBase<Linie>(linie1, linie2);

            Assert.AreEqual(expected, actual);
        }
    }
}
