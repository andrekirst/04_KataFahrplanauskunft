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
        /// <summary>
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
        /// Linien B11 hat 2 Umstiegspunkte H2 und H4
        /// </summary>
        [TestMethod]
        public void Umsteigepunkte_von_Linie_B11_sind_H2_H4()
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
        /// Linien B31 hat 2 Umstiegspunkte H2 und H8
        /// </summary>
        [TestMethod]
        public void Umsteigepunkte_von_Linie_B31_sind_H2_H8()
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
        public void Umsteigepunkte_von_Linie_B41_ist_H8()
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
        /// Linie B11 Starthaltestelle hat auf der Linie 2 Umstiegspunkte
        /// </summary>
        [TestMethod]
        public void Naechste_Umsteigepunkte_von_Haltestelle_B11_Start_hat_Up1_Up2()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Haltestelle an Up1 hat auf den Linien 2 Umstiegspunkte
        /// </summary>
        [TestMethod]
        public void Naechste_Umsteigepunkte_von_Haltestelle_UP1_hat_Up2_Up3()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Linie B42 Starthaltestelle hat auf der Linie 1 Umstiegspunkt
        /// </summary>
        [TestMethod]
        public void Naechste_Umsteigepunkte_von_Haltestelle_B42_Start_hat_Up3()
        {
            Assert.Fail();
        }
    }
}
