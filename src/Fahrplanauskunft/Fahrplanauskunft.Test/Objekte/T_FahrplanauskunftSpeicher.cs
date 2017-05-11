// <copyright file="T_FahrplanauskunftSpeicher.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt FahrplanauskunftSpeicher
    /// </summary>
    [TestClass]
    public class T_FahrplanauskunftSpeicher
    {
        /// <summary>
        /// Test, ob der FahrplanauskunftSpeicher die Dateien im Ordner lädt
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_Konstruktor_OrdnerPfad()
        {
            string ordnerPfad = "TestDaten\\TestSatz1";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);

            Assert.AreEqual("TestDaten\\TestSatz1", fahrplanauskunftSpeicher.OrdnerPfad);
        }

        /// <summary>
        /// Test, dass Haltestellen geladen werden und eine Haltestelle als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellen_1()
        {
            string ordnerPfad = "TestDaten\\TestSatz1";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> expected = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien }
            };
            #endregion

            CollectionAssert.AreEqual(expected, fahrplanauskunftSpeicher.Haltestellen);
        }

        /// <summary>
        /// Test, dass Haltestellen geladen werden und 10 Haltestellen als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellen_10()
        {
            string ordnerPfad = "TestDaten\\TestSatz2";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien },
                new Haltestelle(name: "H2") { Linien = linien },
                new Haltestelle(name: "H3") { Linien = linien },
                new Haltestelle(name: "H4") { Linien = linien },
                new Haltestelle(name: "H5") { Linien = linien },
                new Haltestelle(name: "H6") { Linien = linien },
                new Haltestelle(name: "H7") { Linien = linien },
                new Haltestelle(name: "H8") { Linien = linien },
                new Haltestelle(name: "H9") { Linien = linien },
                new Haltestelle(name: "H10") { Linien = linien }
            };
            #endregion

            List<Haltestelle> actual = fahrplanauskunftSpeicher.Haltestellen;

            List<Haltestelle> expected = haltestellen;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Linien geladen werden und eine Linie als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeLinien_1()
        {
            string ordnerPfad = "TestDaten\\TestSatz3";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeLinien();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };
            #endregion

            List<Linie> actual = fahrplanauskunftSpeicher.Linien;

            List<Linie> expected = linien;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Linien geladen werden und 10 Linien als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeLinien_10()
        {
            string ordnerPfad = "TestDaten\\TestSatz4";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeLinien();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED"),
                new Linie(name: "U2", ident: "U2_A"),
                new Linie(name: "U2", ident: "U2_B"),
                new Linie(name: "U3", ident: "U3_A"),
                new Linie(name: "U3", ident: "U3_B"),
                new Linie(name: "U4", ident: "U4_A"),
                new Linie(name: "U4", ident: "U4_B"),
                new Linie(name: "U5", ident: "U5_A"),
                new Linie(name: "U5", ident: "U5_B")
            };
            #endregion

            List<Linie> actual = fahrplanauskunftSpeicher.Linien;

            List<Linie> expected = linien;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Streckenabschnitte geladen werden und ein Streckenabschnitt als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeStreckenabschnitte_1()
        {
            string ordnerPfad = "TestDaten\\TestSatz5";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeStreckenabschnitte();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien },
                new Haltestelle(name: "H2") { Linien = linien }
            };

            List<Streckenabschnitt> streckenabschnitte = new List<Streckenabschnitt>()
            {
                new Streckenabschnitt(1, haltestellen[0], haltestellen[1], linien)
            };

            #endregion

            List<Streckenabschnitt> actual = fahrplanauskunftSpeicher.Streckenabschnitte;

            List<Streckenabschnitt> expected = streckenabschnitte;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Streckenabschnitte geladen werden und 10 Streckenabschnitte als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeStreckenabschnitte_10()
        {
            string ordnerPfad = "TestDaten\\TestSatz6";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeStreckenabschnitte();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien },
                new Haltestelle(name: "H2") { Linien = linien },
                new Haltestelle(name: "H3") { Linien = linien },
                new Haltestelle(name: "H4") { Linien = linien },
                new Haltestelle(name: "H5") { Linien = linien },
                new Haltestelle(name: "H6") { Linien = linien },
                new Haltestelle(name: "H7") { Linien = linien },
                new Haltestelle(name: "H8") { Linien = linien },
                new Haltestelle(name: "H9") { Linien = linien },
                new Haltestelle(name: "H10") { Linien = linien },
                new Haltestelle(name: "H11") { Linien = linien }
            };

            List<Streckenabschnitt> streckenabschnitte = new List<Streckenabschnitt>()
            {
                new Streckenabschnitt(1, haltestellen[0], haltestellen[1], linien),
                new Streckenabschnitt(1, haltestellen[1], haltestellen[2], linien),
                new Streckenabschnitt(1, haltestellen[2], haltestellen[3], linien),
                new Streckenabschnitt(1, haltestellen[3], haltestellen[4], linien),
                new Streckenabschnitt(1, haltestellen[4], haltestellen[5], linien),
                new Streckenabschnitt(1, haltestellen[5], haltestellen[6], linien),
                new Streckenabschnitt(1, haltestellen[6], haltestellen[7], linien),
                new Streckenabschnitt(1, haltestellen[7], haltestellen[8], linien),
                new Streckenabschnitt(1, haltestellen[8], haltestellen[9], linien),
                new Streckenabschnitt(1, haltestellen[9], haltestellen[10], linien)
            };

            #endregion

            List<Streckenabschnitt> actual = fahrplanauskunftSpeicher.Streckenabschnitte;

            List<Streckenabschnitt> expected = streckenabschnitte;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Haltestellenfahrplaneintraege geladen werden und ein Haltestellenfahrplaneintrag als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellenfahrplaneintraege_1()
        {
            string ordnerPfad = "TestDaten\\TestSatz7";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellenfahrplaneintraege();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0])
            };

            #endregion

            List<HaltestelleFahrplanEintrag> actual = fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;

            List<HaltestelleFahrplanEintrag> expected = haltestellenfahrplaneintraege;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Haltestellenfahrplaneintraege geladen werden und 10 Haltestellenfahrplaneintraege als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellenfahrplaneintraege_10()
        {
            string ordnerPfad = "TestDaten\\TestSatz8";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellenfahrplaneintraege();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 730, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 740, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 750, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 760, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 770, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 780, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 790, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 800, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 810, linie: linien[0])
            };

            #endregion

            List<HaltestelleFahrplanEintrag> actual = fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;

            List<HaltestelleFahrplanEintrag> expected = haltestellenfahrplaneintraege;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Haltestellenfahrplaneintraege geladen werden und 10 Haltestellenfahrplaneintraege mit 2 verschiedenen Haltestellen als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellenfahrplaneintraege_10_Verschiedene_Haltestellen_2()
        {
            string ordnerPfad = "TestDaten\\TestSatz9";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellenfahrplaneintraege();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien },
                new Haltestelle(name: "H2") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 730, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 740, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 750, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 760, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 725, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 735, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 745, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 755, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 805, linie: linien[0])
            };

            #endregion

            List<HaltestelleFahrplanEintrag> actual = fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;

            List<HaltestelleFahrplanEintrag> expected = haltestellenfahrplaneintraege;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, dass Haltestellenfahrplaneintraege geladen werden und 10 Haltestellenfahrplaneintraege mit 2 verschiedenen Haltestellen und 2 verschiedenen Linien als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellenfahrplaneintraege_10_Verschiedene_Haltestellen_2_Linien_2()
        {
            string ordnerPfad = "TestDaten\\TestSatz10";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellenfahrplaneintraege();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien },
                new Haltestelle(name: "H2") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 730, linie: linien[1]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 740, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 750, linie: linien[1]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[0], uhrzeit: 760, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 725, linie: linien[1]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 735, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 745, linie: linien[1]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 755, linie: linien[0]),
                new HaltestelleFahrplanEintrag(haltestelle: haltestellen[1], uhrzeit: 805, linie: linien[1])
            };

            #endregion

            List<HaltestelleFahrplanEintrag> actual = fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;

            List<HaltestelleFahrplanEintrag> expected = haltestellenfahrplaneintraege;

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
