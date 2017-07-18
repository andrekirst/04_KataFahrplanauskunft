// <copyright file="VerbindungsauskunftErgebnisTyp.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Enumeration für den Typ des Ergegnisses einer Verbindungsauskunft
    /// </summary>
    [Flags]
    public enum VerbindungsauskunftErgebnisTyp
    {
        /// <summary>
        /// Das Ergebnis hat ist noch keinem Typ zugewiesen
        /// </summary>
        NichtZugewiesen = 1,

        /// <summary>
        /// Ein Ergbnis mit der geringsten Reisedauer
        /// </summary>
        GeringsteReisedauer = 2,

        /// <summary>
        /// Ein Ergebnis, bei dem der abfahrtstermin am nähesten zum Wunschtermin ist
        /// </summary>
        NaeheZumAbfahrtstermin = 4,

        /// <summary>
        /// Ein Ergebnis mit der geringsten Anzahl an Umstiegen
        /// </summary>
        GeringsteAnzahlUmstiege = 8
    }
}
