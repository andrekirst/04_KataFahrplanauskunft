// <copyright file="EqualsHelper.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;

namespace Fahrplanauskunft.Funktionen
{
    /// <summary>
    /// Diese Klasse ist eine Hilfsklasse für die Equals-Methode
    /// </summary>
    public static class EqualsHelper
    {
        /// <summary>
        /// Hilfsmethode für die Equals-Implementierung
        /// </summary>
        /// <typeparam name="T">Der Type, für wen die Equals-Methode gilt</typeparam>
        /// <param name="obj">Die Objektreferenz, die der Equals-Methode übergeben wird</param>
        /// <param name="custom">Die Funktion, die bool zurückgibt und ein Objekt vom Typ T erwartet</param>
        /// <returns></returns>
        public static bool EqualBase<T>(T obj, Func<bool> custom)
        {
            if(obj == null)
            {
                return false;
            }

            if(custom != null)
            {
                Func<bool> func = custom;
                return func();
            }

            return false;
        }
    }
}
