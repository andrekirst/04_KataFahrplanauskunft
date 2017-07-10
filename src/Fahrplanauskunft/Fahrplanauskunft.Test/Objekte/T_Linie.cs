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
        /// <summary>
        /// Test, ob der Name den Wert "Test" beinhaltet und der Ident den Wert "TEST" beinhaltet.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Konstruktor_Name_Test_Ident_TEST()
        {
            string name = "Test";
            string ident = "TEST";
            string farbe = "#FF4500";
            Linie linie = new Linie(id: "1", name: name, ident: ident, farbe: farbe);

            Assert.AreEqual("Test", linie.Name);
            Assert.AreEqual("TEST", linie.Ident);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei Linien gleich sind. Name: "Test", Ident: "TEST"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Equals_Name_Test_Ident_TEST()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");

            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");
            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");

            Assert.IsTrue(actual == expected);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");
            Linie expected = new Linie(name: "Test2", ident: "TEST2", farbe: "#FF4501", id: "TEST2");

            Assert.IsFalse(actual == expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");
            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");

            Assert.IsFalse(actual != expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500", id: "TEST");
            Linie expected = new Linie(name: "Test2", ident: "TEST2", farbe: "#FF4501", id: "TEST2");

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
            Linie actual = new Linie(id: "TEST", name: "Test", ident: "TEST", farbe: "#FF4500");
            Linie expected = new Linie(id: "TEST", name: "Test", ident: "TEST", farbe: "#FF4501");

            Assert.IsTrue(actual != expected);
        }
    }
}
