// <copyright file="T_FahrplanauskunftObjektBase.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Text.RegularExpressions;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Testen der abstrakten Klasse FahrplanauskunftObjektBase
    /// </summary>
    [TestClass]
    public class T_FahrplanauskunftObjektBase
    {
        /// <summary>
        /// Test, ob der Konstruktor die Eigenschaft ID setzt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_Konstruktor_Eigenschaft_ID()
        {
            TestKlasseFahrplanauskunftObjektBase testklasse = new TestKlasseFahrplanauskunftObjektBase(id: "123");

            string actual = testklasse.ID;
            string expected = "123";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn der Konstruktor den Parameter automatisch eine ID per <see cref="Guid.NewGuid()"/> vergibt, wenn der Wert NULL ist
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_Konstruktor_Eigenschaft_ID_Null_AutoGenerateGuid()
        {
            TestKlasseFahrplanauskunftObjektBase testklasse = new TestKlasseFahrplanauskunftObjektBase(id: null);

            string actual = testklasse.ID;

            bool gueltig = Regex.IsMatch(actual, @"[\dA-Fa-f]{8,8}-[\dA-Fa-f]{4}-[\dA-Fa-f]{4}-[\dA-Fa-f]{4}-[\dA-Fa-f]{12}");

            Assert.IsTrue(gueltig, "Keine gültige automatische ID generiert");
        }

        /// <summary>
        /// Test, wenn der Konstruktor den Parameter automatisch eine ID per <see cref="Guid.NewGuid()"/> vergibt, wenn der Wert <see cref="string.Empty"/> ist
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_Konstruktor_Eigenschaft_ID_Empty_AutoGenerateGuid()
        {
            TestKlasseFahrplanauskunftObjektBase testklasse = new TestKlasseFahrplanauskunftObjektBase(id: string.Empty);

            string actual = testklasse.ID;

            bool gueltig = Regex.IsMatch(actual, @"[\dA-Fa-f]{8,8}-[\dA-Fa-f]{4}-[\dA-Fa-f]{4}-[\dA-Fa-f]{4}-[\dA-Fa-f]{12}");

            Assert.IsTrue(gueltig, "Keine gültige automatische ID generiert");
        }

        /// <summary>
        /// Test, wenn die ID den Wert "1" hat, dass der berechnete Hashwert den Wert -842352753 zurück gibt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_GetHashCode_ID_1_Erwarte__842352753()
        {
            TestKlasseFahrplanauskunftObjektBase testklasse = new TestKlasseFahrplanauskunftObjektBase(id: "1");

            int actual = testklasse.GetHashCode();

            int expected = -842352753;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet, ob zwei Objekte mit jeweils der ID "1" beim Vergleich mit <see cref="FahrplanauskunftObjektBase.Equals(object)"/> true zurück gibt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_Equals_ID_1_Vergleich_ID_1_Gleich()
        {
            TestKlasseFahrplanauskunftObjektBase testklasse1 = new TestKlasseFahrplanauskunftObjektBase(id: "1");
            TestKlasseFahrplanauskunftObjektBase testklasse2 = new TestKlasseFahrplanauskunftObjektBase(id: "1");

            Assert.IsTrue(testklasse1.Equals(testklasse2));
        }

        /// <summary>
        /// Testet, ob zwei Objekte mit der ID "1" bzw. ID "2" beim Vergleich mit <see cref="FahrplanauskunftObjektBase.Equals(object)"/> false zurück gibt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_Equals_ID_1_Vergleich_ID_2_Ungleich()
        {
            TestKlasseFahrplanauskunftObjektBase testklasse1 = new TestKlasseFahrplanauskunftObjektBase(id: "1");
            TestKlasseFahrplanauskunftObjektBase testklasse2 = new TestKlasseFahrplanauskunftObjektBase(id: "2");

            Assert.IsFalse(testklasse1.Equals(testklasse2));
        }

        private class TestKlasseFahrplanauskunftObjektBase : FahrplanauskunftObjektBase
        {
            public TestKlasseFahrplanauskunftObjektBase(string id)
                : base(id)
            {
            }
        }
    }
}
