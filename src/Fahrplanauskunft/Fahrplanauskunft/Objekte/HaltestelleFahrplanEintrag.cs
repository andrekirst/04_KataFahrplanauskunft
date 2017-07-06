// <copyright file="HaltestelleFahrplanEintrag.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Ein HaltestelleFahrplanEintrag beinhaltet die Information, wann, wo und mit welche Linie abfährt
    /// </summary>
    public class HaltestelleFahrplanEintrag : IEquatable<HaltestelleFahrplanEintrag>
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public HaltestelleFahrplanEintrag()
        {
        }

        /// <summary>
        /// Konstruktor, um die Haltestelle, Uhrzeit und die Linie zu setzen
        /// </summary>
        /// <param name="haltestelle">Eine Haltestelle</param>
        /// <param name="uhrzeit">Die Uhrzeit, wann abgefahren wird</param>
        /// <param name="linie">Die Linie, die an der Haltestelle los fährt</param>
        public HaltestelleFahrplanEintrag(Haltestelle haltestelle, int uhrzeit, Linie linie)
        {
            Haltestelle = haltestelle;
            Uhrzeit = uhrzeit;
            Linie = linie;
        }

        /// <summary>
        /// Gibt die Haltestelle zurück, welche die Linie abfährt
        /// </summary>
        public Haltestelle Haltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die Linie für welche die Uhrzeit gilt
        /// </summary>
        public Linie Linie
        {
            get;
            set;
        }

        /// <summary>
        /// Die Uhrzeit, wann abgefahren wird
        /// </summary>
        public int Uhrzeit
        {
            get;
            set;
        }

        /// <summary>
        /// Gleichheitsoperator für Haltestellenfahrplaneintrag
        /// </summary>
        /// <param name="a">Wert vom Typ HaltestelleFahrplanEintrag für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ HaltestelleFahrplanEintrag für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Haltestellenfahrplaneinträge gleich sind</returns>
        public static bool operator ==(HaltestelleFahrplanEintrag a, HaltestelleFahrplanEintrag b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase<HaltestelleFahrplanEintrag>(a, b);
        }

        /// <summary>
        /// Ungleichheitsoperator für Haltestellenfahrplaneintrag
        /// </summary>
        /// <param name="a">Wert vom Typ Haltestelle für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Haltestelle für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Haltestellenfahrplaneinträge gleich sind</returns>
        public static bool operator !=(HaltestelleFahrplanEintrag a, HaltestelleFahrplanEintrag b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Vergleicht den Haltestellenfahrplaneintrag mit einem anderen Haltestellenfahrplaneintrag
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(HaltestelleFahrplanEintrag other)
        {
            return EqualsHelper.EqualBase<HaltestelleFahrplanEintrag>(
                other,
                () =>
                {
                    return Uhrzeit == other.Uhrzeit &&
                    Linie == other.Linie &&
                    Haltestelle == other.Haltestelle;
                });
        }

        /// <summary>
        /// Vergleicht den Haltestellenfahrplaneintrag mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as HaltestelleFahrplanEintrag);
        }

        /// <summary>
        /// Gibt den Hashcode zurück
        /// </summary>
        /// <returns>Der Hashcode</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                // Suitable nullity checks etc, of course :)
                hash = (hash * 23) + Uhrzeit.GetHashCode();
                hash = (hash * 23) + (Linie == null ? 0 : Linie.GetHashCode());
                hash = (hash * 23) + (Haltestelle == null ? 0 : Haltestelle.GetHashCode());
                return hash;
            }
        }
    }
}
