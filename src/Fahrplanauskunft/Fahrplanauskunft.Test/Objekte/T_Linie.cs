// <copyright file="T_Linie.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Linie
    /// </summary>
    [TestClass]
    public class T_Linie
    {
        private static readonly Linie LinieTest = new Linie(id: "TEST", nummer: "Test", lauf: "TEST", farbe: "#FF4500");
        private static readonly Linie LinieTest2 = new Linie(id: "TEST2", nummer: "Test2", lauf: "TEST2", farbe: "#FF4501");

        /// <summary>
        /// Test, ob die Nummer den Wert "Test" beinhaltet und der Lauf den Wert "TEST" beinhaltet.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Konstruktor_Nummer_Test_Lauf_TEST()
        {
            Linie linie = LinieTest;

            Assert.AreEqual("Test", linie.Nummer);
            Assert.AreEqual("TEST", linie.Lauf);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei Linien gleich sind. Nummer: "Test", Lauf: "TEST"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Equals_Nummer_Test_Lauf_TEST()
        {
            Linie actual = LinieTest;

            Linie expected = LinieTest;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit der gleichen Nummer
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Gleiche_Liniennummer()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest;

            Assert.IsTrue(actual == expected);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit verschiedenen Nummern
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Verschiedene_Liniennummern()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest2;

            Assert.IsFalse(actual == expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit den gleichen Nummern
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Gleiche_Liniennummern()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest;

            Assert.IsFalse(actual != expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit verschiedenen Nummern
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Verschiedene_Liniennummern()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest2;

            Assert.IsTrue(actual != expected);
        }

        /// <summary>
        /// Testet die Methode ToString. Erwartet "B1 - B11"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_ToString_B1_B11()
        {
            string expected = "B1 - B11 : Farbe: #FF4500";

            Linie linie = new Linie(nummer: "B1", lauf: "B11", farbe: "#FF4500", id: "B11");
            string actual = linie.ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet, ob die Eigenschaft Farbe den Wert aus dem Konstruktor übernimmt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void Linie_Farbe_RauteFF4500()
        {
            Linie linie = new Linie(id: "TEST", nummer: "Test", lauf: "TEST", farbe: "#FF4500");

            string actual = linie.Farbe;
            string expected = "#FF4500";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass das Attribut Farbe mit unterschiedlichen Werten verglichen wird
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void Linie_Nummer_und_Lauf_gleich_Farbe_unterschiedlich()
        {
            Linie actual = LinieTest;
            Linie expected = new Linie(id: "TEST", nummer: "Test", lauf: "TEST", farbe: "#FF4501");

            Assert.IsTrue(actual != expected);
        }

        /// <summary>
        /// Test, wenn die ID den Wert "1" hat, dass der berechnete Hashwert den Wert -842352753 zurück gibt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void Linie_GetHashCode_ID_1_Erwarte__842352753()
        {
            Linie linie = new Linie(id: "1", nummer: "Test", lauf: "TEST", farbe: "#FF4500");

            int actual = linie.GetHashCode();

            int expected = -842352753;

            Assert.AreEqual(expected, actual);
        }
    }
}
