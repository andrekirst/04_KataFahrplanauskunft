// <copyright file="T_Umstiegspunkt.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Umstiegspunkt
    /// </summary>
    [TestClass]
    public class T_Umstiegspunkt
    {
        /// <summary>
        /// Test-Haltestelle H1
        /// </summary>
        public Haltestelle TestHaltestelleH1 => new Haltestelle(id: "H1", name: "H1");

        /// <summary>
        /// Test-Haltestelle H2
        /// </summary>
        public Haltestelle TestHaltestelleH2 => new Haltestelle(id: "H2", name: "H2");

        /// <summary>
        /// Test der Equals-Methode, dass zwei Umstiegspunkt gleich sind. Name: "Test"
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Equals_Name_Test()
        {
            string name = "Test";
            Umstiegspunkt actual = new Umstiegspunkt(new Haltestelle(id: "Test", name: name));

            string name2 = "Test";
            Umstiegspunkt expected = new Umstiegspunkt(new Haltestelle(id: "Test", name: name2));

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass die Rückgabe Name: H4 ist, wenn der Name der Umstiegspunkt H4 ist.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_ToString()
        {
            Umstiegspunkt umstiegspunkt = new Umstiegspunkt(TestHaltestelleH1);

            string expected = "Name: H1";

            string actual = umstiegspunkt.ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei gleichen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Gleichheitsoperator_Gleiche_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(TestHaltestelleH1);
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(TestHaltestelleH1);

            Assert.IsTrue(umstiegspunkt1 == umstiegspunkt2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei verschiedenen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Gleichheitsoperator_Verschiedene_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(TestHaltestelleH1);
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(TestHaltestelleH2);

            Assert.IsFalse(umstiegspunkt1 == umstiegspunkt2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei gleichen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Ungleichheitsoperator_Gleiche_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(TestHaltestelleH1);
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(TestHaltestelleH1);

            Assert.IsFalse(umstiegspunkt1 != umstiegspunkt2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei ungleichen Umstiegspunkten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Umstiegspunkt_Ungleichheitsoperator_Verschiedene_Umstiegspunkte()
        {
            Umstiegspunkt umstiegspunkt1 = new Umstiegspunkt(TestHaltestelleH1);
            Umstiegspunkt umstiegspunkt2 = new Umstiegspunkt(TestHaltestelleH2);

            Assert.IsTrue(umstiegspunkt1 != umstiegspunkt2);
        }
    }
}