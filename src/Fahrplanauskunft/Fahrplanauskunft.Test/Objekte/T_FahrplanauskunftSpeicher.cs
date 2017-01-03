using System;
using System.Linq;
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

            Assert.AreEqual(1, fahrplanauskunftSpeicher.Haltestellen.Count());
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

            Assert.AreEqual(10, fahrplanauskunftSpeicher.Haltestellen.Count());
        }
    }
}
