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
        private List<Haltestelle> Lade_Test_Haltestellen()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            return fahrplanauskunftSpeicher.Haltestellen;
        }
/*
        private List<Haltestelle> Lade_Test_Haltestellen()
        {
            string ordnerPfad = "TestDaten\\TestSatzBrainstorming";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            return fahrplanauskunftSpeicher.Haltestellen;
        }
        */

        ///<summary>
        /// Haltestelle Linie B11 Starthaltestelle hat eine Linie B11
        /// </summary>
        [TestMethod]
        public void Linien_von_Haltestelle_B11_Start_ist_B11()
        {
            List<Linie> expected = new List<Linie>() { new Linie() { Ident = "B11", Name = "B11" }
                                                     , new Linie() { Ident = "B12", Name = "B12" }};

            Haltestelle h = new Haltestelle("B11_Start");
            h.Linien = new List<Linie>() { new Linie() { Ident = "B11", Name = "B11" }
                                         , new Linie() { Ident = "B12", Name = "B12" } };
            List<Linie> actual = h.Linien;

            CollectionAssert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Haltestelle am Umstiegspunkt Up1 hat vier Linien (B11, B12, B31, B32)
        /// </summary>
        [TestMethod]
        public void Linien_von_Haltestelle_Up1_sind_B11_B12_B31_B32()
        {
            List<Linie> expected = new List<Linie>() { new Linie() { Ident = "B11", Name = "B11" }
                                                     , new Linie() { Ident = "B12", Name = "B12" }
                                                     , new Linie() { Ident = "B31", Name = "B31" }
                                                     , new Linie() { Ident = "B32", Name = "B32" }};
            Haltestelle h = new Haltestelle("Up1");
            h.Linien = new List<Linie>()  { new Linie() { Ident = "B11", Name = "B11" }
                                                     , new Linie() { Ident = "B12", Name = "B12" }
                                                     , new Linie() { Ident = "B31", Name = "B31" }
                                                     , new Linie() { Ident = "B32", Name = "B32" }};
            List<Linie> actual = h.Linien;

            CollectionAssert.AreEqual(expected, actual);

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
                                                                            ,Name = "B1"
                                                                        }, haltestellen)
                                                                        .Select(x => x.Name).ToList();

            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linien B1 hat diese Haltestellen H6,H4, H7, H8 und H9
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
               ,Name = "B2"
            }, haltestellen)
                                                                        .Select(x => x.Name).ToList();
            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linie mit dem Name B1 hat diese Haltestellen H1,H2, H3, H4 und H5
        /// </summary>
        [TestMethod]
        public void Haltestellen_von_Linien_Name_B1_sind_H1_H2_H3_H4_H5()
        {
            List<string> expected = new List<Haltestelle>() { new Haltestelle() { Name = "H1" }
                                                             ,new Haltestelle() { Name = "H2" }
                                                             ,new Haltestelle() { Name = "H3" }
                                                             ,new Haltestelle() { Name = "H4" }
                                                             ,new Haltestelle() { Name = "H5" }
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Haltestellen_einer_Linie("B1", haltestellen)
                                                                        .Select(x => x.Name).ToList();

            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linie mit dem Name B2 hat diese Haltestellen H6,H4, H7, H8 und H9
        /// </summary>
        [TestMethod]
        public void Haltestellen_von_Linien_Name_B2_sind_H6_H4_H7_H8_H9()
        {
            List<string> expected = new List<Haltestelle>() { new Haltestelle() { Name = "H6" }
                                                             ,new Haltestelle() { Name = "H4" }
                                                             ,new Haltestelle() { Name = "H7" }
                                                             ,new Haltestelle() { Name = "H8" }
                                                             ,new Haltestelle() { Name = "H9" }
                                                               }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Haltestellen_einer_Linie("B2"
            , haltestellen)
                                                                        .Select(x => x.Name).ToList();
            // Sortierung wird ignoriert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Linie B1 hat 2 Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Umsteigepunkte_von_Linie_B1_sind_H2_H4()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H2" })
                                                               ,new Umstiegspunkt (new Haltestelle() { Name = "H4" })
                                                               }.Select(x => x.Name).ToList();
           
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Umsteigepunkte_fuer_Linie(new Linie()
                                                                                    {
                                                                                        Ident = "B11"
                                                                                       , Name = "B1"
                                                                                    }, haltestellen)
                                                                                    .Select(x => x.Name).ToList();




            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Linien B3 hat 2 Umstiegspunkte H2 und H8
        /// </summary>
        [TestMethod]
        public void Umsteigepunkte_von_Linie_B3_sind_H2_H8()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt (new Haltestelle() { Name = "H2" })
                                                               ,new Umstiegspunkt (new Haltestelle() { Name = "H8" })
                                                              }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<string> actual = Logik.Liefere_Umsteigepunkte_fuer_Linie(new Linie()
                                                                                {
                                                                                     Ident = "B31"
                                                                                    , Name = "B3"
                                                                                }, haltestellen)
                                                                                .Select(x => x.Name).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Linien B41 hat 1 Umstiegspunkte H8
        /// </summary>
        [TestMethod]
        public void Umsteigepunkte_von_Linie_B4_ist_H8()
        {
            List<string> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "H8" }
                                                                      }.Select(x => x.Name).ToList();

            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            
            List<string> actual = Logik.Liefere_Umsteigepunkte_fuer_Linie(new Linie()
                                                                                {
                                                                                    Ident = "B41"
                                                                                    , Name = "B4"
                                                                                }, haltestellen)
                                                                                .Select(x => x.Name).ToList();

            CollectionAssert.AreEqual(expected, actual);
            
        }

        /// <summary>
        /// 2 Umstiegspunkte Up1 und Up3 sind 2 Umstiegspunkte Up1 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umsteigepunkte_von_Up1_Up3_sind_Up1_Up3()
        {
            List<Umstiegspunkt> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "Up1" }
                                                                      ,new Umstiegspunkt {Name = "Up3" }
                                                                    };
            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umsteigepunkte(new List<Umstiegspunkt>()
                                                                      { new Umstiegspunkt { Name = "Up1" }
                                                                      , new Umstiegspunkt { Name = "Up3" } });

            CollectionAssert.AreEqual(expected, actual);

        }

        /// <summary>
        /// 3 Umstiegspunkte Up1, Up3 und Up3 sind 2 Umstiegspunkte Up1 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umsteigepunkte_von_Up1_Up3_Up3_sind_Up1_Up3()
        {
            List<Umstiegspunkt> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "Up1" }
                                                                      ,new Umstiegspunkt { Name = "Up3" }
                                                                    };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umsteigepunkte(new List<Umstiegspunkt>()
                                                                      { new Umstiegspunkt { Name = "Up1" }
                                                                       ,new Umstiegspunkt { Name = "Up3" }
                                                                      , new Umstiegspunkt { Name = "Up3" } });

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 4 Umstiegspunkte Up1, Up2, Up3 und Up3 sind 3 Umstiegspunkte Up1, Up2 und Up3
        /// </summary>
        [TestMethod]
        public void Eindeutige_Umsteigepunkte_von_Up1_Up2_Up3_Up3_sind_Up1_Up_2_Up3()
        {
            List<Umstiegspunkt> expected = new List<Umstiegspunkt>() { new Umstiegspunkt { Name = "Up1" }
                                                                      ,new Umstiegspunkt { Name = "Up2" }
                                                                      ,new Umstiegspunkt { Name = "Up3" }
                                                                    };

            List<Umstiegspunkt> actual = Logik.Liefere_eindeutige_Umsteigepunkte(new List<Umstiegspunkt>()
                                                                      { new Umstiegspunkt { Name = "Up1" }
                                                                       ,new Umstiegspunkt { Name = "Up2" }
                                                                       ,new Umstiegspunkt { Name = "Up3" }
                                                                       ,new Umstiegspunkt { Name = "Up3" }
            });

            CollectionAssert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Der nächste mögliche Umsteigepunkt von Haltestelle H1 ist H2
        /// </summary>
        [TestMethod]
        public void Naechste_Umsteigepunkte_von_Haltestelle_H1_ist_H2()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Der nächste mögliche Umsteigepunkt von Haltestelle H2 sind H4 und H8
        /// </summary>
        [TestMethod]
        public void Naechste_Umsteigepunkte_von_Haltestelle_H2_sind_H4_H8()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Der nächste mögliche Umsteigepunkt von Haltestelle H16 ist H8
        /// </summary>
        [TestMethod]
        public void Naechste_Umsteigepunkte_von_Haltestelle_H16_ist_H8()
        {
            Assert.Fail();
        }
    }
}
