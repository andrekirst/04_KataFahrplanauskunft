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
        private static readonly Linie LinieTest = new Linie(id: "TEST", name: "Test", ident: "TEST", farbe: "#FF4500");
        private static readonly Linie LinieTest2 = new Linie(id: "TEST2", name: "Test2", ident: "TEST2", farbe: "#FF4501");

        /// <summary>
        /// Test, ob der Name den Wert "Test" beinhaltet und der Ident den Wert "TEST" beinhaltet.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Konstruktor_Name_Test_Ident_TEST()
        {
            Linie linie = LinieTest;

            Assert.AreEqual("Test", linie.Name);
            Assert.AreEqual("TEST", linie.Ident);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei Linien gleich sind. Name: "Test", Ident: "TEST"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Equals_Name_Test_Ident_TEST()
        {
            Linie actual = LinieTest;

            Linie expected = LinieTest;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest;

            Assert.IsTrue(actual == expected);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest2;

            Assert.IsFalse(actual == expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = LinieTest;
            Linie expected = LinieTest;

            Assert.IsFalse(actual != expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Verschiedene_Linienname()
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

            Linie linie = new Linie(name: "B1", ident: "B11", farbe: "#FF4500", id: "B11");
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
            Linie linie = new Linie(id: "TEST", name: "Test", ident: "TEST", farbe: "#FF4500");

            string actual = linie.Farbe;
            string expected = "#FF4500";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass das Attribut Farbe mit unterschiedlichen Werten verglichen wird
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void Linie_Name_und_Ident_gleich_Farbe_unterschiedlich()
        {
            Linie actual = LinieTest;
            Linie expected = new Linie(id: "TEST", name: "Test", ident: "TEST", farbe: "#FF4501");

            Assert.IsTrue(actual != expected);
        }

        /// <summary>
        /// Test, wenn die ID den Wert "1" hat, dass der berechnete Hashwert den Wert -842352753 zurück gibt
        /// </summary>
        [TestMethod]
        [TestCategory("Objekte")]
        public void FahrplanauskunftObjektBase_GetHashCode_ID_1_Erwarte__842352753()
        {
            Linie linie = new Linie(id: "1", name: "Test", ident: "TEST", farbe: "#FF4500");

            int actual = linie.GetHashCode();

            int expected = -842352753;

            Assert.AreEqual(expected, actual);
        }
    }
}
