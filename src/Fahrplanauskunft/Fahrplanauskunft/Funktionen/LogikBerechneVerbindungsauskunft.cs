// <copyright file="LogikBerechneVerbindungsauskunft.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Objekte;
using static Fahrplanauskunft.Funktionen.Logik;

namespace Fahrplanauskunft.Funktionen
{
    internal static class LogikBerechneVerbindungsauskunft
    {
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
                IEnumerable<Linie> linien = ErmittleLinien_Von_Haltestelle_Zu_Haltestelle(startHaltestelle, treeItem.Haltestelle, streckenabschnitte);
                foreach(Linie linie in linien)
                {
                    Einzelverbindung einzel = new Einzelverbindung(0, 0, startHaltestelle, treeItem.Haltestelle, linie);
                    ezs.Add(einzel);
                }

                hs.Add(treeItem.Haltestelle);
                testa(treeItem.Haltestelle, treeItem.Childs, hs, ezs, 0, streckenabschnitte);
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

            return linien;
        }
    }
}
