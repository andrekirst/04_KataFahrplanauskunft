// <copyright file="T_Verbindungsanfrage.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Haltestelle startHaltestelle = new Haltestelle(id: "1", name: "StartHaltestelle");
            Haltestelle zielHaltestelle = new Haltestelle(id: "2", name: "ZielHaltestelle");

            int wunschAbfahrtszeit = 723;

            Verbindungsanfrage verbindungsanfrage = new Verbindungsanfrage(startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, wunschAbfahrtszeit: wunschAbfahrtszeit);

            Assert.IsNotNull(verbindungsanfrage.StartHaltestelle);
            Assert.IsNotNull(verbindungsanfrage.ZielHaltestelle);
            Assert.AreEqual(723, verbindungsanfrage.WunschAbfahrtszeit);
        }
    }
}
