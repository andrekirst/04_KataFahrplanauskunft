using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using System.Linq;
using Fahrplanauskunft.Exceptions;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Summary description for T_Logik
    /// </summary>
    [TestClass]
    public class T_Logik
    {
        /// <summary>
        /// Liefert Testdaten, für den Test
        /// </summary>
        /// <returns></returns>
        private List<Haltestelle> Lade_Test_Haltestellen()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            return fahrplanauskunftSpeicher.Haltestellen;
        }

        /// <summary>
        /// Liefert Testdaten an Linien für die Tests
        /// </summary>
        /// <returns></returns>
        private List<Linie> Lade_Test_Linien()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeLinien();

            return fahrplanauskunftSpeicher.Linien;
        }

        /// <summary>
        /// Liefert Testdaten an Streckenabschnitten für die Tests
        /// </summary>
        /// <returns></returns>
        private List<Streckenabschnitt> Lade_Test_Streckenabschnitte()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeStreckenabschnitte();

            return fahrplanauskunftSpeicher.Streckenabschnitte;
        }

        /// <summary>
        /// Linien B1 hat diese Haltestellen H1,H2, H3, H4 und H5
        /// </summary>
        [TestMethod]
        public void Haltestellen_von_Linie_B1_sind_H1_H2_H3_H4_H5()
        {
            List<string> expected = new List<Haltestelle>() { new Haltestelle() { Name = "H1" }
                                                             ,new Haltestelle() { Name = "H2" }
                                                             ,new Haltestelle() { Name = "H3" }
                                                             ,new Haltestelle() { Name = "H4" }
                                                             ,new Haltestelle() { Name = "H5" }
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Haltestellen_einer_Linie(new Linie()
            {
                Ident = "B11"
                                                                            ,
                Name = "B1"
            }, haltestellen)
                                                                        .Select(x => x.Name).ToList();

            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linien B2 hat diese Haltestellen H6,H4, H7, H8 und H9
        /// </summary>
        [TestMethod]
        public void Haltestellen_von_Linie_B2_sind_H6_H4_H7_H8_H9()
        {
            List<string> expected = new List<Haltestelle>() { new Haltestelle() { Name = "H6" }
                                                             ,new Haltestelle() { Name = "H4" }
                                                             ,new Haltestelle() { Name = "H7" }
                                                             ,new Haltestelle() { Name = "H8" }
                                                             ,new Haltestelle() { Name = "H9" }
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Haltestellen_einer_Linie(new Linie()
            {
                Ident = "B21"
               ,
                Name = "B2"
            }, haltestellen)
                                                                        .Select(x => x.Name).ToList();
            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linie B1 hat 2 Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Umstiegspunkte_von_Linie_B1_sind_H2_H4()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H2" })
                                                               ,new Umstiegspunkt (new Haltestelle() { Name = "H4" })
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Umstiegspunkte_fuer_Linie(new Linie()
            {
                Ident = "B11"
                                                                                       ,
                Name = "B1"
            }, haltestellen)
                                                                                    .Select(x => x.Name).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Linien B3 hat 2 Umstiegspunkte H2 und H8
        /// </summary>
        [TestMethod]
        public void Umstiegspunkte_von_Linie_B3_sind_H2_H8()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H2" })
                                                               ,new Umstiegspunkt (new Haltestelle() { Name = "H8" })
                                                              }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Umstiegspunkte_fuer_Linie(new Linie()
            {
                Ident = "B31"
                                                                                    ,
                Name = "B3"
            }, haltestellen)
                                                                                .Select(x => x.Name).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Linien B41 hat 1 Umstiegspunkte H8
        /// </summary>
        [TestMethod]
        public void Umstiegspunkte_von_Linie_B4_ist_H8()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "H8" }
                                                                      }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<string> actual = Logik.Liefere_Umstiegspunkte_fuer_Linie(new Linie()
            {
                Ident = "B41"
                                                                                    ,
                Name = "B4"
            }, haltestellen)
                                                                                .Select(x => x.Name).ToList();

            CollectionAssert.AreEqual(expected, actual);

        }

        /// <summary>
        /// 2 Umstiegspunkte Up1 und Up3 sind 2 Umstiegspunkte Up1 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umstiegspunkte_von_Up1_Up3_sind_Up1_Up3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") }
                                                                      ,new Umstiegspunkt {Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
                                                                    };
            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umstiegspunkte(new List<Umstiegspunkt>()
                                                                      { new Umstiegspunkt { Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") }
                                                                      , new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") } });

            CollectionAssert.AreEqual(expected, actual);

        }

        /// <summary>
        /// 3 Umstiegspunkte Up1, Up3 und Up3 sind 2 Umstiegspunkte Up1 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umstiegspunkte_von_Up1_Up3_Up3_sind_Up1_Up3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") }
                                                                      ,new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
                                                                    };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umstiegspunkte(new List<Umstiegspunkt>()
                                                                      { new Umstiegspunkt { Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") }
                                                                       ,new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
                                                                      , new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") } });

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 4 Umstiegspunkte Up1, Up2, Up3 und Up3 sind 3 Umstiegspunkte Up1, Up2 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umstiegspunkte_von_Up1_Up2_Up3_Up3_sind_Up1_Up_2_Up3()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            List<Umstiegspunkt> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") }
                                                                      ,new Umstiegspunkt { Name = "Up2", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H4") }
                                                                      ,new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
                                                                    };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umstiegspunkte(new List<Umstiegspunkt>()
                                                                      { new Umstiegspunkt { Name = "Up1", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H2") }
                                                                       ,new Umstiegspunkt { Name = "Up2", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H4") }
                                                                       ,new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
                                                                       ,new Umstiegspunkt { Name = "Up3", Haltestelle = haltestellen.FirstOrDefault(h => h.Name == "H8") }
            });

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Beginnend von Haltestelle H1 gibt es 2 nächste Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Beginnend_naechste_Umstiegspunkte_von_Haltestelle_H1_sind_H2_H4()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H2" })
                                                               ,new Umstiegspunkt (new Haltestelle() { Name = "H4" })
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            Haltestelle aktuelleHaltestelle = haltestellen.Where(x => x.Name == "H1").First();

            List<string> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(aktuelleHaltestelle
                                                                                        , new List<Umstiegspunkt>()
                                                                                        , haltestellen)
                                                                                      .Select(x => x.Name).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Beginnend von Haltestelle H2 gibt es 2 nächste Umstiegspunkte H4 und H8
        /// </summary>
        [TestMethod]
        public void Beginnend_naechste_Umstiegspunkte_von_Haltestelle_H2_sind_H4_H8()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H4" })
                                                               ,new Umstiegspunkt (new Haltestelle() { Name = "H8" })
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            Haltestelle aktuelleHaltestelle = haltestellen.Where(x => x.Name == "H2").First();
            List<string> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(aktuelleHaltestelle
                                                                                        , new List<Umstiegspunkt>()
                                                                                        , haltestellen)
                                                                                      .Select(x => x.Name).ToList();

            CollectionAssert.AreEqual(expected, actual);
            ;
        }

        /// <summary>
        /// Kommend von Haltestelle H1, gibt es an Haltestelle H2 einen nächsten Umstiegspunkt H8
        /// </summary>
        [TestMethod]
        public void Kommend_von_H1_naechster_Umstiegspunkt_von_Haltestelle_H2_ist_H8()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H8" })
                                                              }.Select(x => x.Name).ToList();



            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();

            Haltestelle aktuelleHaltestelle = haltestellen.Where(x => x.Name == "H2").First();

            List<Umstiegspunkt> bereitsgewesenenUmstiegspunkte = new List<Umstiegspunkt>{
                                                                    new Umstiegspunkt (new Haltestelle() { Name = "H4" })
                                                                  };

            List<string> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(aktuelleHaltestelle
                                                                                        , bereitsgewesenenUmstiegspunkte
                                                                                        , haltestellen)
                                                                                      .Select(x => x.Name).ToList();

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

            List<Umstiegspunkt> actual = Logik.Liefere_Naechste_Umstiegspunkte_von_Haltestelle(aktuelleHaltestelle
                                                                                        , bereitsgeweseneUmstiegspunkte
                                                                                        , haltestellen);

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
                    linie: linien.First(l => l.Ident == "B31"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H11"),
                    haltenstellen: haltenstellen,
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
                    linie: linien.First(l => l.Ident == "B32"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H11"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    haltenstellen: haltenstellen,
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
                    linie: linien.First(l => l.Ident == "B41"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H14"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H15"),
                    haltenstellen: haltenstellen,
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
                    linie: linien.First(l => l.Ident == "B42"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H15"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H14"),
                    haltenstellen: haltenstellen,
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
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Ident == "B11"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H1"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H12"),
                    haltenstellen: haltenstellen,
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
            List<Haltestelle> actual = Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(
                    linie: linien.First(l => l.Ident == "B41"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H1"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H12"),
                    haltenstellen: haltenstellen,
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
                linie: linien.First(l => l.Ident == "B11"),
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
                linie: linien.First(l => l.Ident == "B41"),
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
                linie: linien.First(l => l.Ident == "B11"),
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
                linie: linien.First(l => l.Ident == "B11"),
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
                linie: linien.First(l => l.Ident == "B11"),
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
                    linie: linien.First(l => l.Ident == "B31"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H8"),
                    haltenstellen: haltenstellen,
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

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen
                                                                             , max_tiefe);

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

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen
                                                                             , max_tiefe);

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

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen
                                                                             , max_tiefe);

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

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen
                                                                             , max_tiefe);

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

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen
                                                                             , max_tiefe);

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

            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen
                                                                             , max_tiefe);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test für das Initialisieren der Start-Haltestellen in das sortierte Dictionary
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Initialisiere_StartHaltestelle_H1()
        {
            #region Prepare
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "H1");
            List<Streckenabschnitt> gefundeneStreckenabschnitte = Lade_Test_Streckenabschnitte().Where(sab => sab.StartHaltestelle.Equals(haltestellen.First(h => h.Name == "H1")) && sab.ZielHaltestelle.Equals(haltestellen.First(h2 => h2.Name == "H2"))).ToList();
            Dictionary<int, List<Haltestelle>> sortierteListeTempAlsDictionary = new Dictionary<int, List<Haltestelle>>();
            #endregion

            #region Logik ausführen
            Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Initialisiere_StartHaltestelle(startHaltestelle, gefundeneStreckenabschnitte, sortierteListeTempAlsDictionary);
            #endregion

            #region Actual und Expected
            Dictionary<int, List<Haltestelle>> actual = sortierteListeTempAlsDictionary;
            Dictionary<int, List<Haltestelle>> expected = new Dictionary<int, List<Haltestelle>>()
            {
                { 0, new List<Haltestelle>() { haltestellen.First(h => h.Name == "H1") } }
            };
            #endregion

            equalidator.Equalidator.AreEqual(expected, actual);
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
                Logik.Ueberpruefe_Ist_Linie_An_Haltestelle(linien.First(l => l.Ident == "B11"), haltestellen.First(h => h.Name == "H1"));
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

            Logik.Ueberpruefe_Ist_Linie_An_Haltestelle(linien.First(l => l.Ident == "B12"), haltestellen.First(h => h.Name == "H12"));
        }

        /// <summary>
        /// Test, ob das Hinzufügen und Entfernen aus Listen für das Sortieren einer Liste von Haltestellen funktioniert
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Verwalte_Hilfsobjekte_1()
        {
            #region Prepare
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Linie> linien = Lade_Test_Linien();

            List<Haltestelle> haltestellenDerLinie = new List<Haltestelle>()
            {
                haltestellen.First(h => h.Name == "H2"),
                haltestellen.First(h => h.Name == "H3"),
                haltestellen.First(h => h.Name == "H4"),
                haltestellen.First(h => h.Name == "H5")
            };

            List<Streckenabschnitt> streckenabschnitteDerLinie = streckenabschnitte.Where(sab => sab.Linien.Contains(linien.First(l => l.Ident == "B11"))).ToList();

            List<Haltestelle> sortierteListe = new List<Haltestelle>() { haltestellen.First(h => h.Name == "H1") };

            Streckenabschnitt gefundenerStreckenabschnitt = streckenabschnitte.First(sab => sab.StartHaltestelle.Equals(haltestellen.First(h => h.Name == "H1")) && sab.ZielHaltestelle.Equals(haltestellen.First(h2 => h2.Name == "H2")));

            Haltestelle gefundeneHaltestelle = haltestellen.First(h => h.Name == "H2"); 
            #endregion

            Logik.Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Verwalte_Hilfsobjekte(haltestellenDerLinie, streckenabschnitteDerLinie, sortierteListe, gefundenerStreckenabschnitt, gefundeneHaltestelle);

            #region Expected
            List<Haltestelle> sortierteListeExpected = new List<Haltestelle>() { haltestellen.First(h => h.Name == "H1"), haltestellen.First(h => h.Name == "H2") };

            List<Haltestelle> haltestellenDerLinieExpected = new List<Haltestelle>()
            {
                haltestellen.First(h => h.Name == "H3"),
                haltestellen.First(h => h.Name == "H4"),
                haltestellen.First(h => h.Name == "H5")
            };

            List<Streckenabschnitt> streckenabschnitteDerLinieExpected = streckenabschnitte.Where(sab => sab.Linien.Contains(linien.First(l => l.Ident == "B11"))).Where(sab => !sab.StartHaltestelle.Equals(haltestellen.First(h => h.Name == "H1"))).ToList(); 
            #endregion

            CollectionAssert.AreEqual(sortierteListeExpected, sortierteListe);
            CollectionAssert.AreEqual(haltestellenDerLinieExpected, haltestellenDerLinie);
            CollectionAssert.AreEqual(streckenabschnitteDerLinieExpected, streckenabschnitteDerLinie);
        }
    }
}
