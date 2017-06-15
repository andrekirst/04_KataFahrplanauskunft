// <copyright file="T_InteraktorSucheLinie.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.UI.WindowsForms.Editor.Objekte.Linie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.UI.WindowsForms.Editor.Test.Suche
{
    /// <summary>
    /// Testklasse für den Interaktor für die Suche von Linien
    /// </summary>
    [TestClass]
    public class T_InteraktorSucheLinie
    {
        /// <summary>
        /// Methode für das Laden von Linie-Testdaten
        /// </summary>
        /// <returns>Gibt eine Liste von Testdaten vom Typ Linie zurück</returns>
        public static List<Linie> LadeTestLinien()
        {
            return new List<Linie>()
            {
                new Linie(name: "B1", ident: "B11"),
                new Linie(name: "B1", ident: "B12")
            };
        }

        /// <summary>
        /// Test, wenn nach dem Wert "B11" gesucht wird
        /// </summary>
        [TestMethod, TestCategory("UI.WindowsformsEditor.Linie.Suche")]
        public void UI_Linie_Suche_Linie_mit_Suchtext_B11()
        {
            List<Linie> linien = LadeTestLinien();

            string suchtext = "B11";

            List<Linie> expected = new List<Linie>()
            {
                new Linie(name: "B1", ident: "B11")
            };

            InteraktorSucheLinie interaktor = new InteraktorSucheLinie();

            List<Linie> actual = interaktor.Suche_Linie(suchtext: suchtext, linien: linien);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn nach dem Wert "b11" gesucht wird
        /// </summary>
        [TestMethod, TestCategory("UI.WindowsformsEditor.Linie.Suche")]
        public void UI_Linie_Suche_Linie_mit_Suchtext_b11()
        {
            List<Linie> linien = LadeTestLinien();

            string suchtext = "b11";

            List<Linie> expected = new List<Linie>()
            {
                new Linie(name: "B1", ident: "B11")
            };

            InteraktorSucheLinie interaktor = new InteraktorSucheLinie();

            List<Linie> actual = interaktor.Suche_Linie(suchtext: suchtext, linien: linien);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn der Suchtext keinen Wert hat
        /// </summary>
        [TestMethod, TestCategory("UI.WindowsformsEditor.Linie.Suche")]
        public void UI_Linie_Suche_Linie_mit_Suchtext_NULL()
        {
            List<Linie> linien = LadeTestLinien();

            string suchtext = null;

            List<Linie> expected = new List<Linie>()
            {
                new Linie(name: "B1", ident: "B11"),
                new Linie(name: "B1", ident: "B12")
            };

            InteraktorSucheLinie interaktor = new InteraktorSucheLinie();

            List<Linie> actual = interaktor.Suche_Linie(suchtext: suchtext, linien: linien);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn der Suchtext leer ist
        /// </summary>
        [TestMethod, TestCategory("UI.WindowsformsEditor.Linie.Suche")]
        public void UI_Linie_Suche_Linie_mit_Suchtext_Empty()
        {
            List<Linie> linien = LadeTestLinien();

            string suchtext = string.Empty;

            List<Linie> expected = new List<Linie>()
            {
                new Linie(name: "B1", ident: "B11"),
                new Linie(name: "B1", ident: "B12")
            };

            InteraktorSucheLinie interaktor = new InteraktorSucheLinie();

            List<Linie> actual = interaktor.Suche_Linie(suchtext: suchtext, linien: linien);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, wenn der Suchtext leer ist
        /// </summary>
        [TestMethod, TestCategory("UI.WindowsformsEditor.Linie.Suche")]
        public void UI_Linie_Suche_Linie_mit_Suchtext_A0_LeereListe()
        {
            List<Linie> linien = LadeTestLinien();

            string suchtext = "A0";

            List<Linie> expected = new List<Linie>();

            InteraktorSucheLinie interaktor = new InteraktorSucheLinie();

            List<Linie> actual = interaktor.Suche_Linie(suchtext: suchtext, linien: linien);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
