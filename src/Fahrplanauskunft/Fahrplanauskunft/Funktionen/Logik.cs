// <copyright file="Logik.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Exceptions;
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
        /// <returns>Eindeutige Liste der Umstiegspunkte</returns>
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
            // anhand der Liste von Haltestellen, alle Haltestelle meiner Linie
            List<Haltestelle> haltestellenDerLinie = Liefere_Haltestellen_einer_Linie(linie, haltestellen);

            // davon alle Haltestellen mit Umsteigepunkt (also mit mindestens 2 Linien)
            List<Umstiegspunkt> haltestellenMitUmstiegspunkt = haltestellenDerLinie
                .Where(x => x.Linien.GroupBy(l => l.Name).Count() > 1)
                .Select(y => new Umstiegspunkt(y)).ToList();

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
            meinHaltestelle.Linien.ForEach((linie) =>
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
        /// <param name="streckenabschnitte">Alle verfügbaren Streckenabschnitte</param>
        /// <returns>Gibt die sortierte Liste von Haltestellen für eine Linie zurück.</returns>
        internal static List<Haltestelle> Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel(Linie linie, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<Streckenabschnitt> streckenabschnitte)
        {
            // 1. Überprüfung, ob die Start-Haltestelle zur Linie gehört
            Ueberpruefe_Ist_Linie_An_Haltestelle(linie, startHaltestelle);

            // 2. Überprüfung, ob die Ziel-Haltestelle zur Linie gehört
            Ueberpruefe_Ist_Linie_An_Haltestelle(linie, zielHaltestelle);

            // 4. Streckenabschnitte auf die Streckenabschnitte reduzieren, die zur Linie gehören
            List<Streckenabschnitt> streckenabschnitteDerLinie = Liefere_Streckenabschnitte_einer_Linie(linie: linie, streckenabschnitte: streckenabschnitte);

            List<Haltestelle> sortierteListe = new List<Haltestelle>();
            sortierteListe.Add(startHaltestelle);
            Haltestelle aktuelleHaltestelle = startHaltestelle;
            while(aktuelleHaltestelle != zielHaltestelle)
            {
                Streckenabschnitt aktuellerStreckenabschnitt = streckenabschnitteDerLinie.First(h => h.StartHaltestelle == aktuelleHaltestelle);
                aktuelleHaltestelle = aktuellerStreckenabschnitt.ZielHaltestelle;
                streckenabschnitteDerLinie.Remove(aktuellerStreckenabschnitt);
                sortierteListe.Add(aktuelleHaltestelle);
            }

            return sortierteListe;
        }

        /// <summary>
        /// Überprüfe, ob eine Linie an der Haltestelle ist
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="haltestelle">Die Haltestelle</param>
        internal static void Ueberpruefe_Ist_Linie_An_Haltestelle(Linie linie, Haltestelle haltestelle)
        {
            if(!Ist_Linie_An_Haltestelle(linie: linie, haltestelle: haltestelle))
            {
                throw new LinieIstNichtAnHaltestelleException(linie: linie, haltestelle: haltestelle);
            }
        }

        /// <summary>
        /// Liefert die Streckenabschnitte, die an einer Haltestelle dran liegen für eine Linie
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="haltestelle">Die Haltestelle</param>
        /// <param name="streckenabschnitte">Die Streckenabschnitte</param>
        /// <returns>Liste von Streckenabschnitten</returns>
        internal static List<Streckenabschnitt> Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie(Linie linie, Haltestelle haltestelle, List<Streckenabschnitt> streckenabschnitte)
        {
            return streckenabschnitte.Where(s =>
                s.Linie == linie &&
                    (s.StartHaltestelle == haltestelle || s.ZielHaltestelle == haltestelle)).ToList();
        }

        /// <summary>
        /// Liefert die Streckenabschnitte, die einer Linie zugeordnet sind
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="streckenabschnitte">Die Streckenabschnitte</param>
        /// <returns>Liste von Streckenabschnitten</returns>
        internal static List<Streckenabschnitt> Liefere_Streckenabschnitte_einer_Linie(Linie linie, List<Streckenabschnitt> streckenabschnitte)
        {
            return streckenabschnitte.Where(s => s.Linie == linie).ToList();
        }

        /// <summary>
        /// Wertet aus, ob die angegebene Linie an der Haltestelle ist
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="haltestelle">Die Haltestelle</param>
        /// <returns>Gibt true zuürck, wenn die Lnie an der Haltestelle ist, andernfalls false.</returns>
        internal static bool Ist_Linie_An_Haltestelle(Linie linie, Haltestelle haltestelle)
        {
            return haltestelle.Linien.Contains(linie);
        }

        /// <summary>
        /// Liefert eine Hierarchie mit möglichen Umstiegspunkten von einer Haltestelle
        /// </summary>
        /// <param name="aktuelleHaltestelle">Aktuelle Haltestelle, Wurzel der Hierarchie</param>
        /// <param name="bereitsGeweseneUmstiegspunkte">Die Liste von Umstiegspunkten, an denen man bereits gewesen ist</param>
        /// <param name="haltestellen">Liste von Haltestellen</param>
        /// <param name="max_tiefe">Maximale Tiefe bei der Rekursion = maximale Anzahl der möglichen Umstiegspunkte</param>
        /// <returns>Gibt ein TreeItem zurück</returns>
        internal static TreeItem Liefere_Hierarchie_Route_von_Haltestelle(Haltestelle aktuelleHaltestelle, List<Umstiegspunkt> bereitsGeweseneUmstiegspunkte, List<Haltestelle> haltestellen, int max_tiefe)
        {
            // 1. aktuelle Haltestelle ist mein Root
            TreeItem ti_root_Haltestelle = new TreeItem(aktuelleHaltestelle);

            // 2. mache die aktuelle Haltestelle zum Umstiegspunkt(auch die eventuelle Start- oder Endhaltestelle)
            Umstiegspunkt up = new Umstiegspunkt(aktuelleHaltestelle);
            if(!bereitsGeweseneUmstiegspunkte.Contains(up))
            {
                bereitsGeweseneUmstiegspunkte.Add(up);
            }

            if(max_tiefe > 0)
            {
                max_tiefe--;

                // 3. Liefere zu einer Haltestelle, die nächsten Umstiegspunkte
                List<Umstiegspunkt> ups = Liefere_Naechste_Umstiegspunkte_von_Haltestelle(
                    ti_root_Haltestelle.Haltestelle,
                    bereitsGeweseneUmstiegspunkte,
                    haltestellen);

                // 4. merken der gefundenen Umstiegspunkte als schon da gewesene
                foreach(Umstiegspunkt umstiegspunkt in ups)
                {
                    if(!bereitsGeweseneUmstiegspunkte.Contains(umstiegspunkt))
                    {
                        bereitsGeweseneUmstiegspunkte.Add(umstiegspunkt);
                    }
                }

                // 5. Suche Rekursiv
                foreach(Umstiegspunkt umstiegspunkt in ups)
                {
                    List<Umstiegspunkt> neuBereitsGeweseneUmstiegspunkte = new List<Umstiegspunkt>();
                    neuBereitsGeweseneUmstiegspunkte.AddRange(bereitsGeweseneUmstiegspunkte);

                    TreeItem ti_child = Liefere_Hierarchie_Route_von_Haltestelle(
                        umstiegspunkt.Haltestelle,
                        neuBereitsGeweseneUmstiegspunkte,
                        haltestellen,
                        max_tiefe);

                    ti_root_Haltestelle.Childs.Add(ti_child);
                }
            }

            return ti_root_Haltestelle;
        }

        /// <summary>
        /// Berechnen der Fahrtdauer von einer Haltestelle zu einer anderen Haltestlle auf einer Linie
        /// </summary>
        /// <param name="linie">Die Linie</param>
        /// <param name="startHaltestelle">Die Start-Haltestelle</param>
        /// <param name="zielHaltestelle">Die Ziel-Haltestelle</param>
        /// <param name="streckenabschnitte">Die Streckenabschnitte</param>
        /// <returns>Gibt die Dauer in Minuten zurück, die von der Start-Haltestelle zur Ziel-Haltestelle benötigt werden</returns>
        internal static int Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(Linie linie, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<Streckenabschnitt> streckenabschnitte)
        {
            int dauer = 0;

            Ueberpruefe_Ist_Linie_An_Haltestelle(linie, startHaltestelle);

            Ueberpruefe_Ist_Linie_An_Haltestelle(linie, zielHaltestelle);

            List<Streckenabschnitt> streckenabschnitteDerLinie = Liefere_Streckenabschnitte_einer_Linie(linie: linie, streckenabschnitte: streckenabschnitte);

            Haltestelle aktuelleHaltestelle = startHaltestelle;
            while(aktuelleHaltestelle != zielHaltestelle)
            {
                Streckenabschnitt aktuellerStreckenabschnitt = streckenabschnitteDerLinie.First(h => h.StartHaltestelle == aktuelleHaltestelle);
                aktuelleHaltestelle = aktuellerStreckenabschnitt.ZielHaltestelle;
                streckenabschnitteDerLinie.Remove(aktuellerStreckenabschnitt);
                dauer += aktuellerStreckenabschnitt.Dauer;
            }

            return dauer;
        }

        /// <summary>
        /// Ermittelt die nächste Abfahrtszeit
        /// </summary>
        /// <param name="haltestelle">Die Haltestelle</param>
        /// <param name="linie">Die Linie</param>
        /// <param name="haltestellenfahrplaneintraege">Die Liste der Haltestellenfahrplaneinträge</param>
        /// <param name="wunschabfahrtszeit">Die Wunschabfahrtszeit</param>
        /// <returns>Gibt die Uhrzeit zurück, wann eine Linie an einer Linie nach einer Wunschabfahrtszeit abfährt</returns>
        internal static int ErmittleAbfahrtszeit(Haltestelle haltestelle, Linie linie, List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege, int wunschabfahrtszeit)
        {
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraegeGefiltertNachHaltestelleUndLinie = haltestellenfahrplaneintraege
                .Where(p =>
                    p.Haltestelle == haltestelle &&
                    p.Linie == linie)
                .OrderBy(o => o.Uhrzeit)
                .ToList();

            int letzteAbfahrtszeit = haltestellenfahrplaneintraegeGefiltertNachHaltestelleUndLinie.Last().Uhrzeit;

            wunschabfahrtszeit = letzteAbfahrtszeit < wunschabfahrtszeit ? 0 : wunschabfahrtszeit;

            return haltestellenfahrplaneintraegeGefiltertNachHaltestelleUndLinie.First(h => h.Uhrzeit >= wunschabfahrtszeit).Uhrzeit;
        }

        internal static Verbindung BerechneVerbindungsauskunft(
            int wunschabfahrtszeit,
            Haltestelle startHaltestelle,
            Haltestelle zielHaltestelle,
            List<Haltestelle> haltestellen,
            List<Linie> linien,
            List<Streckenabschnitt> streckenabschnitte,
            List<HaltestelleFahrplanEintrag> haltestellenfahrplaneintraege,
            List<Verbindung> gefundeneVerbindungen = null)
        {
            int abfahrtszeit = 0;
            int ankunftszeit = 0;
            Haltestelle zielHaltestelleIst = null;
            Dictionary<int, Einzelverbindung> einzelverbindungen = new Dictionary<int, Einzelverbindung>();

            foreach(Linie linie in startHaltestelle.Linien)
            {
                if(zielHaltestelleIst != null)
                {
                    break;
                }

                List<Haltestelle> haltestellenDerLinie = Liefere_Haltestellen_einer_Linie(linie: linie, haltestellen: haltestellen);
                foreach(Haltestelle haltestelle in haltestellenDerLinie)
                {
                    if(Ist_Linie_An_Haltestelle(linie: linie, haltestelle: haltestelle) && haltestelle == zielHaltestelle)
                    {
                        zielHaltestelleIst = haltestelle;

                        abfahrtszeit = ErmittleAbfahrtszeit(
                            haltestelle: startHaltestelle,
                            linie: linie,
                            haltestellenfahrplaneintraege: haltestellenfahrplaneintraege,
                            wunschabfahrtszeit: wunschabfahrtszeit);

                        int dauer = Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle(
                            linie: linie,
                            startHaltestelle: startHaltestelle,
                            zielHaltestelle: zielHaltestelleIst,
                            streckenabschnitte: streckenabschnitte);

                        ankunftszeit = abfahrtszeit + dauer;

                        Einzelverbindung einzelverbindung = new Einzelverbindung(
                            abfahrtszeit: abfahrtszeit,
                            ankunftszeit: ankunftszeit,
                            startHaltestelle: startHaltestelle,
                            zielHaltestelle: zielHaltestelleIst,
                            linie: linie);

                        einzelverbindungen.Add(1, einzelverbindung);

                        break;
                    }
                }
            }

            if(zielHaltestelleIst == null)
            {
                List<Umstiegspunkt> bereitsGeweseneUmstiegspunkte = new List<Objekte.Umstiegspunkt>();
                TreeItem ti = Liefere_Hierarchie_Route_von_Haltestelle(
                    aktuelleHaltestelle: startHaltestelle,
                    bereitsGeweseneUmstiegspunkte: bereitsGeweseneUmstiegspunkte,
                    haltestellen: haltestellen,
                    max_tiefe: 5);

                List<Haltestelle> hs = new List<Haltestelle>();

                List<Einzelverbindung> ezs = new List<Einzelverbindung>();

                testa(startHaltestelle, ti.Childs, hs, ezs, wunschabfahrtszeit, streckenabschnitte);

                // TODO
            }

            Verbindung verbindung = new Objekte.Verbindung(
                abfahrtszeit: abfahrtszeit,
                ankunftszeit: ankunftszeit,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelleIst,
                einzelverbindungen: einzelverbindungen);

            return verbindung;
        }

        private static void testa(Haltestelle startHaltestelle, List<TreeItem> childs, List<Haltestelle> hs, List<Einzelverbindung> ezs, int abfahrtszeit, List<Streckenabschnitt> streckenabschnitte)
        {
            foreach(TreeItem treeItem in childs)
            {
                //List<Linie> linien = ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(startHaltestelle, treeItem.Haltestelle);
                List<Linie> linien = ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(startHaltestelle, treeItem.Haltestelle, streckenabschnitte);
                foreach(Linie linie in linien)
                {
                    Einzelverbindung einzel = new Einzelverbindung(0, 0, startHaltestelle, treeItem.Haltestelle, linie);
                    ezs.Add(einzel);
                }
                hs.Add(treeItem.Haltestelle);
                //ezs.Add(new Einzelverbindung(0, 0, null, null, null));
                testa(treeItem.Haltestelle, treeItem.Childs, hs, ezs, 0, streckenabschnitte);
            }
        }

        internal static List<Linie> ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<Streckenabschnitt> streckenabschnitte)
        {
            List<Linie> linienAnDerStartHaltestelle = streckenabschnitte.Where(sab => sab.StartHaltestelle == startHaltestelle).Select(sab2 => sab2.Linie).ToList();
            List<Linie> linienAnDerZielHaltestelle = streckenabschnitte.Where(sab => sab.ZielHaltestelle == zielHaltestelle).Select(sab2 => sab2.Linie).ToList();

            List<Linie> linien = linienAnDerStartHaltestelle.Intersect(linienAnDerZielHaltestelle).ToList();

            return linien;
        }
    }
}
