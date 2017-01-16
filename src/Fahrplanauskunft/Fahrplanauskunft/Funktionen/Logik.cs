using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Funktionen
{
    internal class Logik
    {
        internal static List<Umstiegspunkt> Liefere_eindeutige_Umsteigepunkte(List<Umstiegspunkt> umstiegspunkte)
        {
            return umstiegspunkte.Distinct().ToList();
        }

        internal static List<Umstiegspunkt> Liefere_Umsteigepunkte_fuer_Linie(Linie linie)
        {
            throw new NotImplementedException();
        }
    }
}
