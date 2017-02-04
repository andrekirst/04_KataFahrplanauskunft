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

        internal static List<Umstiegspunkt> Liefere_Umsteigepunkte_fuer_Linie(Linie linie, List<Haltestelle> haltestellen)
        {
            //anhand der Liste von Haltestellen, alle Haltestelle meiner Linie
            List<Haltestelle> haltestellenDerLinie = Liefere_Haltestelle_einer_Linie(linie, haltestellen);
            // davon alle Haltestellen mit Umsteigepunkt (also mit mindestens 2 Linien)
            List<Umstiegspunkt> haltestellenMitUmsteigepunkt = haltestellenDerLinie
                .Where(x => x.Linien.GroupBy(l => l.Name).Count() > 1)
                .Select(y => new Umstiegspunkt(y)
               ).ToList();
            
            return haltestellenMitUmsteigepunkt;
        }

        internal static List<Haltestelle> Liefere_Haltestelle_einer_Linie(Linie linie, List<Haltestelle> haltestellen)
        {
            return haltestellen.Where(x => x.Linien.Contains(linie)).ToList();
        }
    }
}
