// <copyright file="T_LogikBerechneVerbindungsauskunft.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Funktionen;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Fahrplanauskunft.Test.Funktionen.T_Logik;

namespace Fahrplanauskunft.Test.Funktionen
{
    [TestClass]
    public class T_LogikBerechneVerbindungsauskunft
    {
        [TestMethod, TestCategory("Logik")]
        public void BerechneVerbindungsauskunft_Start_H1_Ziel_H4_Wunsch_0700_Umstiege_0_Ankunft_0726_Linie_B11()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Linie> linien = Lade_Test_Linien();
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = Lade_Test_Haltestellenfahrplaneintraege();

            #region expected
            Dictionary<int, Einzelverbindung> einzelverbindungen = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 726,
                startHaltestelle: haltestellen.First(h => h.Name == "H1"),
                zielHaltestelle: haltestellen.First(h => h.Name == "H4"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen.Add(1, einzelverbindung);

            Verbindung expected = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 726,
                startHaltestelle: haltestellen.First(h => h.Name == "H1"),
                zielHaltestelle: haltestellen.First(h => h.Name == "H4"),
                einzelverbindungen: einzelverbindungen)
            {
                VerbindungsauskunftErgebnisTyp = VerbindungsauskunftErgebnisTyp.GeringsteAnzahlUmstiege
            };

            #endregion

            Verbindung actual = LogikBerechneVerbindungsauskunft.BerechneVerbindungsauskunft(
                wunschabfahrtszeit: 700,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                haltestellen: haltestellen,
                linien: linien,
                streckenabschnitte: streckenabschnitte,
                haltestellenfahrplaneintraege: haltestellenfahrplaneintraege);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Logik")]
        public void BerechneVerbindungsauskunft_Start_H1_Ziel_H7_Wunsch_0500()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Linie> linien = Lade_Test_Linien();
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = Lade_Test_Haltestellenfahrplaneintraege();

            #region expected
            Dictionary<int, Einzelverbindung> einzelverbindungen = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung1 = new Einzelverbindung(
                abfahrtszeit: 540,
                ankunftszeit: 546,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen.Add(1, einzelverbindung1);

            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 555,
                ankunftszeit: 557,
                startHaltestelle: haltestellen.First(h => h.Name == "H4"),
                zielHaltestelle: haltestellen.First(h => h.Name == "H7"),
                linie: linien.First(l => l.Lauf == "B21"));
            einzelverbindungen.Add(2, einzelverbindung2);

            Verbindung expected = new Verbindung(
                abfahrtszeit: 540,
                ankunftszeit: 557,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H7"),
                einzelverbindungen: einzelverbindungen);

            #endregion

            Verbindung actual = LogikBerechneVerbindungsauskunft.BerechneVerbindungsauskunft(
                wunschabfahrtszeit: 500,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H7"),
                haltestellen: haltestellen,
                linien: linien,
                streckenabschnitte: streckenabschnitte,
                haltestellenfahrplaneintraege: haltestellenfahrplaneintraege);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Logik")]
        public void BerechneVerbindungsauskunft_Start_H1_Ziel_H12_Wunsch_0800()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ErmittleLinien_Von_Haltestelle_Zu_Haltestelle_H1_H2_B11()
        {
            List<Linie> linien = Lade_Test_Linien();
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();

            List<Linie> expected = linien.Where(l => l.Lauf == "B11").ToList();

            List<Linie> actual = LogikBerechneVerbindungsauskunft.ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H2"),
                streckenabschnitte: streckenabschnitte).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
