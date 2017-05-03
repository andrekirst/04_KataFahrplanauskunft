﻿using Fahrplanauskunft.Funktionen;
using System;
using System.Collections.Generic;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Eine Haltestelle ist ein Punkt, an denen ein- und ausgestiegen werden kann.
    /// </summary>
    public class Haltestelle
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Haltestelle()
        {
            Linien = new List<Linie>();
        }

        /// <summary>
        /// Konstruktor mit dem Namen der Haltestelle
        /// </summary>
        /// <param name="name">Der Name der Haltestelle</param>
        public Haltestelle(string name)
            : this()
        {
            Name = name;
        }

        /// <summary>
        /// Die Linien, die der Haltestelle zugeordnet sind
        /// </summary>
        public List<Linie> Linien { get; set; }

        /// <summary>
        /// Gibt den Namen der Haltestelle zurück, oder setzt ihn
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Vergleicht die Haltestelle mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return EqualsHelper.EqualBase<Haltestelle>(obj, (other) =>
            {
                return this.Name == other.Name;
            });
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Gibt die überschriebene ToString-Methode zurück. Bsp.: "Name: H4"
        /// </summary>
        /// <returns>Bsp.: "Name: H4"</returns>
        public override string ToString()
        {
            return String.Format("Name: {0}", Name);
        }

        /// <summary>
        /// Gleichheitsoperator für Haltestelle
        /// </summary>
        /// <param name="a">Wert vom Typ Haltestelle für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Haltestelle für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Haltestellen gleich sind</returns>
        public static bool operator ==(Haltestelle a, Haltestelle b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase<Haltestelle>(a, b);
        }

        /// <summary>
        /// Ungleichheitsoperator für Haltestelle
        /// </summary>
        /// <param name="a">Wert vom Typ Haltestelle für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Haltestelle für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Haltestellen ungleich sind</returns>
        public static bool operator !=(Haltestelle a, Haltestelle b)
        {
            return !(a == b);
        }
    }
}
