// <copyright file="Linie.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Eine Linie ist eine Sammlung von Haltestellen, die das jeweilige Transportsystem, wie eine Linie, abfährt.
    /// </summary>
    public class Linie : FahrplanauskunftObjektBase, IEquatable<Linie>
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Linie()
            : base()
        {
        }

        /// <summary>
        /// Konstruktor für die Angabe von Name und Ident
        /// </summary>
        /// <param name="name">Der Name der Linie (für Hin- und Gegenrichtung)</param>
        /// <param name="ident">Der Identifizierer der Linie (nur eine Richtung)</param>
        /// <param name="farbe">Die Farbe für die Linie</param>
        /// <param name="id">Die ID der Linie</param>
        public Linie(string id, string name, string ident, string farbe)
            : base(id: id)
        {
            Name = name;
            Ident = ident;
            Farbe = farbe;
        }

        /// <summary>
        /// Gibt den Ident der Linie zurück, oder setzt ihn.
        /// </summary>
        public string Ident
        {
            get; set;
        }

        /// <summary>
        /// Gibt den Namen der Linie zurück, oder setzt ihn.
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gibt die Farbe der Linie zurück, oder setzt diese.
        /// </summary>
        public string Farbe
        {
            get;
            set;
        }

        /// <summary>
        /// Gleichheitsoperator für Linie
        /// </summary>
        /// <param name="a">Wert vom Typ Linie für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Linie für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Linien gleich sind</returns>
        public static bool operator ==(Linie a, Linie b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase<Linie>(a, b);
        }

        /// <summary>
        /// Ungleichheitsoperator für Linie
        /// </summary>
        /// <param name="a">Wert vom Typ Linie für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Linie für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Linien ungleich sind</returns>
        public static bool operator !=(Linie a, Linie b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Vergleicht die Linie mit einer anderen Linie
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(Linie other)
        {
            return EqualsHelper.EqualBase<Linie>(
                other,
                () =>
                {
                    return base.Equals(other) && Name == other.Name && Ident == other.Ident && Farbe == other.Farbe;
                });
        }

        /// <summary>
        /// Vergleicht die Linie mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Linie);
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gibt die überschriebene ToString-Methode zurück. Bsp.: "B1 - B11"
        /// </summary>
        /// <returns>Bsp.: "B1 - B11"</returns>
        public override string ToString()
        {
            return $"{Name} - {Ident} : Farbe: {Farbe}";
        }
    }
}