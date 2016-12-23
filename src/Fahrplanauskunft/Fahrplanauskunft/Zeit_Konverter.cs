using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft
{
    internal class Zeit_Konverter
    {
        internal static string ZuUhrzeitText(int minuten)
        {
             return DateTime.MinValue.AddMinutes(minuten).ToString("hh:mm");
       }
    }
}
