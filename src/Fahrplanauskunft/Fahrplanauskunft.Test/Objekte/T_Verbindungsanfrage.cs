using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;
using System.Collections.Generic;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Verbindungsanfrage
    /// </summary>
    [TestClass]
    public class T_Verbindungsanfrage
    {
        /// <summary>
        /// Test, ob in der Verbindungsabfrage die Start- und ZielHaltestelle nicht NULL sind und die gewünschte Abfahrtszeit den Wert 723 hat
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Verbindungsanfrage_Konstruktor_StartHaltestelle_Nicht_NULL_ZielHaltestelle_Nicht_NULL_WunschAbfahrtszeit_723()
        {
            Haltestelle startHaltestelle = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle = new Haltestelle(name: "ZielHaltestelle");


            int wunschAbfahrtszeit = 723;

            Verbindungsanfrage verbindungsanfrage = new Verbindungsanfrage(startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, wunschAbfahrtszeit: wunschAbfahrtszeit);

            Assert.IsNotNull(verbindungsanfrage.StartHaltestelle);
            Assert.IsNotNull(verbindungsanfrage.ZielHaltestelle);
            Assert.AreEqual(723, verbindungsanfrage.WunschAbfahrtszeit);
        }
    }
}
