using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;
using System.Collections.Generic;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Streckenabschnitt
    /// </summary>
    [TestClass]
    public class T_Streckenabschnitt
    {
        /// <summary>
        /// Test, ob der Streckenabschnitt die Dauer von 1 hat, eine Start- und ZielHaltestelle hat, sowie dass eine Linie auf dem Streckebschnitt fährt.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Konstruktor_Dauer_1_StartHaltestelle_Nicht_NULL_ZielHaltestelle_Nicht_NULL_Linien_1()
        {
            Haltestelle startHaltestelle = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, linien: linien);

            Assert.AreEqual(1, streckenabschnitt.Dauer);
            Assert.AreEqual("StartHaltestelle", streckenabschnitt.StartHaltestelle.Name);
            Assert.AreEqual("ZielHaltestelle", streckenabschnitt.ZielHaltestelle.Name);
            Assert.AreEqual(1, streckenabschnitt.Linien.Count());
        }

        /// <summary>
        /// Test der Equals-Methode, dass zwei gleiche Streckenabschnitte vergleicht
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Equals_Name_Test_Ident_TEST()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien1 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linien: linien1);


            Haltestelle startHaltestelle2 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle2 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien2 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt2 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle2, zielHaltestelle: zielHaltestelle2, linien: linien2);


            Assert.AreEqual(streckenabschnitt1, streckenabschnitt2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei gleichen Streckenabschnitten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Gleichheitsoperator_Gleicher_Linienname()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien1 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linien: linien1);


            Haltestelle startHaltestelle2 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle2 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien2 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt2 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle2, zielHaltestelle: zielHaltestelle2, linien: linien2);

            Assert.IsTrue(streckenabschnitt1 == streckenabschnitt2);
        }

        /// <summary>
        /// Test des Gleichheitsoperators mit zwei verschiedenen Streckenabschnitten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Gleichheitsoperator_Verschiedene_Linienname()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien1 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linien: linien1);


            Haltestelle startHaltestelle2 = new Haltestelle(name: "StartHaltestelle2");
            Haltestelle zielHaltestelle2 = new Haltestelle(name: "ZielHaltestelle2");

            List<Linie> linien2 = new List<Linie>()
            {
                new Linie(name: "U12", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt2 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle2, zielHaltestelle: zielHaltestelle2, linien: linien2);

            Assert.IsFalse(streckenabschnitt1 == streckenabschnitt2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei gleichen Streckenabschnitten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Ungleichheitsoperator_Gleicher_Linienname()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien1 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linien: linien1);


            Haltestelle startHaltestelle2 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle2 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien2 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt2 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle2, zielHaltestelle: zielHaltestelle2, linien: linien2);

            Assert.IsFalse(streckenabschnitt1 != streckenabschnitt2);
        }

        /// <summary>
        /// Test des Ungleichheitsoperators mit zwei ungleichen Streckenabschnitten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Ungleichheitsoperator_Verschiedene_Linienname()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien1 = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linien: linien1);


            Haltestelle startHaltestelle2 = new Haltestelle(name: "StartHaltestelle2");
            Haltestelle zielHaltestelle2 = new Haltestelle(name: "ZielHaltestelle2");

            List<Linie> linien2 = new List<Linie>()
            {
                new Linie(name: "U12", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt2 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle2, zielHaltestelle: zielHaltestelle2, linien: linien2);

            Assert.IsTrue(streckenabschnitt1 != streckenabschnitt2);
        }
    }
}
