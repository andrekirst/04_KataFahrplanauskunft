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
        public void BerechneVerbindungsauskunft_Start_H1_Ziel_H12_Wunsch_0800()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Streckenabschnitt> streckenabschnitte = Lade_Test_Streckenabschnitte();
            List<Linie> linien = Lade_Test_Linien();
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege = Lade_Test_Haltestellenfahrplaneintraege();

            #region expected
            #region Route 1
            Dictionary<int, Einzelverbindung> einzelverbindungen1 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung11 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 726,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen1.Add(1, einzelverbindung11);

            Einzelverbindung einzelverbindung12 = new Einzelverbindung(
                abfahrtszeit: 726, // Zeit noch falsch
                ankunftszeit: 729, // Zeit noch falsch
                startHaltestelle: haltestellen.First(h => h.ID == "H4"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H8"),
                linie: linien.First(l => l.Lauf == "B21"));
            einzelverbindungen1.Add(2, einzelverbindung12);

            Einzelverbindung einzelverbindung13 = new Einzelverbindung(
                abfahrtszeit: 729, // Zeit noch falsch
                ankunftszeit: 736, // Zeit noch falsch
                startHaltestelle: haltestellen.First(h => h.ID == "H8"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H12"),
                linie: linien.First(l => l.Lauf == "B42"));
            einzelverbindungen1.Add(3, einzelverbindung13);

            Verbindung verbindung1 = new Verbindung(
                    abfahrtszeit: 720,
                    ankunftszeit: 736, // Zeit noch falsch
                    startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                    zielHaltestelle: haltestellen.First(h => h.ID == "H12"),
                    einzelverbindungen: einzelverbindungen1);

            #endregion

            #region Route 2
            Dictionary<int, Einzelverbindung> einzelverbindungen2 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung21 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 722,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H2"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen2.Add(1, einzelverbindung21);

            Einzelverbindung einzelverbindung22 = new Einzelverbindung(
                abfahrtszeit: 722, // Zeit noch falsch
                ankunftszeit: 723, // Zeit noch falsch
                startHaltestelle: haltestellen.First(h => h.ID == "H2"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H8"),
                linie: linien.First(l => l.Lauf == "B21"));
            einzelverbindungen2.Add(2, einzelverbindung22);

            Einzelverbindung einzelverbindung23 = new Einzelverbindung(
                abfahrtszeit: 723, // Zeit noch falsch
                ankunftszeit: 730, // Zeit noch falsch
                startHaltestelle: haltestellen.First(h => h.ID == "H8"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H12"),
                linie: linien.First(l => l.Lauf == "B42"));
            einzelverbindungen2.Add(3, einzelverbindung23);

            Verbindung verbindung2 = new Verbindung(
                    abfahrtszeit: 720,
                    ankunftszeit: 730, // Zeit noch falsch
                    startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                    zielHaltestelle: haltestellen.First(h => h.ID == "H12"),
                    einzelverbindungen: einzelverbindungen2);

            #endregion

            List<Verbindung> expected = new List<Verbindung>()
                { verbindung1, verbindung2 };

            #endregion

            List<Verbindung> actual = LogikBerechneVerbindungsauskunft.BerechneVerbindungsauskunft(
                wunschabfahrtszeit: 700,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H12"),
                haltestellen: haltestellen,
                linien: linien,
                streckenabschnitte: streckenabschnitte,
                haltestellenfahrplaneintraege: haltestellenfahrplaneintraege);

            CollectionAssert.AreEqual(expected, actual);
        }

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
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen.Add(1, einzelverbindung);

            List<Verbindung> expected = new List<Verbindung>()
            {
                    new Verbindung(
                    abfahrtszeit: 720,
                    ankunftszeit: 726,
                    startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                    zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                    einzelverbindungen: einzelverbindungen)
            };

            #endregion

            List<Verbindung> actual = LogikBerechneVerbindungsauskunft.BerechneVerbindungsauskunft(
                wunschabfahrtszeit: 700,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                haltestellen: haltestellen,
                linien: linien,
                streckenabschnitte: streckenabschnitte,
                haltestellenfahrplaneintraege: haltestellenfahrplaneintraege);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Logik")]
        public void BerechneVerbindungsauskunft_Start_H1_Ziel_H7_Wunsch_0500()
        {
            Assert.Fail();
        }

        [TestMethod, TestCategory("Logik")]
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

        /// <summary>
        /// Test der Equals-Methode, dass zwei _Verbindungsauskunft mit jeweils der gleichen Verbindung, aber unterschiedlicherVerbindungsauskunftErgebnisTyp : "GeringsteAnzahlUmstiege" bzw. "GeringsteAnzahlUmstiege" nicht gleich sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Verbindungsauskunft_GeringsteAnzahlUmstiege_Verbindung2()
        {
            List<Haltestelle> haltestellen = Lade_Test_Haltestellen();
            List<Linie> linien = Lade_Test_Linien();

            #region expected
            Dictionary<int, Einzelverbindung> einzelverbindungen = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung1 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 726,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen.Add(1, einzelverbindung1);

            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 730,
                ankunftszeit: 734,
                startHaltestelle: haltestellen.First(h => h.ID == "H4"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H9"),
                linie: linien.First(l => l.Lauf == "B21"));
            einzelverbindungen.Add(2, einzelverbindung2);

            Verbindung verbindung = new Verbindung(
                    abfahrtszeit: 720,
                    ankunftszeit: 734,
                    startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                    zielHaltestelle: haltestellen.First(h => h.ID == "H9"),
                    einzelverbindungen: einzelverbindungen);

            List<Verbindungsauskunft> expected = new List<Verbindungsauskunft>();
            expected.Add(new Verbindungsauskunft(verbindung)
                                                {
                                                    ErgebnisTyp = VerbindungsauskunftErgebnisTyp.GeringsteAnzahlUmstiege
                                                });

            #endregion

            #region actual Vorbereiten

            #region act Verbindung 1
            Dictionary<int, Einzelverbindung> einzelverbindungen1 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung11 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 726,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H4"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen1.Add(1, einzelverbindung11);

            Einzelverbindung einzelverbindung12 = new Einzelverbindung(
                abfahrtszeit: 730,
                ankunftszeit: 734,
                startHaltestelle: haltestellen.First(h => h.ID == "H4"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H9"),
                linie: linien.First(l => l.Lauf == "B21"));
            einzelverbindungen1.Add(2, einzelverbindung12);

            Verbindung verbindung1 = new Verbindung(
                    abfahrtszeit: 720,
                    ankunftszeit: 734,
                    startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                    zielHaltestelle: haltestellen.First(h => h.ID == "H9"),
                    einzelverbindungen: einzelverbindungen1);
            #endregion

            #region act Verbindung 2
            Dictionary<int, Einzelverbindung> einzelverbindungen2 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung21 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 722,
                startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H2"),
                linie: linien.First(l => l.Lauf == "B11"));
            einzelverbindungen2.Add(1, einzelverbindung21);

            Einzelverbindung einzelverbindung22 = new Einzelverbindung(
                abfahrtszeit: 724,
                ankunftszeit: 725,
                startHaltestelle: haltestellen.First(h => h.ID == "H2"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H8"),
                linie: linien.First(l => l.Lauf == "B31"));
            einzelverbindungen2.Add(2, einzelverbindung22);

            Einzelverbindung einzelverbindung23 = new Einzelverbindung(
                abfahrtszeit: 728,
                ankunftszeit: 730,
                startHaltestelle: haltestellen.First(h => h.ID == "H8"),
                zielHaltestelle: haltestellen.First(h => h.ID == "H9"),
                linie: linien.First(l => l.Lauf == "B21"));
            einzelverbindungen2.Add(3, einzelverbindung23);

            Verbindung verbindung2 = new Verbindung(
                    abfahrtszeit: 720,
                    ankunftszeit: 734,
                    startHaltestelle: haltestellen.First(h => h.ID == "H1"),
                    zielHaltestelle: haltestellen.First(h => h.ID == "H9"),
                    einzelverbindungen: einzelverbindungen2);

            #endregion

            List<Verbindung> verbindungen = new List<Verbindung>();
            verbindungen.Add(verbindung1);
            verbindungen.Add(verbindung2);

            #endregion

            List<Verbindungsauskunft> actual = LogikBerechneVerbindungsauskunft.Ermittle_GeringsteAnzahlUmstiege(verbindungen);

            Assert.AreEqual(expected[0], actual[0]);
        }
    }
}
