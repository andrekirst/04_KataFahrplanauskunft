﻿// <copyright file="T_Logik.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Exceptions;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Testklasse für Logik
    /// </summary>
    [TestClass]
    public class T_Logik
    {
        /// <summary>
        /// Liefert Testdaten, für den Test
        /// </summary>
        /// <returns>Liste von Haltestellen</returns>
        public static List<Haltestelle> Lade_Test_Haltestellen()
        {
            string ordnerPfad = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\TestDaten\\TestSatzBrainstorming");

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            return fahrplanauskunftSpeicher.Haltestellen;
        }

        /// <summary>
        /// Liefert Testdaten an Linien für die Tests
        /// </summary>
        /// <returns>Gibt die Test-Linien zurück</returns>
        public static List<Linie> Lade_Test_Linien()
        {
            string ordnerPfad = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\TestDaten\\TestSatzBrainstorming");

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeLinien();

            return fahrplanauskunftSpeicher.Linien;
        }

        /// <summary>
        /// Liefert Testdaten an Streckenabschnitten für die Tests
        /// </summary>
        /// <returns>Gibt die Test-Streckenabschnitte zurück</returns>
        public static List<Streckenabschnitt> Lade_Test_Streckenabschnitte()
        {
            string ordnerPfad = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\TestDaten\\TestSatzBrainstorming");

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeStreckenabschnitte();

            return fahrplanauskunftSpeicher.Streckenabschnitte;
        }

        /// <summary>
        /// Liefert Testdaten an Haltestellenfahrplaneinträgen für die Tests
        /// </summary>
        /// <returns>Gibt die Test-Haltestellenfahrplaneinträge zurück</returns>
        public List<HaltestelleFahrplanEintrag> Lade_Test_Haltestellenfahrplaneintraege()
        {
            string ordnerPfad = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\TestDaten\\TestSatzBrainstorming");

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellenfahrplaneintraege();

            return fahrplanauskunftSpeicher.Haltestellenfahrplaneintraege;
        }

        /// <summary>
        /// Linien B1 hat diese Haltestellen H1,H2, H3, H4 und H5
        /// </summary>
        [TestMethod]
        public void Haltestellen_von_Linie_B1_sind_H1_H2_H3_H4_H5()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltestellen.First(h => h.Name == "H1"),
                haltestellen.First(h => h.Name == "H2"),
                haltestellen.First(h => h.Name == "H3"),
                haltestellen.First(h => h.Name == "H4"),
                haltestellen.First(h => h.Name == "H5")
            };

            List<Haltestelle> actual = Logik.Liefere_Haltestellen_einer_Linie(
                new Linie()
                {
                    ID = "B11",
                    Lauf = "B11",
                    Nummer = "B1"
                },
                haltestellen);

            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linien B2 hat diese Haltestellen H6,H4, H7, H8 und H9
        /// </summary>
        [TestMethod]
        public void Haltestellen_von_Linie_B2_sind_H6_H4_H7_H8_H9()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltestellen.First(h => h.Name == "H6"),
                haltestellen.First(h => h.Name == "H4"),
                haltestellen.First(h => h.Name == "H7"),
                haltestellen.First(h => h.Name == "H8"),
                haltestellen.First(h => h.Name == "H9")
            };

            List<Haltestelle> actual = Logik.Liefere_Haltestellen_einer_Linie(
                new Linie()
                {
                    ID = "B21",
                    Lauf = "B21",
                    Nummer = "B2"
                },
                haltestellen);

            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linie B1 hat 2 Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Umstiegspunkte_von_Linie_B1_sind_H2_H4()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H2")),
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H4"))
            };

            List<Umstiegspunkt> actual = Logik.Liefere_Umstiegspunkte_fuer_Linie(
                new Linie()
                {
                    ID = "B11",
                    Lauf = "B11",
                    Nummer = "B1"
                },
                haltestellen);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Linien B3 hat 2 Umstiegspunkte H2 und H8
        /// </summary>
        [TestMethod]
        public void Umstiegspunkte_von_Linie_B3_sind_H2_H8()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H2")),
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H8"))
            };

            List<Umstiegspunkt> actual = Logik.Liefere_Umstiegspunkte_fuer_Linie(
                new Linie()
                {
                    ID = "B31",
                    Lauf = "B31",
                    Nummer = "B3"
                },
                haltestellen);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Linien B41 hat 1 Umstiegspunkte H8
        /// </summary>
        [TestMethod]
        public void Umstiegspunkte_von_Linie_B4_ist_H8()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H8"))
            };

            List<Umstiegspunkt> actual = Logik.Liefere_Umstiegspunkte_fuer_Linie(
                new Linie()
                {
                    ID = "B41",
                    Lauf = "B41",
                    Nummer = "B4"
                },
                haltestellen);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 2 Umstiegspunkte Up1 und Up3 sind 2 Umstiegspunkte Up1 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umstiegspunkte_von_Up1_Up3_sind_Up1_Up3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt { ID = "Up1", Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") },
                new Umstiegspunkt { ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
            };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umstiegspunkte(
                new List<Umstiegspunkt>()
                {
                    new Umstiegspunkt()
                    {
                        ID = "Up1",
                        Name = "Up1",
                        Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2")
                    },
                    new Umstiegspunkt()
                    {
                        ID = "Up3",
                        Name = "Up3",
                        Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8")
                    }
                });

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 3 Umstiegspunkte Up1, Up3 und Up3 sind 2 Umstiegspunkte Up1 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umstiegspunkte_von_Up1_Up3_Up3_sind_Up1_Up3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt { ID = "Up1", Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") },
                new Umstiegspunkt { ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
            };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umstiegspunkte(
                new List<Umstiegspunkt>()
                {
                    new Umstiegspunkt { ID = "Up1", Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") },
                    new Umstiegspunkt { ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") },
                    new Umstiegspunkt { ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
                });

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 4 Umstiegspunkte Up1, Up2, Up3 und Up3 sind 3 Umstiegspunkte Up1, Up2 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umstiegspunkte_von_Up1_Up2_Up3_Up3_sind_Up1_Up_2_Up3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt()
                {
                    ID = "Up1", Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2")
                },
                new Umstiegspunkt()
                {
                    ID = "Up2", Name = "Up2", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H4")
                },
                new Umstiegspunkt()
                {
                    ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8")
                }
            };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umstiegspunkte(
                new List<Umstiegspunkt>()
                {
                    new Umstiegspunkt()
                    {
                        ID = "Up1", Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2")
                    },
                    new Umstiegspunkt()
                    {
                        ID = "Up2", Name = "Up2", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H4")
                    },
                    new Umstiegspunkt()
                    {
                        ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8")
                    },
                    new Umstiegspunkt()
                    {
                        ID = "Up3", Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8")
                    }
            });

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Beginnend von Haltestelle H1 gibt es 2 nächste Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Beginnend_naechste_Umstiegspunkte_von_Haltestelle_H1_sind_H2_H4()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H2")),
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H4"))
            };

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H1");

            List<Umstiegspunkt> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(
                aktuelleHaltestelle,
                new List<Umstiegspunkt>(),
                haltestellen);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Beginnend von Haltestelle H2 gibt es 2 nächste Umstiegspunkte H4 und H8
        /// </summary>
        [TestMethod]
        public void Beginnend_naechste_Umstiegspunkte_von_Haltestelle_H2_sind_H4_H8()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H4")),
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H8"))
            };

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H2");
            List<Umstiegspunkt> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(
                aktuelleHaltestelle,
                new List<Umstiegspunkt>(),
                haltestellen);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Kommend von Haltestelle H1, gibt es an Haltestelle H2 einen nächsten Umstiegspunkt H8
        /// </summary>
        [TestMethod]
        public void Kommend_von_H1_naechster_Umstiegspunkt_von_Haltestelle_H2_ist_H8()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H8"))
            };

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H2");

            List<Umstiegspunkt> bereitsgewesenenUmstiegspunkte = new List<Umstiegspunkt>
            {
                new Umstiegspunkt(haltestellen.First(h => h.Name == "H4"))
            };

            List<Umstiegspunkt> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgewesenenUmstiegspunkte,
                haltestellen);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Kommend von Haltestelle H12, gibt es an Haltestelle H8 zwei nächste Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Kommend_von_H12_naechste_Umstiegspunkts_von_Haltestelle_H8_sind_H2_H4()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>()
            {
                new Umstiegspunkt(haltestellen.FirstOrDefault(h => h.Name == "H2")),
                new Umstiegspunkt(haltestellen.FirstOrDefault(h => h.Name == "H4"))
            };

            Haltestelle aktuelleHaltestelle = haltestellen.FirstOrDefault(x => x.Name == "H8");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            List<Umstiegspunkt> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B31, bei der die Start-Haltestelle H10 ist und die Ziel-Haltestelle H11
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B31_von_H10_nach_H11()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten
            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltenstellen.First(h => h.Name == "H10"),
                haltenstellen.First(h => h.Name == "H2"),
                haltenstellen.First(h => h.Name == "H8"),
                haltenstellen.First(h => h.Name == "H11")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B31"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H11"),
                    streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B32, bei der die Start-Haltestelle H11 ist und die Ziel-Haltestelle H12 ist
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B32_von_H11_nach_H10()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten
            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltenstellen.First(h => h.Name == "H11"),
                haltenstellen.First(h => h.Name == "H8"),
                haltenstellen.First(h => h.Name == "H2"),
                haltenstellen.First(h => h.Name == "H10")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B32"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H11"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B41, bei der die Start-Haltestelle H14 ist und die Ziel-Haltestelle H15 ist
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H14_nach_H15()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten
            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltenstellen.First(h => h.Name == "H14"),
                haltenstellen.First(h => h.Name == "H8"),
                haltenstellen.First(h => h.Name == "H15")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B41"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H14"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H15"),
                    streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B42, bei der die Start-Haltestelle H15 ist und die Ziel-Haltestelle H14 ist
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B42_von_H15_nach_H14()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten
            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltenstellen.First(h => h.Name == "H15"),
                haltenstellen.First(h => h.Name == "H8"),
                haltenstellen.First(h => h.Name == "H14")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B42"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H15"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H14"),
                    streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Negativ-Test - Sortierung einer Liste von Haltestellen für die Linie B11, bei der die Start-Haltestelle H1 ist und die Ziel-Haltestelle H12 ist. Hier muss der Fehler kommen, dass die Ziel-Haltestelle H12 nicht zur Linie B11 gehört.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(LinieIstNichtAnHaltestelleException))]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B11_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten

            #endregion

            #region Das Ergebnis auswerten
            Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B11"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H1"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H12"),
                    streckenabschnitte: streckenabschnitte);

            // Hier wird eine Exception geworfen, die vom UnitTest als erwartet ausgewertet wird
            #endregion
        }

        /// <summary>
        /// Negativ-Test - Sortierung einer Liste von Haltestellen für die Linie B41, bei der die Start-Haltestelle H1 ist und die Ziel-Haltestelle H12 ist. Hier muss der Fehler kommen, dass die Start-Haltestelle H1 nicht zur Linie B41 gehört.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(LinieIstNichtAnHaltestelleException))]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten

            #endregion

            #region Das Ergebnis auswerten
            Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B41"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H1"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H12"),
                    streckenabschnitte: streckenabschnitte);

            // Hier wird eine Exception geworfen, die vom UnitTest als erwartet ausgewertet wird
            #endregion
        }

        /// <summary>
        /// Test, ob die Linie B11 an der Haltestelle H1 ist
        /// </summary>
        [TestMethod]
        public void Ist_Linie_An_Haltestelle_Linie_B11_Haltestelle_H1()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();

            #endregion

            #region Erwarteten Wert vorbereiten
            bool expected = true;
            #endregion

            #region Das Ergebnis auswerten
            bool actual = Logik.Ist_Linie_An_Haltestelle(
                linie: linien.First(l => l.Lauf == "B11"),
                haltestelle: haltenstellen.First(h => h.Name == "H1"));
            #endregion

            #region Assert ausführen
            Assert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Negativ-Test - Test, dass die Linie B41 nicht an der Haltestelle H1 ist
        /// </summary>
        [TestMethod]
        public void Ist_Linie_An_Haltestelle_Negativ_Linie_B41_Haltestelle_H1()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();

            #endregion

            #region Erwarteten Wert vorbereiten
            bool expected = false;
            #endregion

            #region Das Ergebnis auswerten
            bool actual = Logik.Ist_Linie_An_Haltestelle(
                linie: linien.First(l => l.Lauf == "B41"),
                haltestelle: haltenstellen.First(h => h.Name == "H1"));
            #endregion

            #region Assert ausführen
            Assert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Test, das nur Streckenabschnitte geliefert werden, an der sich auch die Linie B11 befindet
        /// </summary>
        [TestMethod]
        public void Liefere_Streckenabschnitte_einer_Linie_Linie_B11()
        {
            #region Testdaten vorbereiten
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Linie> linien = Lade_Test_Linien();

            #endregion

            #region Erwarteten Wert vorbereiten
            List<Streckenabschnitt> expected = new List<Streckenabschnitt>()
            {
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H1" && s.ZielHaltestelle.Name == "H2"),
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H2" && s.ZielHaltestelle.Name == "H3"),
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H3" && s.ZielHaltestelle.Name == "H4"),
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H4" && s.ZielHaltestelle.Name == "H5")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Streckenabschnitt> actual = Logik.Liefere_Streckenabschnitte_einer_Linie(
                linie: linien.First(l => l.Lauf == "B11"),
                streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Test, dass an der Haltstelle H1 für die Linie B11 ein Streckenabschnitt zurückgegeben wird
        /// </summary>
        [TestMethod]
        public void Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie_Haltestelle_H1_Linie_B11()
        {
            #region Testdaten vorbereiten
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();

            #endregion

            #region Erwarteten Wert vorbereiten
            List<Streckenabschnitt> expected = new List<Streckenabschnitt>()
            {
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H1" && s.ZielHaltestelle.Name == "H2")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Streckenabschnitt> actual = Logik.Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie(
                linie: linien.First(l => l.Lauf == "B11"),
                haltestelle: haltestellen.First(h => h.Name == "H1"),
                streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Test, dass an der Haltstelle H1 für die Linie B11 zwei Streckenabschnitte zurückgegeben werden
        /// </summary>
        [TestMethod]
        public void Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie_Haltestelle_H2_Linie_B11()
        {
            #region Testdaten vorbereiten
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();

            #endregion

            #region Erwarteten Wert vorbereiten
            List<Streckenabschnitt> expected = new List<Streckenabschnitt>()
            {
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H1" && s.ZielHaltestelle.Name == "H2"),
                streckenabschnitte.First(s => s.StartHaltestelle.Name == "H2" && s.ZielHaltestelle.Name == "H3")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Streckenabschnitt> actual = Logik.Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie(
                linie: linien.First(l => l.Lauf == "B11"),
                haltestelle: haltestellen.First(h => h.Name == "H2"),
                streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B31, bei der die Start-Haltestelle H10 ist und die Ziel-Haltestelle H8
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B31_von_H10_nach_H8()
        {
            #region Testdaten vorbereiten
            List<Haltestelle> haltenstellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            #endregion

            #region Erwarteten Wert vorbereiten
            List<Haltestelle> expected = new List<Haltestelle>()
            {
                haltenstellen.First(h => h.Name == "H10"),
                haltenstellen.First(h => h.Name == "H2"),
                haltenstellen.First(h => h.Name == "H8")
            };
            #endregion

            #region Das Ergebnis auswerten
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Lauf == "B31"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H8"),
                    streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            CollectionAssert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Erstelle Hierarchie möglichen Route von Haltestelle H1
        /// </summary>
        [TestMethod]
        public void Hierarchie_Route_von_H1()
        {
            #region Vorbereitung
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            // root:       H1
            //            /  \
            // 1. Ebene:H2 # H4
            //          |    |
            // 2. Ebene:H8 # H8

            // 2. Ebene
            TreeItem ti_2_h8_l = new TreeItem(haltestellen.First(h => h.Name == "H8"));
            TreeItem ti_2_h8_r = new TreeItem(haltestellen.First(h => h.Name == "H8"));

            // 1. Ebene
            TreeItem ti_1_h2_l = new TreeItem(haltestellen.First(h => h.Name == "H2"));
            TreeItem ti_1_h4_r = new TreeItem(haltestellen.First(h => h.Name == "H4"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H1"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h2_l);
            ti_root_Haltestelle.Childs.Add(ti_1_h4_r);

            // 2. Ebene --> 1. Ebene
            ti_1_h2_l.Childs.Add(ti_2_h8_l);
            ti_1_h4_r.Childs.Add(ti_2_h8_r);
            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H1");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            int max_tiefe = 5;

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen,
                max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Erstelle Hierarchie möglichen Route von Haltestelle H2
        /// </summary>
        [TestMethod]
        public void Hierarchie_Route_von_H2()
        {
            #region Vorbereitung
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            // root:       H2
            //            /  \
            // 1. Ebene:H4 # H8

            // 1. Ebene
            TreeItem ti_1_h4_l = new TreeItem(haltestellen.First(h => h.Name == "H4"));
            TreeItem ti_1_h8_r = new TreeItem(haltestellen.First(h => h.Name == "H8"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H2"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h4_l);
            ti_root_Haltestelle.Childs.Add(ti_1_h8_r);

            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H2");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            int max_tiefe = 5;

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen,
                max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Erstelle Hierarchie möglichen Route von Haltestelle H12
        /// </summary>
        [TestMethod]
        public void Hierarchie_Route_von_H12()
        {
            #region Vorbereitung
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            // root:      H12
            //            |
            // 1. Ebene:  H8
            //           /  \
            // 2. Ebene:H2 # H4

            // 2. Ebene
            TreeItem ti_2_h2_l = new TreeItem(haltestellen.First(h => h.Name == "H2"));
            TreeItem ti_2_h4_r = new TreeItem(haltestellen.First(h => h.Name == "H4"));

            // 1. Ebene
            TreeItem ti_1_h8 = new TreeItem(haltestellen.First(h => h.Name == "H8"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H12"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h8);

            // 2. Ebene --> 1. Ebene
            ti_1_h8.Childs.Add(ti_2_h2_l);
            ti_1_h8.Childs.Add(ti_2_h4_r);
            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H12");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            int max_tiefe = 5;

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen,
                max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Erstelle Hierarchie möglichen Route von Haltestelle H1 mit einer maximalen Tiefe von 1
        /// </summary>
        [TestMethod]
        public void Hierarchie_Route_von_H1_mit_Tiefe_1()
        {
            #region Vorbereitung
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            // root:       H1
            //            /  \
            // 1. Ebene:H2 # H4

            // 1. Ebene
            TreeItem ti_1_h2_l = new TreeItem(haltestellen.First(h => h.Name == "H2"));
            TreeItem ti_1_h4_r = new TreeItem(haltestellen.First(h => h.Name == "H4"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H1"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h2_l);
            ti_root_Haltestelle.Childs.Add(ti_1_h4_r);

            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H1");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            int max_tiefe = 1;

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen,
                max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Erstelle Hierarchie möglichen Route von Haltestelle H2 mit einer maximalen Tiefe von 1
        /// </summary>
        [TestMethod]
        public void Hierarchie_Route_von_H2_mit_Tiefe_1()
        {
            #region Vorbereitung
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            // root:       H2
            //            /  \
            // 1. Ebene:H4 # H8

            // 1. Ebene
            TreeItem ti_1_h4_l = new TreeItem(haltestellen.First(h => h.Name == "H4"));
            TreeItem ti_1_h8_r = new TreeItem(haltestellen.First(h => h.Name == "H8"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H2"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h4_l);
            ti_root_Haltestelle.Childs.Add(ti_1_h8_r);

            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H2");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            int max_tiefe = 1;

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen,
                max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Erstelle Hierarchie möglichen Route von Haltestelle H12 mit einer maximalen Tiefe von 1
        /// </summary>
        [TestMethod]
        public void Hierarchie_Route_von_H12_mit_Tiefe_1()
        {
            #region Vorbereitung
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            // root:      H12
            //            |
            // 1. Ebene:  H8

            // 1. Ebene
            TreeItem ti_1_h8 = new TreeItem(haltestellen.First(h => h.Name == "H8"));

            // Root
            TreeItem ti_root_Haltestelle = new TreeItem(haltestellen.First(h => h.Name == "H12"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h8);

            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H12");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();

            int max_tiefe = 1;

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(
                aktuelleHaltestelle,
                bereitsgeweseneUmstiegspunkte,
                haltestellen,
                max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test, ob die Linie B11 an der Haltetelle H1 ist
        /// </summary>
        [TestMethod]
        public void Ueberpruefe_Ist_Linie_An_Haltestelle_B11_H1()
        {
            List<Linie> linien = Lade_Test_Linien();
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            try
            {
                Logik.Ueberpruefe_Ist_Linie_An_Haltestelle(linien.First(l => l.Lauf == "B11"), haltestellen.First(h => h.Name == "H1"));
            }
            catch(Exception)
            {
                Assert.Fail("Test fehlgeschlagen");
            }
        }

        /// <summary>
        /// Test, ob die Exception LinieIstNichtAnHaltestelleException geworfen wird
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(LinieIstNichtAnHaltestelleException))]
        public void Ueberpruefe_Ist_Linie_An_Haltestelle_LinieIstNichtAnHaltestelleException()
        {
            List<Linie> linien = Lade_Test_Linien();
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            Logik.Ueberpruefe_Ist_Linie_An_Haltestelle(linien.First(l => l.Lauf == "B12"), haltestellen.First(h => h.Name == "H12"));
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H1 zu H2. Die erwartete Fahrtdauer beträgt 2 Minuten
        /// </summary>
        [TestMethod]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H1_zu_H2_Ergebnis_2()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H1");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "H2");

            Linie linie = linien.First(l => l.Lauf == "B11");

            int expected = 2;
            int actual = Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                linie: linie,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelle,
                streckenabschnitte: streckenabschnitte);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H1 zu H4. Die erwartete Fahrtdauer beträgt 6 Minuten
        /// </summary>
        [TestMethod]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H1_zu_H4_Ergebnis_6()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H1");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "H4");

            Linie linie = linien.First(l => l.Lauf == "B11");

            int expected = 6;
            int actual = Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                linie: linie,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelle,
                streckenabschnitte: streckenabschnitte);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H12 zu H16. Die erwartete Fahrtdauer beträgt 12 Minuten
        /// </summary>
        [TestMethod]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H12_zu_H16_Ergebnis_12()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H12");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "H16");

            Linie linie = linien.First(l => l.Lauf == "B41");

            int expected = 12;
            int actual = Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                linie: linie,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelle,
                streckenabschnitte: streckenabschnitte);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H16 zu H12. Die erwartete Fahrtdauer beträgt 12 Minuten
        /// </summary>
        [TestMethod]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H16_zu_H12_Ergebnis_12()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H16");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "H12");

            Linie linie = linien.First(l => l.Lauf == "B42");

            int expected = 12;
            int actual = Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                linie: linie,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelle,
                streckenabschnitte: streckenabschnitte);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test für die Ermittlung der nächsten Abfahrtszeit an der Haltestelle H2, Linie B11 mit der Wunschabfahrtszeit 770 (12:50 Uhr). Sollwert 783 (13:03 Uhr)
        /// </summary>
        [TestMethod, TestCategory("Logik")]
        public void ErmittleAbfahrtszeit_Haltestelle_H2_Linie_B11_Wunsch_770_Soll_783()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = Lade_Test_Haltestellenfahrplaneintraege();

            Haltestelle haltstelleH1 = haltestellen.First(h => h.Name == "H2");
            Linie linieB11 = linien.First(l => l.Lauf == "B11");

            int actual = Logik.ErmittleAbfahrtszeit(haltestelle: haltstelleH1, linie: linieB11, haltestellenfahrplaneintraege: haltestellenfahrplaneintraege, wunschabfahrtszeit: 770);
            int expected = 783;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test für die Ermittlung der nächsten Abfahrtszeit an der Haltestelle H2, Linie B11 mit der Wunschabfahrtszeit 1433 (23:53 Uhr). Sollwert 3 (00:03 Uhr)
        /// </summary>
        [TestMethod, TestCategory("Logik")]
        public void ErmittleAbfahrtszeit_Haltestelle_H2_Linie_B11_Wunsch_1433_Soll_3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = Lade_Test_Haltestellenfahrplaneintraege();

            Haltestelle haltstelleH1 = haltestellen.First(h => h.Name == "H2");
            Linie linieB11 = linien.First(l => l.Lauf == "B11");

            int actual = Logik.ErmittleAbfahrtszeit(haltestelle: haltstelleH1, linie: linieB11, haltestellenfahrplaneintraege: haltestellenfahrplaneintraege, wunschabfahrtszeit: 1433);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test für die Ermittlung der nächsten Abfahrtszeit an der Haltestelle H2, Linie B11 mit der Wunschabfahrtszeit 3 (00:03 Uhr). Sollwert 3 (00:03 Uhr)
        /// </summary>
        [TestMethod, TestCategory("Logik")]
        public void ErmittleAbfahrtszeit_Haltestelle_H2_Linie_B11_Wunsch_3_Soll_3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = Lade_Test_Haltestellenfahrplaneintraege();

            Haltestelle haltstelleH1 = haltestellen.First(h => h.Name == "H2");
            Linie linieB11 = linien.First(l => l.Lauf == "B11");

            int actual = Logik.ErmittleAbfahrtszeit(haltestelle: haltstelleH1, linie: linieB11, haltestellenfahrplaneintraege: haltestellenfahrplaneintraege, wunschabfahrtszeit: 3);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H16 zu H1. Es wird die Exception LinieIstNichtAnHaltestelleException erwartet
        /// </summary>
        [TestMethod, TestCategory("Logik")]
        [ExpectedException(typeof(LinieIstNichtAnHaltestelleException))]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H16_zu_H1_Erwartet_Exception()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H16");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "H1");

            Linie linie = linien.First(l => l.Lauf == "B42");

            Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                linie: linie,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelle,
                streckenabschnitte: streckenabschnitte);

            // Hier wird eine Exception geworfen, die vom UnitTest als erwartet ausgewertet wird
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H1 zu H12. Es wird die Exception LinieIstNichtAnHaltestelleException erwartet
        /// </summary>
        [TestMethod, TestCategory("Logik")]
        [ExpectedException(typeof(LinieIstNichtAnHaltestelleException))]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H1_zu_H12_Erwartet_Exception()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H1");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "H12");

            Linie linie = linien.First(l => l.Lauf == "B42");

            Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                linie: linie,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelle,
                streckenabschnitte: streckenabschnitte);

            // Hier wird eine Exception geworfen, die vom UnitTest als erwartet ausgewertet wird
        }
    }
}
