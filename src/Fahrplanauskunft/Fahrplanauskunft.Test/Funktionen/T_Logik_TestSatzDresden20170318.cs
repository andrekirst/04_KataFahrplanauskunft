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
    public class T_T_Logik_TestSatzDresden20170318
    {
        /// <summary>
        /// Liefert Testdaten, für den Test
        /// </summary>
        /// <returns></returns>
        private List<Haltestelle> Lade_Test_Haltestellen()
        {
            string ordnerPfad = "TestDaten\\TestSatzDresden20170318";

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
            string ordnerPfad = "TestDaten\\TestSatzDresden20170318";

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
            string ordnerPfad = "TestDaten\\TestSatzDresden20170318";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeStreckenabschnitte();

            return fahrplanauskunftSpeicher.Streckenabschnitte;
        }

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H16 zu H12. Die erwartete Fahrtdauer beträgt 12 Minuten
        /// </summary>
        [TestMethod]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_Leutewitz_zu_Prohlis_Ergebnis_47()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "Leutewitz");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "Prohlis Gleisschleife");

            Linie linie = linien.First(l => l.Ident == "1_PROHLIS");

            int expected = 47;
            int actual = Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(linie: linie, startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, streckenabschnitte: streckenabschnitte, haltestellen: haltestellen);

            Assert.AreEqual(expected, actual);
        }
    }
}
