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
        [TestMethod]
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
        [TestMethod]
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
    }
}