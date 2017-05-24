using System;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    [TestClass]
    public class T_Einzelverbindung
    {
        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Equals()
        {
            Einzelverbindung einzelverbindung1 = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Assert.AreEqual(einzelverbindung1, einzelverbindung2);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_Abfahrtszeit()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Assert.AreEqual(700, einzelverbindung.Abfahrtszeit);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_Ankunftszeit()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Assert.AreEqual(800, einzelverbindung.Ankunftszeit);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_Linie()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Linie expected = new Linie(name: "Linie 1", ident: "L1");

            Assert.AreEqual(expected, einzelverbindung.Linie);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_StartHaltestelle()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Haltestelle expected = new Haltestelle(name: "H1");

            Assert.AreEqual(expected, einzelverbindung.StartHaltestelle);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_ZielHaltestelle()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            Haltestelle expected = new Haltestelle(name: "H2");

            Assert.AreEqual(expected, einzelverbindung.ZielHaltestelle);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_ToString()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(name: "H1"),
                zielHaltestelle: new Haltestelle(name: "H2"),
                linie: new Linie(name: "Linie 1", ident: "L1"));

            string expected = "Linie 1 : H1 11:40 -> H2 13:20";
            string actual = einzelverbindung.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
