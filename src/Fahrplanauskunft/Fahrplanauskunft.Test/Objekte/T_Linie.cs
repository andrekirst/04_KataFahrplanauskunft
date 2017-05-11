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
            Linie linie = new Linie(name, ident);

            Assert.AreEqual("Test", linie.Name);
            Assert.AreEqual("TEST", linie.Ident);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei Linien gleich sind. Name: "Test", Ident: "TEST"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Equals_Name_Test_Ident_TEST()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST");
            
            Linie expected = new Linie(name: "Test", ident: "TEST");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST");
            Linie expected = new Linie(name: "Test", ident: "TEST");

            Assert.IsTrue(actual == expected);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Gleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST");
            Linie expected = new Linie(name: "Test2", ident: "TEST2");

            Assert.IsFalse(actual == expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Gleicher_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST");
            Linie expected = new Linie(name: "Test", ident: "TEST");

            Assert.IsFalse(actual != expected);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Linien mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Linie_Ungleichheitsoperator_Verschiedene_Linienname()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST");
            Linie expected = new Linie(name: "Test2", ident: "TEST2");

            Assert.IsTrue(actual != expected);
        }
    }
}
