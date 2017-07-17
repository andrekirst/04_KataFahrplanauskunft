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
                startHaltestelle: new Haltestelle(id: "H1", name: "H1"),
                zielHaltestelle: new Haltestelle(id: "H2", name: "H2"),
                linie: new Linie(id: "L1", nummer: "Linie 1", lauf: "L1", farbe: "#000000"));

            Einzelverbindung einzelverbindung2 = new Einzelverbindung(
                abfahrtszeit: 700,
                ankunftszeit: 800,
                startHaltestelle: new Haltestelle(id: "H1", name: "H1"),
                zielHaltestelle: new Haltestelle(id: "H2", name: "H2"),
                linie: new Linie(id: "L1", nummer: "Linie 1", lauf: "L1", farbe: "#000000"));

            Assert.AreEqual(einzelverbindung1, einzelverbindung2);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_Abfahrtszeit()
        {
            Einzelverbindung einzelverbindung = TestEinzelverbindung();

            Assert.AreEqual(700, einzelverbindung.Abfahrtszeit);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_Ankunftszeit()
        {
            Einzelverbindung einzelverbindung = TestEinzelverbindung();

            Assert.AreEqual(800, einzelverbindung.Ankunftszeit);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_Linie()
        {
            Einzelverbindung einzelverbindung = TestEinzelverbindung();

            Linie expected = new Linie(id: "L1", nummer: "Linie 1", lauf: "L1", farbe: "#000000");

            Assert.AreEqual(expected, einzelverbindung.Linie);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_StartHaltestelle()
        {
            Einzelverbindung einzelverbindung = TestEinzelverbindung();

            Haltestelle expected = new Haltestelle(id: "H1", name: "H1");

            Assert.AreEqual(expected, einzelverbindung.StartHaltestelle);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_Property_ZielHaltestelle()
        {
            Einzelverbindung einzelverbindung = TestEinzelverbindung();

            Haltestelle expected = new Haltestelle(id: "H2", name: "H2");

            Assert.AreEqual(expected, einzelverbindung.ZielHaltestelle);
        }

        [TestMethod, TestCategory("Objekte")]
        public void Einzelverbindung_ToString()
        {
            Einzelverbindung einzelverbindung = TestEinzelverbindung();

            string expected = "Linie 1 : H1 11:40 -> H2 13:20";
            string actual = einzelverbindung.ToString();

            Assert.AreEqual(expected, actual);
        }

        private Einzelverbindung TestEinzelverbindung()
        {
            Einzelverbindung einzelverbindung = new Einzelverbindung(
                   abfahrtszeit: 700,
                   ankunftszeit: 800,
                   startHaltestelle: new Haltestelle(id: "H1", name: "H1"),
                   zielHaltestelle: new Haltestelle(id: "H2", name: "H2"),
                   linie: new Linie(id: "L1", nummer: "Linie 1", lauf: "L1", farbe: "#000000"));

            return einzelverbindung;
        }
    }
}
