using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;
using System.Collections.Generic;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt FahrplanauskunftSpeicher
    /// </summary>
    [TestClass]
    public class T_FahrplanauskunftSpeicher
    {
        /// <summary>
        /// Test, ob der FahrplanauskunftSpeicher die Dateien im Ordner lädt
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_Konstruktor_OrdnerPfad()
        {
            string ordnerPfad = "TestDaten\\TestSatz1";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);

            Assert.AreEqual("TestDaten\\TestSatz1", fahrplanauskunftSpeicher.OrdnerPfad);
        }


        /// <summary>
        /// Test, dass Haltestellen geladen werden und eine Haltestelle als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellen_1()
        {
            string ordnerPfad = "TestDaten\\TestSatz1";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.Laden();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> expected = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien }
            };
            #endregion

            CollectionAssert.AreEqual(expected, fahrplanauskunftSpeicher.Haltestellen);
        }

        /// <summary>
        /// Test, dass Haltestellen geladen werden und 10 Haltestellen als Quelle und im Ziel vorhanden sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void FahrplanauskunftSpeicher_LadeHaltestellen_10()
        {
            string ordnerPfad = "TestDaten\\TestSatz2";

            FahrplanauskunftSpeicher fahrplanauskunftSpeicher = new FahrplanauskunftSpeicher(ordnerPfad: ordnerPfad);
            fahrplanauskunftSpeicher.Laden();

            #region Erstellung des zu erwartendem Wertes
            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD"),
                new Linie(name: "U1", ident: "U1_SUED")
            };

            List<Haltestelle> haltestellen = new List<Haltestelle>()
            {
                new Haltestelle(name: "H1") { Linien = linien },
                new Haltestelle(name: "H2") { Linien = linien },
                new Haltestelle(name: "H3") { Linien = linien },
                new Haltestelle(name: "H4") { Linien = linien },
                new Haltestelle(name: "H5") { Linien = linien },
                new Haltestelle(name: "H6") { Linien = linien },
                new Haltestelle(name: "H7") { Linien = linien },
                new Haltestelle(name: "H8") { Linien = linien },
                new Haltestelle(name: "H9") { Linien = linien },
                new Haltestelle(name: "H10") { Linien = linien }
            };
            #endregion

            List<Haltestelle> actual = fahrplanauskunftSpeicher.Haltestellen;

            List<Haltestelle> expected = haltestellen;

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
