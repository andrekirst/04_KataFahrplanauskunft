// <copyright file="FarbeHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using static System.Text.RegularExpressions.Regex;

namespace Fahrplanauskunft.Funktionen
{
    /// <summary>
    /// Helper-Klasse für das Attribut <see cref="Objekte.Linie.Farbe"/>
    /// </summary>
    public static class FarbeHelper
    {
        /// <summary>
        /// Methode für die Überprüfung auf eine Farbe im RGB-Format
        /// </summary>
        /// <param name="farbe">Der Hexadezimale Wert einer Farbe im RGB-Format</param>
        /// <returns>Gibt true zurück, wen die Farbe im RGB-Format gültig ist, andernfalls false</returns>
        public static bool IstFarbeGueltig(string farbe)
        {
            if(farbe == null)
            {
                return false;
            }

            return IsMatch(farbe, @"\#[0-9a-fA-Z]{6}");
        }
    }
}
