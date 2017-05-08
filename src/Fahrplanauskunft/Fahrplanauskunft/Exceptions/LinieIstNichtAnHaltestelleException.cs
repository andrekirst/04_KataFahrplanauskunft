using System;
using System.Runtime.Serialization;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Exceptions
{
    /// <summary>
    /// Exception für, dass die Linie nicht an der Haltestelle ist
    /// </summary>
    public class LinieIstNichtAnHaltestelleException : Exception
    {
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