using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;
using System.Linq;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Haltestelle
    /// </summary>
    [TestClass]
    public class T_Haltestelle
    {
        /// <summary>
        /// Test einer Haltestelle mit dem Namen "Test" und keinen Linien
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Name_Test_Linien_0()
        {
            string name = "Test";
            Haltestelle haltestelle = new Haltestelle(name);

            Assert.AreEqual("Test", haltestelle.Name);
            Assert.AreEqual(0, haltestelle.Linien.Count());
        }

        /// <summary>
        /// Test einer Haltestelle mit dem Namen "Test" und einer Linie (Name: "U1", Ident: "U1_NORD")
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Name_Test_Linien_1()
        {
            string name = "Test";
            Haltestelle haltestelle = new Haltestelle(name);

            string linieName = "U1";
            string linieIdent = "U1_NORD";

            Linie linie = new Linie(name: linieName, ident: linieIdent);

            haltestelle.Linien.Add(linie);

            Assert.AreEqual("Test", haltestelle.Name);
            Assert.AreEqual(1, haltestelle.Linien.Count());
            Assert.AreEqual("U1", haltestelle.Linien[0].Name);
            Assert.AreEqual("U1_NORD", haltestelle.Linien[0].Ident);
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei Haltestellen gleich sind. Name: "Test"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Equals_Name_Test()
        {
            string name = "Test";
            Haltestelle actual = new Haltestelle(name);

            string name2 = "Test";
            Haltestelle expected = new Haltestelle(name2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass die Rückgabe Name: H4 ist, wenn der Name der Haltestelle H4 ist.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_ToString()
        {
            Haltestelle haltestelle = new Haltestelle(name: "H4");

            string expected = "Name: H4";

            string actual = haltestelle.ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Methode Equals mit einem anderen Vergleichsobjekt. In diesem Fall eine Linie
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Equals_Anderes_Vergleichsobjekt_Linie()
        {
            string name = "Test";
            Haltestelle haltestelle = new Haltestelle(name);

            Linie linie = new Linie("Test", "TEST");

            Assert.AreNotEqual(haltestelle, linie);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Haltestellen mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Gleichheitsoperator_Gleicher_Haltestellenname()
        {
            Haltestelle h1 = new Haltestelle(name: "H1");
            Haltestelle h2 = new Haltestelle(name: "H1");

            Assert.IsTrue(h1 == h2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei Haltestellen mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Gleichheitsoperator_Verschiedene_Haltestellenname()
        {
            Haltestelle h1 = new Haltestelle(name: "H1");
            Haltestelle h2 = new Haltestelle(name: "H2");

            Assert.IsFalse(h1 == h2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Haltestellen mit den gleichen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Ungleichheitsoperator_Gleicher_Haltestellenname()
        {
            Haltestelle h1 = new Haltestelle(name: "H1");
            Haltestelle h2 = new Haltestelle(name: "H1");

            Assert.IsFalse(h1 != h2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei Haltestellen mit verschiedenen Namen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Haltestelle_Ungleichheitsoperator_Verschiedene_Haltestellenname()
        {
            Haltestelle h1 = new Haltestelle(name: "H1");
            Haltestelle h2 = new Haltestelle(name: "H2");

            Assert.IsTrue(h1 != h2);
        }
    }
}