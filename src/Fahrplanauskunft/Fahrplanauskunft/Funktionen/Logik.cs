using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.Funktionen
{
    /// <summary>
    /// Klasse beinhaltet verschiedenen statische Methoden für die Ermittlung einer Verbindungsabfrage
    /// </summary>
    internal static class Logik
    {
        /// <summary>
        /// Liefert aus einer Liste von Umstiegspunkten eine eindeutige Menge
        /// </summary>
        /// <param name="umstiegspunkte">Liste der Umstiegspunkte</param>
        /// <returns>eindeutige Liste der Umstiegspunkte</returns>
        internal static List<Umstiegspunkt> Liefere_eindeutige_Umstiegspunkte(List<Umstiegspunkt> umstiegspunkte)
        {
            return umstiegspunkte.Distinct().ToList();
        }

        /// <summary>
        /// Ermittelt die Umstiegpunkte für eine Linie
        /// </summary>
        /// <param name="linie">Für diese Linie</param>
        /// <param name="haltestellen">Liste von Haltestellen</param>
        /// <returns>Liste der Umstiegspunkte</returns>
        internal static List<Umstiegspunkt> Liefere_Umstiegspunkte_fuer_Linie(Linie linie, List<Haltestelle> haltestellen)
        {
            //anhand der Liste von Haltestellen, alle Haltestelle meiner Linie
            List<Haltestelle> haltestellenDerLinie = Liefere_Haltestellen_einer_Linie(linie, haltestellen);
            // davon alle Haltestellen mit Umsteigepunkt (also mit mindestens 2 Linien)
            List<Umstiegspunkt> haltestellenMitUmstiegspunkt = haltestellenDerLinie
                .Where(x => x.Linien.GroupBy(l => l.Name).Count() > 1)
                .Select(y => new Umstiegspunkt(y)
               ).ToList();
            
            return haltestellenMitUmstiegspunkt;
        }

        /// <summary>
        /// Ermittelt die Haltestellen für eine Linie 
        /// </summary>
        /// <param name="linie">Für dies Linie</param>
        /// <param name="haltestellen">Liste von Haltestellen</param>
        /// <returns>Liste der Haltestellen</returns>
        internal static List<Haltestelle> Liefere_Haltestellen_einer_Linie(Linie linie, List<Haltestelle> haltestellen)
        {
            return haltestellen.Where(x => x.Linien.Contains(linie)).ToList();
        }

        /// <summary>
        /// Liefert zu einer Haltestelle die Umstiegspunkte, entfernt aber die Umstiegspunkte anhand der Liste der <paramref name="bereitsGeweseneUmstiegspunkte"/>
        /// </summary>
        /// <param name="meinHaltestelle">Die Haltestelle, an der man sich gerade befindet</param>
        /// <param name="bereitsGeweseneUmstiegspunkte">Liste von Umstiegspunkten, an denen man bereits gewesen ist</param>
        /// <param name="haltestellen">Liste von Haltestellen</param>
        /// <returns>Liste der Umstiegspunkte</returns>
        internal static List<Umstiegspunkt> Liefere_Naechste_Umstiegspunkte_von_Haltestelle(Haltestelle meinHaltestelle, List<Umstiegspunkt> bereitsGeweseneUmstiegspunkte, List<Haltestelle> haltestellen)
        {
            // 1. hole alle Linie zu einer Haltestelle
            List<Umstiegspunkt> umstiegspunkte = new List<Umstiegspunkt>();
            meinHaltestelle.Linien.ForEach(delegate (Linie linie)
            {
                // 2. hole zu den Linie jeweils die Umstiegspunkte
                umstiegspunkte.AddRange(Liefere_Umstiegspunkte_fuer_Linie(linie, haltestellen));
            });

            // 3. Distinkte Menge der Umstiegspunkte bilden
            umstiegspunkte = Liefere_eindeutige_Umstiegspunkte(umstiegspunkte);

            // 4. Entfernen der bereitsgewesenen Umstiegspunkte
            umstiegspunkte = umstiegspunkte.Except(bereitsGeweseneUmstiegspunkte).ToList();

            // 5. Entfernen meinHaltestelle, wenn dieser ein Umstiegspunkt ist
            umstiegspunkte.RemoveAll(x => x.Haltestelle == meinHaltestelle);

            return umstiegspunkte;
        }
    }
}
