using System;
using System.Runtime.Serialization;
using Fahrplanauskunft.Objekte;
using System.Diagnostics.CodeAnalysis;

namespace Fahrplanauskunft.Exceptions
{
    /// <summary>
    /// Exception für, dass die Linie nicht an der Haltestelle ist
    /// </summary>
    [Serializable]
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
        /// Konstruktor für LinieIstNichtAnHaltestelleException mit SerializationInfo und StreamingContext. (Ausschluss von CodeCoverage, da base aufgerufen wird)
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [ExcludeFromCodeCoverageAttribute]
        protected LinieIstNichtAnHaltestelleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Konstruktor für LinieIstNichtAnHaltestelleException mit einer message und Exception. (Ausschluss von CodeCoverage, da base aufgerufen wird)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        [ExcludeFromCodeCoverageAttribute]
        public LinieIstNichtAnHaltestelleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Konstruktor für LinieIstNichtAnHaltestelleException mit einer message. (Ausschluss von CodeCoverage, da base aufgerufen wird)
        /// </summary>
        /// <param name="message"></param>
        [ExcludeFromCodeCoverageAttribute]
        public LinieIstNichtAnHaltestelleException(string message) : base(message)
        {
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