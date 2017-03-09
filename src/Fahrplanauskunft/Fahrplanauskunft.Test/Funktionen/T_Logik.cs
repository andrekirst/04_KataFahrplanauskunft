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
            TreeItem ti_root_Haltestelle  = new TreeItem(haltestellen.First(h => h.Name == "H1"));

            // 1. Ebene --> Root
            ti_root_Haltestelle.Childs.Add(ti_1_h2_l);
            ti_root_Haltestelle.Childs.Add(ti_1_h4_r);

            // 2. Ebene --> 1. Ebene
            ti_1_h2_l.Childs.Add(ti_2_h8_l);
            ti_2_h8_r.Childs.Add(ti_2_h8_r);
            #endregion

            TreeItem expected = ti_root_Haltestelle;

            Haltestelle aktuelleHaltestelle = haltestellen.First(x => x.Name == "H1");

            List<Umstiegspunkt> bereitsgeweseneUmstiegspunkte = new List<Umstiegspunkt>();



            TreeItem actual = Logik.Liefere_Hierarchie_Route_von_Haltestelle(aktuelleHaltestelle
                                                                             , ref bereitsgeweseneUmstiegspunkte
                                                                             , haltestellen);

            Assert.AreEqual(expected, actual);
        }

    
    }
}
