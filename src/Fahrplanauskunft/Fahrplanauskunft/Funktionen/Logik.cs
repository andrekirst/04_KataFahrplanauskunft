using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplanauskunft.Objekte;
using Fahrplanauskunft.Exceptions;

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

        /// <summary>
        /// Gibt die sortierte Liste von Haltestellen für eine Linie zurück. Sortiert wird sie von der Start- zur Ziel-Haltestelle
        /// </summary>
        /// <param name="linie">Die Linie, für die sortierung ausgeführt werden soll</param>
        /// <param name="startHaltestelle">Die Start-Haltestelle, bei der die Sortierung beginnen soll</param>
        /// <param name="zielHaltestelle">Die Ziel-Haltestelle, bei der die Sortierung enden soll</param>
        /// <param name="haltenstellen">Das gesamte Haltestellennetz</param>
        /// <param name="streckenabschnitte">Alle verfügbaren Streckenabschnitte</param>
        /// <returns></returns>
        internal static List<Haltestelle> Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(Linie linie, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<Haltestelle> haltenstellen, List<Streckenabschnitt> streckenabschnitte)
        {
            // 1. Überprüfung, ob die Start-Haltestelle zur Linie gehört 
            if(!Ist_Linie_An_Haltestelle(linie: linie, haltestelle: startHaltestelle))
            {
                throw new LinieIstNichtAnHaltestelleException();
            }

            // 2. Überprüfung, ob die Ziel-Haltestelle zur Linie gehört
            if(!Ist_Linie_An_Haltestelle(linie: linie, haltestelle: zielHaltestelle))
            {
                throw new LinieIstNichtAnHaltestelleException();
            }

            // 3. Haltestellen auf die Haltestellen reduzieren, die zur Linie gehören
            List<Haltestelle> haltestellenDerLinie = Liefere_Haltestellen_einer_Linie(linie: linie, haltestellen: haltenstellen);

            // 4. Streckenabschnitte auf die Streckenabschnitte reduzieren, die zur Linie gehören
            List<Streckenabschnitt> streckenabschnitteDerLinie = Liefere_Streckenabschnitte_einer_Linie(linie: linie, streckenabschnitte: streckenabschnitte);

            // 5. Liste für die sortierten Haltestellen erstellen
            List<Haltestelle> sortierteListe = new List<Haltestelle>();

            // 6. Start-Haltestelle zur Liste der sortierten Haltestellen hinzufügen
            sortierteListe.Add(item: startHaltestelle);

            // 6.1 Start-Haltestelle aus der Liste der verfügbaren Linien entfernen
            haltestellenDerLinie.Remove(item: startHaltestelle);

            // 7.Solange durch eine Liste gehen, bis die ziel-Haltestelle erreicht ist oder die Liste verfügbarer Haltestellen leer ist
            while(!sortierteListe.Last().Equals(zielHaltestelle) || haltestellenDerLinie.Count() > 0)
            {
                // 7.1. Ermittlung nächster Haltestelle anhand des Streckenabschnittes, welche als letzte zur sortieren Liste der Haltestellen hinzugefügt wurde
                List<Streckenabschnitt> gefundeneStreckenabschnitte = Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie(linie: linie, haltestelle: sortierteListe.Last(), streckenabschnitte: streckenabschnitteDerLinie);
                if(gefundeneStreckenabschnitte.Count() == 1)
                {
                    Streckenabschnitt gefundenerStreckenabschnitt = gefundeneStreckenabschnitte[0];
                    Haltestelle gefundeneHaltestelle = gefundenerStreckenabschnitt.StartHaltestelle.Equals(sortierteListe.Last()) ? gefundenerStreckenabschnitt.ZielHaltestelle : gefundenerStreckenabschnitt.StartHaltestelle;
                    if(gefundeneHaltestelle != null)
                    {
                        sortierteListe.Add(gefundeneHaltestelle);
                        haltestellenDerLinie.Remove(gefundeneHaltestelle);
                        // 7.2.vom Schritt zuvor ermittelten Streckenabschnitt aus der zur Verfügung stehenden Streckenabschnitte entfernen
                        streckenabschnitteDerLinie.Remove(gefundenerStreckenabschnitt);
                    }
                }
                else
                {
                    // TODO: Break, damit es keine Endlosschleife gibt
                    break;
                }
            }
            // 8. Ergebnis zurückgeben
            return sortierteListe;
        }

        /// <summary>
        /// Liefert die Streckenabschnitte, die an einer Haltestelle dran liegen für eine Linie
        /// </summary>
        /// <param name="linie"></param>
        /// <param name="haltestelle"></param>
        /// <param name="streckenabschnitte"></param>
        /// <returns></returns>
        internal static List<Streckenabschnitt> Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie(Linie linie, Haltestelle haltestelle, List<Streckenabschnitt> streckenabschnitte)
        {
            return streckenabschnitte.Where(s =>
                s.Linien.Contains(linie) &&
                    ( s.StartHaltestelle.Equals(haltestelle) || s.ZielHaltestelle.Equals(haltestelle) )
                ).ToList();
        }

        /// <summary>
        /// Liefert die Streckenabschnitte, die einer Linie zugeordnet sind
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="streckenabschnitte">Die Streckenabschnitte</param>
        /// <returns></returns>
        internal static List<Streckenabschnitt> Liefere_Streckenabschnitte_einer_Linie(Linie linie, List<Streckenabschnitt> streckenabschnitte)
        {
            return streckenabschnitte.Where(s => s.Linien.Contains(linie)).ToList();
        }

        /// <summary>
        /// Wertet aus, ob die angegebene Linie an der Haltestelle ist
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="haltestelle">Die Haltestelle</param>
        /// <returns></returns>
        internal static bool Ist_Linie_An_Haltestelle(Linie linie, Haltestelle haltestelle)
        {
            return haltestelle.Linien.Contains(linie);
        }
    }
}
