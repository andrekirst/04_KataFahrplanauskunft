// <copyright file="T_LinieIstNichtAnHaltestelleException.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using Fahrplanauskunft.Exceptions;
using Fahrplanauskunft.Objekte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fahrplanauskunft.Test.Exceptions
{
    /// <summary>
    /// Testklasse für LinieIstNichtAnHaltestelleException
    /// </summary>
    [TestClass]
    public class T_LinieIstNichtAnHaltestelleException
    {
        /// <summary>
        /// Test für die Eigenschaft Linie
        /// </summary>
        [TestMethod, TestCategory("Exceptions")]
        public void LinieIstNichtAnHaltestelleException_Property_Linie()
        {
            Linie linie = new Linie(id: "L1", name: "Linie 1", ident: "L1", farbe: "#FF4500");
            Haltestelle haltestelle = new Haltestelle(id: "1", name: "H1");
            LinieIstNichtAnHaltestelleException exception = new LinieIstNichtAnHaltestelleException(linie, haltestelle);

            string expected = "L1";
            string actual = exception.Linie.Ident;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test für die Eigenschaft Haltestelle
        /// </summary>
        [TestMethod, TestCategory("Exceptions")]
        public void LinieIstNichtAnHaltestelleException_Property_Haltestelle()
        {
            Linie linie = new Linie(id: "L1", name: "Linie 1", ident: "L1", farbe: "#FF4500");
            Haltestelle haltestelle = new Haltestelle(id: "1", name: "H1");
            LinieIstNichtAnHaltestelleException exception = new LinieIstNichtAnHaltestelleException(linie, haltestelle);

            string expected = "H1";
            string actual = exception.Haltestelle.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}
