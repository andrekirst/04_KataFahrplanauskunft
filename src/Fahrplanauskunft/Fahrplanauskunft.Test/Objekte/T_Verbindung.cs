using System;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Fahrplanauskunft.Test.Objekte
{
    [TestClass]
    public class T_Verbindung
    {

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_Abfahrtszeit()
        {
            Verbindung verbindung = TestVerbindung();

            Assert.AreEqual(720, verbindung.Abfahrtszeit);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_Ankunftszeit()
        {
            Verbindung verbindung = TestVerbindung();

            Assert.AreEqual(770, verbindung.Ankunftszeit);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_StartHaltestelle()
        {
            Verbindung verbindung = TestVerbindung();

            Haltestelle expected = new Haltestelle(name: "H1");

            Assert.AreEqual(expected, verbindung.StartHaltestelle);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_ZielHaltestelle()
        {
            Verbindung verbindung = TestVerbindung();

            Haltestelle expected = new Haltestelle(name: "H2");

            Assert.AreEqual(expected, verbindung.ZielHaltestelle);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_Einzelverbindungen()
        {
            Verbindung verbindung = TestVerbindung();

            Dictionary<int, Einzelverbindung> expected = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            expected.Add(1, einzelverbindung);

            Dictionary<int, Einzelverbindung> actual = verbindung.Einzelverbindungen;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Equals()
        {
            Dictionary<int, Einzelverbindung> einzelverbindungen1 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung1 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            einzelverbindungen1.Add(1, einzelverbindung1);

            Verbindung verbindung1 = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                einzelverbindungen: einzelverbindungen1);

            Dictionary<int, Einzelverbindung> einzelverbindungen2 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            einzelverbindungen2.Add(1, einzelverbindung2);

            Verbindung verbindung2 = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                einzelverbindungen: einzelverbindungen2);

            Assert.AreEqual(verbindung1, verbindung2);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_NotEquals()
        {
            Dictionary<int, Einzelverbindung> einzelverbindungen1 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung1 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            einzelverbindungen1.Add(1, einzelverbindung1);

            Verbindung verbindung1 = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                einzelverbindungen: einzelverbindungen1);

            Dictionary<int, Einzelverbindung> einzelverbindungen2 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 2", ident: "L2"));

            einzelverbindungen2.Add(1, einzelverbindung2);

            Verbindung verbindung2 = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                einzelverbindungen: einzelverbindungen2);

            Assert.AreNotEqual(verbindung1, verbindung2);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_ToString()
        {
            Verbindung verbindung = TestVerbindung();

            string expected = "H1 12:00 -> H2 12:50 - Umstiege: 0";
            string actual = verbindung.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_AnzahlUmstiege_0()
        {
            Verbindung verbindung = TestVerbindung();

            int expected = 0;
            int actual = verbindung.AnzahlUmstiege;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_AnzahlUmstiege_1()
        {
            Verbindung verbindung = TestVerbindung_2_Einzelverbindugen();

            int expected = 1;
            int actual = verbindung.AnzahlUmstiege;

            Assert.AreEqual(expected, actual);
        }

        private Verbindung TestVerbindung()
        {
            Dictionary<int, Einzelverbindung> einzelverbindungen = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            einzelverbindungen.Add(1, einzelverbindung);

            Verbindung verbindung = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                einzelverbindungen: einzelverbindungen);
            return verbindung;
        }

        private Verbindung TestVerbindung_2_Einzelverbindugen()
        {
            Dictionary<int, Einzelverbindung> einzelverbindungen = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            einzelverbindungen.Add(1, einzelverbindung);

            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 780,
                ankunftszeit: 810,
                startHaltestelle: new Haltestelle(name: "H2"),
                zielHaltestelle: new Haltestelle(name: "H3"),
                linie: new Linie(name: "Linie 2", ident: "L2"));

            einzelverbindungen.Add(2, einzelverbindung2);

            Verbindung verbindung = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                einzelverbindungen: einzelverbindungen);
            return verbindung;
        }
    }
}
