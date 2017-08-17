// <copyright file="T_Verbindungsauskunft.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>
using System.Collections.Generic;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Objekte
{
    /// <summary>
    /// Testklasse für Verbindungsauskunft
    /// </summary>
    [TestClass]
    public class T_Verbindungsauskunft
    {
        private static readonly Linie LinieL1 = new Linie(id: "L1", nummer: "Linie 1", lauf: "L1", farbe: "#000000");

        private static readonly Haltestelle HaltestelleH1 = new Haltestelle(id: "H1", name: "H1");
        private static readonly Haltestelle HaltestelleH2 = new Haltestelle(id: "H2", name: "H2");

        /// <summary>
        /// Test der Equals-Methode, dass zwei _Verbindungsauskunft mit jeweils der gleichen Verbindung, aber unterschiedlicherVerbindungsauskunftErgebnisTyp : "GeringsteAnzahlUmstiege" bzw. "GeringsteAnzahlUmstiege" nicht gleich sind
        /// </summary>
        [TestMethod, TestCategory("Objekte")]
        public void Verbindungsauskunft_NotEquals_VerbindungsauskunftErgebnisTyp()
        {
            Dictionary<int, Einzelverbindung> einzelverbindungen1 = new Dictionary<int, Einzelverbindung>();
            Einzelverbindung einzelverbindung1 = new Einzelverbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: HaltestelleH1,
                zielHaltestelle: HaltestelleH2,
                linie: LinieL1);

            einzelverbindungen1.Add(1, einzelverbindung1);

            Verbindung verbindung = new Verbindung(
                abfahrtszeit: 720,
                ankunftszeit: 770,
                startHaltestelle: HaltestelleH1,
                zielHaltestelle: HaltestelleH2,
                einzelverbindungen: einzelverbindungen1);

            Verbindungsauskunft expected = new Verbindungsauskunft(verbindung)
            {
                ErgebnisTyp = VerbindungsauskunftErgebnisTyp.GeringsteAnzahlUmstiege
            };

            Verbindungsauskunft actual = new Verbindungsauskunft(verbindung)
            {
                ErgebnisTyp = VerbindungsauskunftErgebnisTyp.GeringsteAnzahlUmstiege
            };

            Assert.AreNotEqual(expected, actual);
        }

        

    }
}
