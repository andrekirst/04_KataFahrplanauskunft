using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplanauskunft.Exceptions;
using Fahrplanauskunft.Objekte;

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
            Linie linie = new Linie("Linie 1", "L1");
            Haltestelle haltestelle = new Haltestelle("H1");
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
            Linie linie = new Linie("Linie 1", "L1");
            Haltestelle haltestelle = new Haltestelle("H1");
            LinieIstNichtAnHaltestelleException exception = new LinieIstNichtAnHaltestelleException(linie, haltestelle);

            string expected = "H1";
            string actual = exception.Haltestelle.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}
