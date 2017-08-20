// <copyright file="TreeItem.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Hierarchische Struktur von möglichen Umstiegspunkten von einer Haltestelle
    /// </summary>
    internal class TreeItem : IEquatable<TreeItem>
    {
        /// <summary>
        /// Konstruktor für die Angabe der Haltstelle
        /// </summary>
        /// <param name="haltestelle">Haltestelle</param>
        public TreeItem(Haltestelle haltestelle)
            : this()
        {
            Haltestelle = haltestelle;
        }

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        private TreeItem()
        {
            Childs = new List<TreeItem>();
        }

        /// <summary>
        /// Die TreeItems unterhalb des aktuellen
        /// </summary>
        public List<TreeItem> Childs
        {
            get; set;
        }

        /// <summary>
        /// Verweis auf die Haltestelle (Wurzel)
        /// </summary>
        public Haltestelle Haltestelle
        {
            get; set;
        }

        /// <summary>
        /// Ungleichheitsoperator für TreeItem
        /// </summary>
        /// <param name="a">Wert vom Typ TreeItem für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ TreeItem für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die TreeItems ungleich sind</returns>
        public static bool operator !=(TreeItem a, TreeItem b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Gleichheitsoperator für TreeItem
        /// </summary>
        /// <param name="a">Wert vom Typ TreeItem für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ TreeItem für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die TreeItems gleich sind</returns>
        public static bool operator ==(TreeItem a, TreeItem b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase(a, b);
        }

        /// <summary>
        /// Vergleicht das TreeItem mit einem anderen TreeItem
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(TreeItem other)
        {
            return EqualsHelper.EqualBase(
                other,
                () =>
                {
                    bool equal = true;

                    equal = equal == (Haltestelle == other.Haltestelle);
                    if(Childs.Count != 0 || other.Childs.Count != 0)
                    {
                        // Reihefolge spielt keine Rolle, wir sortieren vorher
                        equal = equal == Childs.OrderBy(x => x.Haltestelle.Name).SequenceEqual(other.Childs.OrderBy(x => x.Haltestelle.Name));
                    }

                    return equal;
                });
        }

        /// <summary>
        /// Vergleicht das TreeItem mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as TreeItem);
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Haltestelle.GetHashCode();
        }

        /// <summary>
        /// Gibt die überschriebene ToString-Methode zurück. Bsp.: "Name: H4 - Childs: 2"
        /// </summary>
        /// <returns>Bsp.: "Name: H4 - Childs: 2"</returns>
        public override string ToString()
        {
            return $"Name: {Haltestelle.Name} - Childs: {Childs.Count}";
        }
    }
}
