using System;
using System.Runtime.Serialization;

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
    }
}