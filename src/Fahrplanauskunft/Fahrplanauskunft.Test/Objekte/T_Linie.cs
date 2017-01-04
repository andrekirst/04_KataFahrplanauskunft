using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;

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
        public void Haltestelle_Equals_Name_Test_Ident_TEST()
        {
            Linie actual = new Linie(name: "Test", ident: "TEST");
            
            Linie expected = new Linie(name: "Test", ident: "TEST");

            Assert.AreEqual(expected, actual);
        }
    }
}
