// <copyright file="T_Streckenabschnitt.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Linie linie = new Linie(name: "U1", ident: "U1_NORD");

            Streckenabschnitt streckenabschnitt = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, linie: linie);

            Assert.AreEqual(1, streckenabschnitt.Dauer);
            Assert.AreEqual("StartHaltestelle", streckenabschnitt.StartHaltestelle.Name);
            Assert.AreEqual("ZielHaltestelle", streckenabschnitt.ZielHaltestelle.Name);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Property_Linie()
        {
            Haltestelle startHaltestelle = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle = new Haltestelle(name: "ZielHaltestelle");
            Linie linie = new Linie(name: "U1", ident: "U1_NORD");

            Streckenabschnitt streckenabschnitt = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, linie: linie);

            Linie expected = new Linie(name: "U1", ident: "U1_NORD");

            Linie actual = streckenabschnitt.Linie;

            Assert.AreEqual(expected, actual);
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
        public void Streckenabschnitt_Gleichheitsoperator_Gleicher_Streckenabschnitt()
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
        public void Streckenabschnitt_Gleichheitsoperator_Verschiedene_Streckenabschnitte()
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
        public void Streckenabschnitt_Ungleichheitsoperator_Gleicher_Streckenabschnitt()
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
        public void Streckenabschnitt_Ungleichheitsoperator_Verschiedene_Streckenabschnitte()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            Linie linie1 = new Linie(name: "U1", ident: "U1_NORD");

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linie: linie1);

            Haltestelle startHaltestelle2 = new Haltestelle(name: "StartHaltestelle2");
            Haltestelle zielHaltestelle2 = new Haltestelle(name: "ZielHaltestelle2");

            Linie linie2 = new Linie(name: "U12", ident: "U1_NORD");

            Streckenabschnitt streckenabschnitt2 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle2, zielHaltestelle: zielHaltestelle2, linie: linie2);

            Assert.IsTrue(streckenabschnitt1 != streckenabschnitt2);
        }

        /// <summary>
        /// Testet den Hashcode, der durch die Dauer, die zwei Haltestellen und die Linien erzeugt wird
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_GetHashCode()
        {
            Haltestelle startHaltestelle1 = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle1 = new Haltestelle(name: "ZielHaltestelle");

            Linie linie1 = new Linie(name: "U1", ident: "U1_NORD");

            Streckenabschnitt streckenabschnitt1 = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle1, zielHaltestelle: zielHaltestelle1, linie: linie1);

            int actual = streckenabschnitt1.GetHashCode();

            int expected = -1109444853;
            Assert.AreEqual(expected, actual);
        }
    }
}
