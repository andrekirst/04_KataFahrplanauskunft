// <copyright file="LogikBerechneVerbindungsauskunft.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Objekte;
using static Fahrplanauskunft.Funktionen.Logik;

namespace Fahrplanauskunft.Funktionen
{
    public static class LogikBerechneVerbindungsauskunft
    {
        internal static List<Verbindung> BerechneVerbindungsauskunft(
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

            #region Prüft, ob Start- und Zielhaltestelle auf einer Linie
            // Prüft, ob Start- und Zielhaltestelle auf einer Linie
            foreach (Linie linie in startHaltestelle.Linien)
            {
                if(zielHaltestelleIst != null)
                {
                    // gefunden, dann Ausstieg
                    break;
                }

                List<Haltestelle> haltestellenDerLinie = Liefere_Haltestellen_einer_Linie(linie: linie, haltestellen: haltestellen);
                foreach(Haltestelle haltestelle in haltestellenDerLinie)
                {
                    if(Ist_Linie_An_Haltestelle(linie: linie, haltestelle: haltestelle) && haltestelle == zielHaltestelle)
                    {
                        // Treffer
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
            #endregion

            if (zielHaltestelleIst == null)
            {
                #region Start- und Zielhaltestelle nicht auf verschiedenen Linien
                List<Umstiegspunkt> bereitsGeweseneUmstiegspunkte = new List<Objekte.Umstiegspunkt>();
                TreeItem ti = Liefere_Hierarchie_Route_von_Haltestelle(
                    aktuelleHaltestelle: startHaltestelle,
                    bereitsGeweseneUmstiegspunkte: bereitsGeweseneUmstiegspunkte,
                    haltestellen: haltestellen,
                    max_tiefe: 5);

                List<Haltestelle> hs = new List<Haltestelle>();

                List<Einzelverbindung> ezs = new List<Einzelverbindung>();

                testa(startHaltestelle, zielHaltestelle, ti.Childs, hs, ezs, wunschabfahrtszeit, streckenabschnitte);

                #endregion

                // TODO
            }

            Verbindung verbindung = new Objekte.Verbindung(
                abfahrtszeit: abfahrtszeit,
                ankunftszeit: ankunftszeit,
                startHaltestelle: startHaltestelle,
                zielHaltestelle: zielHaltestelleIst,
                einzelverbindungen: einzelverbindungen);

            return new List<Verbindung>() { verbindung };
        }

        private static void testa(Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<TreeItem> childs, List<Haltestelle> hs, List<Einzelverbindung> ezs, int abfahrtszeit, List<Streckenabschnitt> streckenabschnitte)
        {
            if (childs.Count > 0)
            {
                foreach (TreeItem treeItem in childs)
                {
                    IEnumerable<Linie> linien = ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(startHaltestelle, treeItem.Haltestelle, streckenabschnitte);
                    foreach (Linie linie in linien)
                    {
                        Einzelverbindung einzel = new Einzelverbindung(0, 0, startHaltestelle, treeItem.Haltestelle, linie);
                        ezs.Add(einzel);
                    }

                    hs.Add(treeItem.Haltestelle);
                    testa(treeItem.Haltestelle, zielHaltestelle, treeItem.Childs, hs, ezs, 0, streckenabschnitte);
                }
            }
            else
            {
                // hier wird die Linie vom letzten Umstiegspunkt zur Zielhaltstelle ermittelt
                IEnumerable<Linie> linien = ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(startHaltestelle, zielHaltestelle, streckenabschnitte);
                foreach (Linie linie in linien)
                {
                    Einzelverbindung einzel = new Einzelverbindung(0, 0, startHaltestelle, zielHaltestelle, linie);
                    ezs.Add(einzel);
                }
                hs.Add(zielHaltestelle);
            }
        }

        internal static IEnumerable<Linie> ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<Streckenabschnitt> streckenabschnitte)
        {
            IEnumerable<Linie> linienAnDerStartHaltestelle = streckenabschnitte
                .Where(sab => sab.StartHaltestelle == startHaltestelle)
                .Select(sab2 => sab2.Linie);

            IEnumerable<Linie> linienAnDerZielHaltestelle = streckenabschnitte
                .Where(sab => sab.ZielHaltestelle == zielHaltestelle)
                .Select(sab2 => sab2.Linie);

            IEnumerable<Linie> linien = linienAnDerStartHaltestelle.Intersect(linienAnDerZielHaltestelle);

            // hier ist der Ansatz für die Route
            var x = streckenabschnitte.Where(sab => sab.Linie == linien.ToList()[0]).ToList();
            var a = x.Where(sab => sab.StartHaltestelle == startHaltestelle).FirstOrDefault();

            // neue rekursive Funktion
            List<Streckenabschnitt> route = Hole_Streckenabschnitte(a, x, new List<Streckenabschnitt>(), zielHaltestelle);

            // es gibt ja mehrere Linien
            if (linien.ToList().Count > 1)
            {
                var y = streckenabschnitte.Where(sab => sab.Linie == linien.ToList()[1]);
            }
            // Ende

            return linien;
        }

        internal static List<Streckenabschnitt> Hole_Streckenabschnitte(Streckenabschnitt aktuellerStreckenabschnitt, List<Streckenabschnitt> streckenabschnitteDerLinie, List<Streckenabschnitt> aktuelleStreckenabschnitte, Haltestelle zielHaltestelle)
        {
            if (aktuellerStreckenabschnitt == null)
            {
                return aktuelleStreckenabschnitte;
            }

            aktuelleStreckenabschnitte.Add(aktuellerStreckenabschnitt);

            if (aktuellerStreckenabschnitt.ZielHaltestelle == zielHaltestelle)
            {
                return aktuelleStreckenabschnitte;
            }
            Streckenabschnitt nächsterSAb = streckenabschnitteDerLinie.Where(sab => sab.StartHaltestelle == aktuellerStreckenabschnitt.ZielHaltestelle).FirstOrDefault();

            return Hole_Streckenabschnitte(nächsterSAb, streckenabschnitteDerLinie, aktuelleStreckenabschnitte, zielHaltestelle);

        }

        internal static List<Verbindungsauskunft> Ermittle_GeringsteAnzahlUmstiege(List<Verbindung> verbindungen)
        {
            int minAnzahlUmstiege = verbindungen.Min(x => x.AnzahlUmstiege);
            return verbindungen.Where(x => x.AnzahlUmstiege == minAnzahlUmstiege)
                    .Select(x => new Verbindungsauskunft(verbindung: x)
                                    { ErgebnisTyp = VerbindungsauskunftErgebnisTyp.GeringsteAnzahlUmstiege })
                    .ToList<Verbindungsauskunft>();

        }
    }
}
