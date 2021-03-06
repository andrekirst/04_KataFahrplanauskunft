﻿// <copyright file="T_ZeitKonverter.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Funktionen
{
    /// <summary>
    /// Testklasse für Zeit_Konverter
    /// </summary>
    [TestClass]
    public class T_ZeitKonverter
    {
        /// <summary>
        /// Es soll die Funktion ZuUhrzeitText mit dem Wert 120 aufgerufen werden und die Ausgabe soll "02:00" betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitText_Ganzzahl_120_Text_0200()
        {
            int zeit = 120;

            string expected = "02:00";

            string actual = Fahrplanauskunft.Funktionen.ZeitKonverter.ZuUhrzeitText(zeit);

            Assert.AreEqual(expected, actual);
       }

        /// <summary>
        /// Es soll die Funktion ZuUhrzeitText mit dem Wert 726 aufgerufen werden und die Ausgabe soll "12:06" betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitText_Ganzzahl_726_Text_1206()
        {
            int zeit = 726;

            string expected = "12:06";

            string actual = Fahrplanauskunft.Funktionen.ZeitKonverter.ZuUhrzeitText(zeit);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es soll die Funktion ZuUhrzeitText mit dem Wert 800 aufgerufen werden und die Ausgabe soll "13:20" betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitText_Ganzzahl_800_Text_1320()
        {
            int zeit = 800;

            string expected = "13:20";

            string actual = Fahrplanauskunft.Funktionen.ZeitKonverter.ZuUhrzeitText(zeit);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es soll die Funktion ZuUhrzeitZahl mit dem Wert 02:00 aufgerufen werden und die Ausgabe soll 120 betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitZahl_Text_0200_Ganzzahl_120()
        {
            string zeit = "02:00";

            int expected = 120;

            int actual = Fahrplanauskunft.Funktionen.ZeitKonverter.ZuUhrzeitZahl(zeit);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es soll die Funktion ZuUhrzeitZahl mit dem Wert 12:06 aufgerufen werden und die Ausgabe soll 726 betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitZahl_Text_1206_Ganzzahl_726()
        {
            string zeit = "12:06";

            int expected = 726;

            int actual = Fahrplanauskunft.Funktionen.ZeitKonverter.ZuUhrzeitZahl(zeit);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Es soll die Funktion ZuUhrzeitZahl mit dem Wert 13:20 aufgerufen werden und die Ausgabe soll 800 betragen.
        /// </summary>
        [TestMethod]
        public void ZuUhrzeitZahl_Text_1320_Ganzzahl_800()
        {
            string zeit = "13:20";

            int expected = 800;

            int actual = Fahrplanauskunft.Funktionen.ZeitKonverter.ZuUhrzeitZahl(zeit);

            Assert.AreEqual(expected, actual);
        }
    }
}
