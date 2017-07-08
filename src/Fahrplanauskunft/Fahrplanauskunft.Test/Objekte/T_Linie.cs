﻿// <copyright file="T_Linie.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
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
            Linie linie = new Linie(name, ident, farbe: farbe);

            Assert.AreEqual("Test", linie.Name);
            Assert.AreEqual("TEST", linie.Ident);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei Linien gleich sind. Name: "Test", Ident: "TEST"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Equals_Name_Test_Ident_TEST()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");

            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");
            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");

            Assert.IsTrue(actual == expected);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");
            Linie expected = new Linie(name: "Test2", ident: "TEST2", farbe: "#FF4501");

            Assert.IsFalse(actual == expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");
            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");

            Assert.IsFalse(actual != expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");
            Linie expected = new Linie(name: "Test2", ident: "TEST2", farbe: "#FF4501");

            Assert.IsTrue(actual != expected);
        }

        /// <summary>
        /// Testet die Methode ToString. Erwartet "B1 - B11"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_ToString_B1_B11()
        {
            string expected = "B1 - B11 : Farbe: #FF4500";

            Linie linie = new Linie(name: "B1", ident: "B11", farbe: "#FF4500");
            string actual = linie.ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet, ob die Eigenschaft Farbe den Wert aus dem Konstruktor übernimmt
        /// </summary>
        [TestMethod]
        public void Linie_Farbe_RauteFF4500()
        {
            Linie linie = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");

            string actual = linie.Farbe;
            string expected = "#FF4500";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass das Attribut Farbe mit unterschiedlichen Werten verglichen wird
        /// </summary>
        [TestMethod]
        public void Linie_Name_und_Ident_gleich_Farbe_unterschiedlich()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST", farbe: "#FF4500");
            Linie expected = new Linie(name: "Test", ident: "TEST", farbe: "#FF4501");

            Assert.IsTrue(actual != expected);
        }

        /// <summary>
        /// Test, wenn alle Attribute null sind, dass der HashCode 0 ist
        /// </summary>
        [TestMethod]
        public void Linie_GetHashCode_Attribute_null_Erwartet_0()
        {
            Linie linie = new Linie();

            int expected = 0;
            int actual = linie.GetHashCode();

            Assert.AreEqual(expected, actual);
        }
    }
}
