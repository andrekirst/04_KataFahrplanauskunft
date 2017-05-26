// <copyright file="ZeitKonverter.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
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
    /// Funktionalität für das Konvertieren einer Uhrzeit als Ganzzahl in Text sowie anders herum
    /// </summary>
    public static class ZeitKonverter
    {
        /// <summary>
        /// Konvertiert ganzahlige Minuten in das Format "HH:mm" (24h)
        /// </summary>
        /// <param name="minuten">Zeit in Minuten</param>
        /// <returns>Formatierte Zeit</returns>
        internal static string ZuUhrzeitText(int minuten)
        {
            return DateTime.MinValue.AddMinutes(minuten).ToString("HH:mm");
        }

        /// <summary>
        /// Konvertiert das Format "HH:mm" (24h) in ganzahlige Minuten
        /// </summary>
        /// <param name="zeit">Zeit im Format "HH:mm"</param>
        /// <returns>Ganzzahlige Minuten</returns>
        internal static int ZuUhrzeitZahl(string zeit)
        {
            string[] zeitWerte = zeit.Split(new char[] { ':' });
            return (Convert.ToInt32(zeitWerte[0]) * 60) + Convert.ToInt32(zeitWerte[1]);
        }
    }
}
