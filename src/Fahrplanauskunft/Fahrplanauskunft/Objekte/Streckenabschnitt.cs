// <copyright file="Streckenabschnitt.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Ein Streckenabschnitt ist eine Verbindung zwischen zwei Haltestellen, auf der n Linien fahren und eine Zeit x für die Fahrt benötigt wird.
    /// </summary>
    public sealed class Streckenabschnitt : FahrplanauskunftObjektBase, IEquatable<Streckenabschnitt>
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Streckenabschnitt()
            : base()
        {
        }

        /// <summary>
        /// Konstruktor mit der Angabe von Dauer, der Start- und Ziel-Haltestelle und den Linien
        /// </summary>
        /// <param name="dauer">Die Dauer, wie lange es von der Start-Haltestelle zur Ziel-Haltestelle dauert</param>
        /// <param name="startHaltestelle">Die Start-Haltestelle</param>
        /// <param name="zielHaltestelle">Die Ziel-Haltestelle</param>
        /// <param name="linie">Die Linie, die auf diesem Streckenabschnitt fährt</param>
        /// <param name="id">Die ID des Streckenabschnittes</param>
        public Streckenabschnitt(string id, int dauer, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, Linie linie)
            : base(id: id)
        {
            Dauer = dauer;
            StartHaltestelle = startHaltestelle;
            ZielHaltestelle = zielHaltestelle;
            Linie = linie;
        }

        /// <summary>
        /// Die Dauer, wie lange es von der Start-Haltestelle zur Ziel-Haltestelle dauert
        /// </summary>
        public int Dauer
        {
            get;
            set;
        }

        /// <summary>
        /// Die Linie, die auf diesem Streckenabschnitt fährt
        /// </summary>
        public Linie Linie
        {
            get;
            set;
        }

        /// <summary>
        /// Die Start-Haltestelle
        /// </summary>
        public Haltestelle StartHaltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die Ziel-Haltestelle
        /// </summary>
        public Haltestelle ZielHaltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Ungleichheitsoperator für Streckenabschnitt
        /// </summary>
        /// <param name="a">Wert vom Typ Streckenabschnitt für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Streckenabschnitt für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Streckenabschnitte ungleich sind</returns>
        public static bool operator !=(Streckenabschnitt a, Streckenabschnitt b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Gleichheitsoperator für Streckenabschnitt
        /// </summary>
        /// <param name="a">Wert vom Typ Streckenabschnitt für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Streckenabschnitt für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Streckenabschnitte gleich sind</returns>
        public static bool operator ==(Streckenabschnitt a, Streckenabschnitt b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase<Streckenabschnitt>(a, b);
        }

        /// <summary>
        /// Vergleicht den Streckenabschnitt mit einem anderen Streckenabschnitt
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(Streckenabschnitt other)
        {
            return EqualsHelper.EqualBase<Streckenabschnitt>(
                other,
                () =>
                {
                    return
                    base.Equals(other) &&
                    Dauer == other.Dauer &&
                    StartHaltestelle == other.StartHaltestelle &&
                    ZielHaltestelle == other.ZielHaltestelle &&
                    Linie == other.Linie;
                });
        }

        /// <summary>
        /// Vergleicht den Streckenabschnitt mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Streckenabschnitt);
        }

        /// <summary>
        /// Gibt den Hashcode zurück
        /// </summary>
        /// <returns>Der Hashcode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
