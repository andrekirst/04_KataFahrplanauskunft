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
            Assert.Fail();
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_ZielHaltestelle()
        {
            Assert.Fail();
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Property_Einzelverbindungen()
        {
            Assert.Fail();
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_Equals()
        {
            Assert.Fail();
        }

        [TestMethod, TestCategory("Objekte")]
        public void Verbindung_ToString()
        {
            Assert.Fail();
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
                einzelerverbindungen: einzelverbindungen);
            return verbindung;
        }
    }
}
