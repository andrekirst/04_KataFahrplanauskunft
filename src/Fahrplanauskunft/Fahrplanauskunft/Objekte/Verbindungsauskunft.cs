// <copyright file="Verbindungsauskunft.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Erweiterte Verbindung-Objekt, als Ergebnis eines Vergleich mit mehreren Verbindungen
    /// </summary>
    public class Verbindungsauskunft
    {
        /// <summary>
        /// Konstruktor für die Angabe der Verbindung
        /// </summary>
        /// <param name="verbindung">Verbindung</param>
        public Verbindungsauskunft(Verbindung verbindung)
        {
            Verbindung = verbindung;
        }

        /// <summary>
        /// Verweis auf die Verbindung
        /// </summary>
        public Verbindung Verbindung
        {
            get;
            private set;
        }

        /// <summary>
        /// Typ des Ergebnisses einer Verbindungsauskunft
        /// </summary>
        public VerbindungsauskunftErgebnisTyp ErgebnisTyp
        {
            get;
            set;
        }

        /// <summary>
        /// Vergleicht das Verbindungsauskunft mit einem anderen Verbindungsauskunft
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(Verbindungsauskunft other)
        {
            return EqualsHelper.EqualBase<Verbindungsauskunft>(
                other,
                () =>
                {
                    return
                        Verbindung == other.Verbindung &&
                        ErgebnisTyp == other.ErgebnisTyp;
                });
        }

        /// <summary>
        /// Vergleicht das Verbindungsauskunft mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Verbindungsauskunft);
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Verbindung.GetHashCode();
        }

        /// <summary>
        /// Gibt dieüberschriebene ToString-Methode von Verbindung und ErgebnisTyp zurück. Bsp.: "{Verbindung.ToString() - ErgebnisTyp..ToString()"
        /// </summary>
        /// <returns>Bsp.: "B1 - B11"</returns>
        public override string ToString()
        {
            return $"{Verbindung.ToString()} - {ErgebnisTyp.ToString()}";
        }
    }
}
