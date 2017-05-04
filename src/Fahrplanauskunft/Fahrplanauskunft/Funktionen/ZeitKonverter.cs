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
        /// Konvertiert ganzahlige Minuten in das Format "hh:mm"
        /// </summary>
        /// <param name="minuten">Zeit in Minuten</param>
        /// <returns>Formatierte Zeit</returns>
        internal static string ZuUhrzeitText(int minuten)
        {
             return DateTime.MinValue.AddMinutes(minuten).ToString("hh:mm");
       }

        /// <summary>
        /// Konvertiert das Format "hh:mm" in ganzahlige Minuten
        /// </summary>
        /// <param name="zeit">Zeit im Format "hh:mm"</param>
        /// <returns>ganzzahlige Minuten</returns>
        internal static int ZuUhrzeitZahl(string zeit)
        {
            string[] zeitWerte =zeit.Split(new Char[] { ':' });
            return Convert.ToInt32(zeitWerte[0]) * 60 + Convert.ToInt32(zeitWerte[1]);
        }
    }
}
