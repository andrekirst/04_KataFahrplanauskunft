// <copyright file="LinieIstNichtAnHaltestelleException.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Fahrplanauskunft.Objekte;

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
        /// <param name="linie">Die Linie</param>
        /// <param name="haltestelle">Die Haltestelle</param>
        public LinieIstNichtAnHaltestelleException(Linie linie, Haltestelle haltestelle)
        {
            Linie = linie;
            Haltestelle = haltestelle;
        }

        /// <summary>
        /// Konstruktor für LinieIstNichtAnHaltestelleException mit SerializationInfo und StreamingContext. (Ausschluss von CodeCoverage, da base aufgerufen wird)
        /// </summary>
        /// <param name="info">Die SerializationInfo, die die serialisierten Objektdaten für die ausgelöste Exception enthält.</param>
        /// <param name="context">Der StreamingContext, der die Kontextinformationen über die Quelle oder das Ziel enthält.</param>
        [ExcludeFromCodeCoverageAttribute]
        public LinieIstNichtAnHaltestelleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Konstruktor für LinieIstNichtAnHaltestelleException mit einer message und Exception. (Ausschluss von CodeCoverage, da base aufgerufen wird)
        /// </summary>
        /// <param name="message">Die Fehlermeldung, in der die Ursache der Exception erklärt wird</param>
        /// <param name="innerException">Die Ausnahme, die die aktuelle Ausnahme verursacht hat, oder null</param>
        [ExcludeFromCodeCoverageAttribute]
        public LinieIstNichtAnHaltestelleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Konstruktor für LinieIstNichtAnHaltestelleException mit einer message. (Ausschluss von CodeCoverage, da base aufgerufen wird)
        /// </summary>
        /// <param name="message">Die Fehlermeldung, in der die Ursache der Exception erklärt wird</param>
        [ExcludeFromCodeCoverageAttribute]
        public LinieIstNichtAnHaltestelleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Die Haltestelle
        /// </summary>
        public Haltestelle Haltestelle
        {
            get; set;
        }

        /// <summary>
        /// Die Linie
        /// </summary>
        public Linie Linie
        {
            get; set;
        }
    }
}