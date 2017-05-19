// <copyright file="T_Logik_TestSatzDresden20170318.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Test-Klasse für die Logik-Klasse mit dem Test-Datensatz Dresden20170318
    /// </summary>
    [TestClass]
    public class T_Logik_TestSatzDresden20170318
    {
        /// <summary>
        /// Liefert Testdaten an Haltestellen für die Tests
        /// </summary>
        /// <returns>Gibt die Test-Daten für die Haltestellen zurück</returns>
        public List<Haltestelle> Lade_Test_Haltestellen()
        {
            string ordnerPfad = "TestDaten\\TestSatzDresden20170318";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeHaltestellen();

            return fahrplanauskunftSpeicher.Haltestellen;
        }

        /// <summary>
        /// Liefert Testdaten an Linien für die Tests
        /// </summary>
        /// <returns>Gibt die Test-Daten für die Haltestellen zurück</returns>
        public List<Linie> Lade_Test_Linien()
        {
            string ordnerPfad = "TestDaten\\TestSatzDresden20170318";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.LadeLinien();

            return fahrplanauskunftSpeicher.Linien;
        }

        /// <summary>
        /// Liefert Testdaten an Streckenabschnitten für die Tests
        /// </summary>
        /// <returns>Gibt die Test-Daten für die Streckenabschnitte zurück</returns>
        public List<Streckenabschnitt> Lade_Test_Streckenabschnitte()
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
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_Leutewitz_zu_Prohlis_Linie1_PROHLIS_Ergebnis_47()
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

        /// <summary>
        /// Berechnung der Fahrtdauer von der Haltestelle H16 zu H12. Die erwartete Fahrtdauer beträgt 12 Minuten
        /// </summary>
        [TestMethod]
        public void Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_Freystrasse_zu_Postplatz_Linie2_Ergebnis_30()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            Haltestelle startHaltestelle = haltestellen.First(h => h.Name == "Freystraße");
            Haltestelle zielHaltestelle = haltestellen.First(h => h.Name == "Postplatz");

            Linie linie = linien.First(l => l.Ident == "2_BETRIEBSHOF_GORBITZ");

            int expected = 30;
            int actual = Logik.Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(linie: linie, startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, streckenabschnitte: streckenabschnitte, haltestellen: haltestellen);

            Assert.AreEqual(expected, actual);
        }
    }
}
