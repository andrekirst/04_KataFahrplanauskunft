﻿// <copyright file="Linie.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Eine Linie ist eine Sammlung von Haltestellen, die das jeweilige Transportsystem, wie eine Linie, abfährt.
    /// </summary>
    public sealed class Linie : FahrplanauskunftObjektBase, IEquatable<Linie>
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Linie()
            : base()
        {
        }

        /// <summary>
        /// Konstruktor für die Angabe von Nummer, Lauf und Farbe
        /// </summary>
        /// <param name="nummer">Die Nummer der Linie (für Hin- und Gegenrichtung)</param>
        /// <param name="lauf">Der Lauf der Linie (nur eine Richtung)</param>
        /// <param name="farbe">Die Farbe für die Linie</param>
        /// <param name="id">Die ID der Linie</param>
        public Linie(string id, string nummer, string lauf, string farbe)
            : base(id: id)
        {
            Nummer = nummer;
            Lauf = lauf;
            Farbe = farbe;
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
        /// Gibt den Lauf der Linie zurück, oder setzt ihn.
        /// </summary>
        public string Lauf
        {
            get; set;
        }

        /// <summary>
        /// Gibt die Nummer der Linie zurück, oder setzt ihn.
        /// </summary>
        public string Nummer
        {
            get; set;
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
        /// Gleichheitsoperator für Linie
        /// </summary>
        /// <param name="a">Wert vom Typ Linie für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Linie für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Linien gleich sind</returns>
        public static bool operator ==(Linie a, Linie b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase(a, b);
        }

        /// <summary>
        /// Vergleicht die Linie mit einer anderen Linie
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(Linie other)
        {
            return EqualsHelper.EqualBase(
                other,
                () =>
                {
                    return base.Equals(other) && Nummer == other.Nummer && Lauf == other.Lauf && Farbe == other.Farbe;
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
            return $"{Nummer} - {Lauf} : Farbe: {Farbe}";
        }
    }
}