using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Funktionen
{
    internal class Zeit_Konverter
    {
        internal static string ZuUhrzeitText(int minuten)
        {
             return DateTime.MinValue.AddMinutes(minuten).ToString("hh:mm");
       }

        internal static int ZuUhrzeitZahl(string zeit)
        {
            string[] zeitWerte =zeit.Split(new Char[] { ':' });
            return Convert.ToInt32(zeitWerte[0]) * 60 + Convert.ToInt32(zeitWerte[1]);
        }
    }
}
