using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Objekte;
using System.Collections.Generic;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Test-Klasse für das Objekt Streckenabschnitt
    /// </summary>
    [TestClass]
    public class T_Streckenabschnitt
    {
        /// <summary>
        /// Test, ob der Streckenabschnitt die Dauer von 1 hat, eine Start- und ZielHaltestelle hat, sowie dass eine Linie auf dem Streckebschnitt fährt.
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Streckenabschnitt_Konstruktor_Dauer_1_StartHaltestelle_Nicht_NULL_ZielHaltestelle_Nicht_NULL_Linien_1()
        {
            Haltestelle startHaltestelle = new Haltestelle(name: "StartHaltestelle");
            Haltestelle zielHaltestelle = new Haltestelle(name: "ZielHaltestelle");

            List<Linie> linien = new List<Linie>()
            {
                new Linie(name: "U1", ident: "U1_NORD")
            };

            Streckenabschnitt streckenabschnitt = new Streckenabschnitt(dauer: 1, startHaltestelle: startHaltestelle, zielHaltestelle: zielHaltestelle, linien: linien);

            Assert.AreEqual(1, streckenabschnitt.Dauer);
            Assert.AreEqual("StartHaltestelle", streckenabschnitt.StartHaltestelle.Name);
            Assert.AreEqual("ZielHaltestelle", streckenabschnitt.ZielHaltestelle.Name);
            Assert.AreEqual(1, streckenabschnitt.Linien.Count());
        }
    }
}
