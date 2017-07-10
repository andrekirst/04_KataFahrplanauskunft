// <copyright file="T_FahrplanauskunftSpeicher.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private static Linie LinieB11 = new Linie(id: "B11", name: "B1", ident: "B11", farbe: "#FF4500");

        private static Linie LinieB12 = new Linie(id: "B12", name: "B1", ident: "B12", farbe: "#FF4500");

        private static Linie LinieB31 = new Linie(id: "B31", name: "B3", ident: "B31", farbe: "#AA4500");

        private static Linie LinieB32 = new Linie(id: "B32", name: "B3", ident: "B32", farbe: "#AA4500");

        private static Haltestelle HaltestelleH1 = new Haltestelle(id: "H1", name: "H1")
        {
            Linien = new List<Linie>()
            {
                LinieB11,
                LinieB12
            }
        };

        private static Haltestelle HaltestelleH2 = new Haltestelle(id: "H2", name: "H2")
        {
            Linien = new List<Linie>()
            {
                LinieB11,
                LinieB12,
                LinieB31,
                LinieB32
            }
        };

        /// <summary>
        /// Test-Fahrplanauskunftspeicher für die Tests
        /// </summary>
        /// <param name="testFolder">Der Ordner des Tests</param>
        /// <returns>Gibt einen Test-Fahrplanauskunftspeicher zurück</returns>
        public FahrplanauskunftSpeicher TestFahrplanauskunftSpeicher(string testFolder)
        {
            return new FahrplanauskunftSpeicher(ordnerPfad: testFolder)
            {
                Linien = new List<Linie>()
                {
                    LinieB11
                },
                Haltestellen = new List<Haltestelle>()
                {
                    HaltestelleH1
                },
                Haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
                {
                    new HaltestelleFahrplanEintrag()
                    {
                        ID = "HFE1",
                        Haltestelle = HaltestelleH1,
                        Uhrzeit = 720,
                        Linie = LinieB11
                    }
                },
                Streckenabschnitte = new List<Streckenabschnitt>()
                {
                    new Streckenabschnitt()
                    {
                        ID = "SAB1",
                        Dauer = 1,
                        Linie = LinieB11,
                        StartHaltestelle = HaltestelleH1,
                        ZielHaltestelle = HaltestelleH2
                    }
                }
            };
        }

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
                new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED", farbe: "#FF4500", id: "U1_SUED")
            };

            List<Haltestelle> expected = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1", id: "H1") { Linien = linien }
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
                new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED", farbe: "#FF4500", id: "U1_SUED")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1", id: "H1") { Linien = linien },
                new Haltestelle(name: "H2", id: "H2") { Linien = linien },
                new Haltestelle(name: "H3", id: "H3") { Linien = linien },
                new Haltestelle(name: "H4", id: "H4") { Linien = linien },
                new Haltestelle(name: "H5", id: "H5") { Linien = linien },
                new Haltestelle(name: "H6", id: "H6") { Linien = linien },
                new Haltestelle(name: "H7", id: "H7") { Linien = linien },
                new Haltestelle(name: "H8", id: "H8") { Linien = linien },
                new Haltestelle(name: "H9", id: "H9") { Linien = linien },
                new Haltestelle(name: "H10", id: "H10") { Linien = linien }
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
                new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "U1_NORD")
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
                new Linie(name: "U1", ident: "U1_NORD", farbe: "#FF4500", id: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED", farbe: "#FF4500", id: "U1_SUED"),
                new Linie(name: "U2", ident: "U2_A", farbe: "#EE4500", id: "U2_A"),
                new Linie(name: "U2", ident: "U2_B", farbe: "#EE4500", id: "U2_B"),
                new Linie(name: "U3", ident: "U3_A", farbe: "#DD4500", id: "U3_A"),
                new Linie(name: "U3", ident: "U3_B", farbe: "#DD4500", id: "U3_B"),
                new Linie(name: "U4", ident: "U4_A", farbe: "#CC4500", id: "U4_A"),
                new Linie(name: "U4", ident: "U4_B", farbe: "#CC4500", id: "U4_B"),
                new Linie(name: "U5", ident: "U5_A", farbe: "#BB4500", id: "U5_A"),
                new Linie(name: "U5", ident: "U5_B", farbe: "#BB4500", id: "U5_B")
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
                new Linie(id: "U1_NORD", name: "U1", ident: "U1_NORD", farbe: "#FF4500"),
                new Linie(id: "U1_SUED", name: "U1", ident: "U1_SUED", farbe: "#FF4500")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(id: "H1", name: "H1") { Linien = linien },
                new Haltestelle(id: "H2", name: "H2") { Linien = linien }
            };

            List<Streckenabschnitt> streckenabschnitte = new List<Streckenabschnitt>()
            {
                new Streckenabschnitt(id: "SAB1", dauer: 1, startHaltestelle: haltestellen[0], zielHaltestelle: haltestellen[1], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB2", dauer: 1, startHaltestelle: haltestellen[1], zielHaltestelle: haltestellen[0], linie: linien.First(l => l.Ident == "U1_SUED"))
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
                new Linie(id: "U1_NORD", name: "U1", ident: "U1_NORD", farbe: "#FF4500"),
                new Linie(id: "U1_SUED", name: "U1", ident: "U1_SUED", farbe: "#FF4500")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(id: "H1", name: "H1") { Linien = linien },
                new Haltestelle(id: "H2", name: "H2") { Linien = linien },
                new Haltestelle(id: "H3", name: "H3") { Linien = linien },
                new Haltestelle(id: "H4", name: "H4") { Linien = linien },
                new Haltestelle(id: "H5", name: "H5") { Linien = linien },
                new Haltestelle(id: "H6", name: "H6") { Linien = linien },
                new Haltestelle(id: "H7", name: "H7") { Linien = linien },
                new Haltestelle(id: "H8", name: "H8") { Linien = linien },
                new Haltestelle(id: "H9", name: "H9") { Linien = linien },
                new Haltestelle(id: "H10", name: "H10") { Linien = linien },
                new Haltestelle(id: "H11", name: "H11") { Linien = linien }
            };

            List<Streckenabschnitt> streckenabschnitte = new List<Streckenabschnitt>()
            {
                new Streckenabschnitt(id: "SAB1", dauer: 1, startHaltestelle: haltestellen[0], zielHaltestelle: haltestellen[1], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB2", dauer: 1, startHaltestelle: haltestellen[1], zielHaltestelle: haltestellen[2], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB3", dauer: 1, startHaltestelle: haltestellen[2], zielHaltestelle: haltestellen[3], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB4", dauer: 1, startHaltestelle: haltestellen[3], zielHaltestelle: haltestellen[4], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB5", dauer: 1, startHaltestelle: haltestellen[4], zielHaltestelle: haltestellen[5], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB6", dauer: 1, startHaltestelle: haltestellen[5], zielHaltestelle: haltestellen[6], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB7", dauer: 1, startHaltestelle: haltestellen[6], zielHaltestelle: haltestellen[7], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB8", dauer: 1, startHaltestelle: haltestellen[7], zielHaltestelle: haltestellen[8], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB9", dauer: 1, startHaltestelle: haltestellen[8], zielHaltestelle: haltestellen[9], linie: linien.First(l => l.Ident == "U1_NORD")),
                new Streckenabschnitt(id: "SAB10", dauer: 1, startHaltestelle: haltestellen[9], zielHaltestelle: haltestellen[10], linie: linien.First(l => l.Ident == "U1_NORD"))
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
                new Linie(id: "U1_NORD", name: "U1", ident: "U1_NORD", farbe: "#FF4500")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(id: "H1", name: "H1") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(id: "HFE1", haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0])
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
                new Linie(id: "U1_NORD", name: "U1", ident: "U1_NORD", farbe: "#FF4500")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(id: "H1", name: "H1") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(id: "HFE1", haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE2", haltestelle: haltestellen[0], uhrzeit: 730, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE3", haltestelle: haltestellen[0], uhrzeit: 740, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE4", haltestelle: haltestellen[0], uhrzeit: 750, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE5", haltestelle: haltestellen[0], uhrzeit: 760, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE6", haltestelle: haltestellen[0], uhrzeit: 770, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE7", haltestelle: haltestellen[0], uhrzeit: 780, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE8", haltestelle: haltestellen[0], uhrzeit: 790, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE9", haltestelle: haltestellen[0], uhrzeit: 800, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE10", haltestelle: haltestellen[0], uhrzeit: 810, linie: linien[0])
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
                new Linie(id: "U1_NORD", name: "U1", ident: "U1_NORD", farbe: "#FF4500")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(id: "H1", name: "H1") { Linien = linien },
                new Haltestelle(id: "H2", name: "H2") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(id: "HFE1", haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE2", haltestelle: haltestellen[0], uhrzeit: 730, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE3", haltestelle: haltestellen[0], uhrzeit: 740, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE4", haltestelle: haltestellen[0], uhrzeit: 750, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE5", haltestelle: haltestellen[0], uhrzeit: 760, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE6", haltestelle: haltestellen[1], uhrzeit: 725, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE7", haltestelle: haltestellen[1], uhrzeit: 735, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE8", haltestelle: haltestellen[1], uhrzeit: 745, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE9", haltestelle: haltestellen[1], uhrzeit: 755, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE10", haltestelle: haltestellen[1], uhrzeit: 805, linie: linien[0])
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
                new Linie(id: "U1_NORD", name: "U1", ident: "U1_NORD", farbe: "#FF4500"),
                new Linie(id: "U1_SUED", name: "U1", ident: "U1_SUED", farbe: "#FF4500")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(id: "H1", name: "H1") { Linien = linien },
                new Haltestelle(id: "H2", name: "H2") { Linien = linien }
            };

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = new List<HaltestelleFahrplanEintrag>()
            {
                new HaltestelleFahrplanEintrag(id: "HFE1", haltestelle: haltestellen[0], uhrzeit: 720, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE2", haltestelle: haltestellen[0], uhrzeit: 730, linie: linien[1]),
                new HaltestelleFahrplanEintrag(id: "HFE3", haltestelle: haltestellen[0], uhrzeit: 740, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE4", haltestelle: haltestellen[0], uhrzeit: 750, linie: linien[1]),
                new HaltestelleFahrplanEintrag(id: "HFE5", haltestelle: haltestellen[0], uhrzeit: 760, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE6", haltestelle: haltestellen[1], uhrzeit: 725, linie: linien[1]),
                new HaltestelleFahrplanEintrag(id: "HFE7", haltestelle: haltestellen[1], uhrzeit: 735, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE8", haltestelle: haltestellen[1], uhrzeit: 745, linie: linien[1]),
                new HaltestelleFahrplanEintrag(id: "HFE9", haltestelle: haltestellen[1], uhrzeit: 755, linie: linien[0]),
                new HaltestelleFahrplanEintrag(id: "HFE10", haltestelle: haltestellen[1], uhrzeit: 805, linie: linien[1])
            };

            #endregion

            List<HaltestelleFahrplanEintrag> actual = fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;

            List<HaltestelleFahrplanEintrag> expected = haltestellenfahrplaneintraege;

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Methode Laden mit der Überprüfung von Haltestellen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_Laden_Haltestellen_Anzahl_16()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.Laden();

            List<Haltestelle> haltestellen = fahrplanauskunftSpeicher.Haltestellen;

            int expected = 16;
            int actual = haltestellen.Count;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Methode Laden mit der Überprüfung von Linien
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_Laden_Linien_Anzahl_8()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.Laden();

            List<Linie> linien = fahrplanauskunftSpeicher.Linien;

            int expected = 8;
            int actual = linien.Count;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Methode Laden mit der Überprüfung von Streckenabschnitten
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_Laden_Streckenabschnitte_Anzahl_32()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.Laden();

            List<Streckenabschnitt> streckenabschnitte = fahrplanauskunftSpeicher.Streckenabschnitte;

            int expected = 32;
            int actual = streckenabschnitte.Count;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet die Methode Laden mit der Überprüfung von Haltestellenfahrplaneinträgen
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_Laden_Haltestellenfahrplaneintraege_Anzahl_16()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.Laden();

            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;

            int expected = 768;
            int actual = haltestellenfahrplaneintraege.Count;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testet, dass die FileNotFoundException geworfen wird, wenn die Methode LadeStreckenabschnitte und der Pfad ungültig ist
        /// </summary>
        [TestMethod, TestCategory("Objekte"), ExpectedException(typeof(FileNotFoundException))]
        public void FahrplanauskunftSpeicher_LadeStreckenabschnitte_Datei_nicht_gefunden()
        {
            string ordnerPfad = "TestDaten\\UngueltigerOrdner";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeStreckenabschnitte();

            // Hier wird der Test gültig, weil die Exception FileNotFoundException erwartet wird

            Assert.Fail();
        }

        /// <summary>
        /// Testet, dass die FileNotFoundException geworfen wird, wenn die Methode LadeHaltestellen und der Pfad ungültig ist
        /// </summary>
        [TestMethod, TestCategory("Objekte"), ExpectedException(typeof(FileNotFoundException))]
        public void FahrplanauskunftSpeicher_LadeHaltestellen_Datei_nicht_gefunden()
        {
            string ordnerPfad = "TestDaten\\UngueltigerOrdner";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            // Hier wird der Test gültig, weil die Exception FileNotFoundException erwartet wird

            Assert.Fail();
        }

        /// <summary>
        /// Testet, dass die FileNotFoundException geworfen wird, wenn die Methode LadeLinien und der Pfad ungültig ist
        /// </summary>
        [TestMethod, TestCategory("Objekte"), ExpectedException(typeof(FileNotFoundException))]
        public void FahrplanauskunftSpeicher_LadeLinien_Datei_nicht_gefunden()
        {
            string ordnerPfad = "TestDaten\\UngueltigerOrdner";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeLinien();

            // Hier wird der Test gültig, weil die Exception FileNotFoundException erwartet wird

            Assert.Fail();
        }

        /// <summary>
        /// Testet, dass die FileNotFoundException geworfen wird, wenn die Methode LadeHaltestellenfahrplaneintraege und der Pfad ungültig ist
        /// </summary>
        [TestMethod, TestCategory("Objekte"), ExpectedException(typeof(FileNotFoundException))]
        public void FahrplanauskunftSpeicher_LadeHaltestellenfahrplaneintraege_Datei_nicht_gefunden()
        {
            string ordnerPfad = "TestDaten\\UngueltigerOrdner";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellenfahrplaneintraege();

            // Hier wird der Test gültig, weil die Exception FileNotFoundException erwartet wird

            Assert.Fail();
        }

        /// <summary>
        /// Test für das Speichern der Linien aus dem FahrplanauskunftSpeicher
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_SpeicherLinien()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = new FahrplanauskunftSpeicher(ordnerPfad: testFolder)
            {
                Linien = new List<Linie>()
                {
                    new Linie(id: "B11", name: "B1", ident: "B11", farbe: "#FF4500")
                }
            };

            fahrplanauskunftSpeicherSpeichern.SpeicherLinien();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.LadeLinien();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Linien, fahrplanauskunftSpeicherLaden.Linien);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern der Haltestellen aus dem FahrplanauskunftSpeicher
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_SpeicherHaltestellen()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.SpeicherHaltestellen();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.LadeHaltestellen();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Haltestellen, fahrplanauskunftSpeicherLaden.Haltestellen);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern der Haltestellenfahrplaneintraege aus dem FahrplanauskunftSpeicher
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_SpeicherHaltestellenfahrplaneintraege()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.SpeicherHaltestellenfahrplaneintraege();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.LadeHaltestellenfahrplaneintraege();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Haltestellenfahrplaneintraege, fahrplanauskunftSpeicherLaden.Haltestellenfahrplaneintraege);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern der Streckenabschnitte aus dem FahrplanauskunftSpeicher
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_SpeicherStreckenabschnitte()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.SpeicherStreckenabschnitte();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.LadeStreckenabschnitte();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Streckenabschnitte, fahrplanauskunftSpeicherLaden.Streckenabschnitte);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern aller Objekte aus dem FahrplanauskunftSpeicher. Explizites Testen der Eigenschaft Linien
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_Speichern_Eigenschaft_Linien()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.Speichern();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.Laden();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Linien, fahrplanauskunftSpeicherLaden.Linien);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern aller Objekte aus dem FahrplanauskunftSpeicher. Explizites Testen der Eigenschaft Haltestellen
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_Speichern_Eigenschaft_Haltestellen()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.Speichern();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.Laden();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Haltestellen, fahrplanauskunftSpeicherLaden.Haltestellen);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern aller Objekte aus dem FahrplanauskunftSpeicher. Explizites Testen der Eigenschaft Haltestellenfahrplaneintraege
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_Speichern_Eigenschaft_Haltestellenfahrplaneintraege()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.Speichern();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.Laden();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Haltestellenfahrplaneintraege, fahrplanauskunftSpeicherLaden.Haltestellenfahrplaneintraege);

            Directory.Delete(testFolder, true);
        }

        /// <summary>
        /// Test für das Speichern aller Objekte aus dem FahrplanauskunftSpeicher. Explizites Testen der Eigenschaft Streckenabschnitte
        /// </summary>
        [TestMethod]
        public void FahrplanauskunftSpeicher_Speichern_Eigenschaft_Streckenabschnitte()
        {
            string testFolder = "test";

            Directory.CreateDirectory(testFolder);

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherSpeichern = TestFahrplanauskunftSpeicher(testFolder);

            fahrplanauskunftSpeicherSpeichern.Speichern();

            FahrplanauskunftSpeicher fahrplanauskunftSpeicherLaden = new FahrplanauskunftSpeicher(ordnerPfad: testFolder);

            fahrplanauskunftSpeicherLaden.Laden();

            CollectionAssert.AreEqual(fahrplanauskunftSpeicherSpeichern.Streckenabschnitte, fahrplanauskunftSpeicherLaden.Streckenabschnitte);

            Directory.Delete(testFolder, true);
        }
    }
}
