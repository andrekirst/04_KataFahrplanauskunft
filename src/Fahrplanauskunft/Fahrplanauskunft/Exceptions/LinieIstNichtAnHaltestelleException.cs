using System;
using System.Runtime.Serialization;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Exceptions
{
    /// <summary>
    /// Exception für, dass die Linie nicht an der Haltestelle ist
    /// </summary>
    [Serializable]
    internal class LinieIstNichtAnHaltestelleException : Exception
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public LinieIstNichtAnHaltestelleException()
        {
        }

        /// <summary>
        /// Exception mit der Angabe einer Nachricht
        /// </summary>
        /// <param name="message"></param>
        public LinieIstNichtAnHaltestelleException(string message) : base(message)
        {
        }

        /// <summary>
        /// Konstruktor mit der Linie und Haltestelle
        /// </summary>
        /// <param name="linie"></param>
        /// <param name="haltestelle"></param>
        public LinieIstNichtAnHaltestelleException(Linie linie, Haltestelle haltestelle)
        {
            Linie = linie;
            Haltestelle = haltestelle;
        }

        /// <summary>
        /// Die Linie
        /// </summary>
        public Linie Linie
        {
            get; set;
        }

        /// <summary>
        /// Die Haltestelle
        /// </summary>
        public Haltestelle Haltestelle
        {
            get; set;
        }
    }
}