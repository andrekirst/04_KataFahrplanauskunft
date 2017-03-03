using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using System.Linq;

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
                    linie: linien.First(l => l.Name == "B31"),
                    startHaltestelle: haltenstellen.First(h => h.Name == "H10"),
                    zielHaltestelle: haltenstellen.First(h => h.Name == "H11"),
                    haltenstellen: haltenstellen,
                    streckenabschnitte: streckenabschnitte);
            #endregion

            #region Assert ausführen
            Assert.AreEqual(expected, actual);
            #endregion
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B32, bei der die Start-Haltestelle H11 ist und die Ziel-Haltestelle H12 ist
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B32_von_H11_nach_H10()
        {
            Assert.Fail(String.Format(nameof(Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B32_von_H11_nach_H10), "{0} nicht implementiert"));
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B41, bei der die Start-Haltestelle H14 ist und die Ziel-Haltestelle H15 ist
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H14_nach_H15()
        {
            Assert.Fail(String.Format(nameof(Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H14_nach_H15), "{0} nicht implementiert"));
        }

        /// <summary>
        /// Sortierung einer Liste von Haltestellen für die Linie B42, bei der die Start-Haltestelle H15 ist und die Ziel-Haltestelle H14 ist
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B42_von_H15_nach_H14()
        {
            Assert.Fail(String.Format(nameof(Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B42_von_H15_nach_H14), "{0} nicht implementiert"));
        }

        /// <summary>
        /// Negativ-Test - Sortierung einer Liste von Haltestellen für die Linie B11, bei der die Start-Haltestelle H1 ist und die Ziel-Haltestelle H12 ist. Hier muss der Fehler kommen, dass die Ziel-Haltestelle H12 nicht zur Linie B11 gehört.
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B11_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie()
        {
            Assert.Fail(String.Format(nameof(Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B11_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie), "{0} nicht implementiert"));
        }

        /// <summary>
        /// Negativ-Test - Sortierung einer Liste von Haltestellen für die Linie B41, bei der die Start-Haltestelle H1 ist und die Ziel-Haltestelle H12 ist. Hier muss der Fehler kommen, dass die Start-Haltestelle H1 nicht zur Linie B41 gehört.
        /// </summary>
        [TestMethod]
        public void Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie()
        {
            Assert.Fail(String.Format(nameof(Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie), "{0} nicht implementiert"));
        }
    }
}
