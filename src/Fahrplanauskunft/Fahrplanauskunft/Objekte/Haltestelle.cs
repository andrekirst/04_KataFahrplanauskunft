// <copyright file="Haltestelle.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Eine Haltestelle ist ein Punkt, an denen ein- und ausgestiegen werden kann.
    /// </summary>
    public class Haltestelle : FahrplanauskunftObjektBase, IEquatable<Haltestelle>
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Haltestelle()
            : base()
        {
            Linien = new List<Linie>();
        }

        /// <summary>
        /// Konstruktor mit dem Namen der Haltestelle
        /// </summary>
        /// <param name="name">Der Name der Haltestelle</param>
        /// <param name="id">Die ID der Haltestelle</param>
        public Haltestelle(string id, string name)
            : base(id: id)
        {
            Name = name;
            Linien = new List<Objekte.Linie>();
        }

        /// <summary>
        /// Die Linien, die der Haltestelle zugeordnet sind
        /// </summary>
        public List<Linie> Linien
        {
            get; set;
        }

        /// <summary>
        /// Gibt den Namen der Haltestelle zurück, oder setzt ihn
        /// </summary>
        public string Name
        {
            get; set;
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
        /// Vergleicht die Haltestelle mit einer anderen Haltestelle
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(Haltestelle other)
        {
            return EqualsHelper.EqualBase<Haltestelle>(
                other,
                () =>
                {
                    return
                        base.Equals(other) &&
                        Name == other.Name &&
                        Linien.SequenceEqual(other.Linien);
                });
        }

        /// <summary>
        /// Vergleicht die Haltestelle mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Haltestelle);
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
        /// Gibt die überschriebene ToString-Methode zurück. Bsp.: "Name: H4"
        /// </summary>
        /// <returns>Bsp.: "Name: H4"</returns>
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
