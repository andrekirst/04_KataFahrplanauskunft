// <copyright file="EqualsOperatorHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Funktionen
{
    /// <summary>
    /// Hilfsklasse für den Gleichheitsoperator
    /// </summary>
    public static class EqualsOperatorHelper
    {
        /// <summary>
        /// Hilfemethode für den Gleichheitsoperator
        /// </summary>
        /// <typeparam name="T">Der Typ, der verwendet wird</typeparam>
        /// <param name="a">Der linke Wert</param>
        /// <param name="b">Der rechte Wert</param>
        /// <returns>Gibt true zurück, wenn es die gleiche Instanz ist, beide null sind oder die Equals-Methode des jeweiligen Typs true zurückgibt, andernfalls wird false zurückgegeben.</returns>
        public static bool EqualsOperatorBase<T>(T a, T b)
            where T : class
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }
    }
}
