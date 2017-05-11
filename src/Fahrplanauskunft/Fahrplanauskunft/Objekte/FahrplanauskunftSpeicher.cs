// <copyright file="FahrplanauskunftSpeicher.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Der FahrplanauskunftSpeicher ist der zentrale Speicher für die Haltestellen, Linien, etc.
    /// </summary>
    public class FahrplanauskunftSpeicher
    {
        /// <summary>
        /// Konstruktor mit dem Ordner-Pfad, in dem sich die Fahrplanauskunfts-Dateien befinden
        /// </summary>
        /// <param name="ordnerPfad">Der Pfad, in dem sich die Fahrplanauskunfts-Dateien befinden</param>
        public FahrplanauskunftSpeicher(string ordnerPfad)
        {
            OrdnerPfad = ordnerPfad;
        }

        /// <summary>
        /// Gibt oder setzt den Pfad, in dem sich die Fahrplanauskunfts-Dateien befinden
        /// </summary>
        public string OrdnerPfad
        {
            get;
            set;
        }

        /// <summary>
        /// Die Liste von Haltestellen
        /// </summary>
        public List<Haltestelle> Haltestellen
        {
            get; set;
        }

        /// <summary>
        /// Die Liste von Linien
        /// </summary>
        public List<Linie> Linien
        {
            get;
            set;
        }

        /// <summary>
        /// Die Liste der Streckenabschnitte
        /// </summary>
        public List<Streckenabschnitt> Streckenabschnitte
        {
            get;
            set;
        }

        /// <summary>
        /// Die Liste der Haltestellenfahrplaneinträge
        /// </summary>
        public List<HaltestelleFahrplanEintrag> Haltestellenfahrplaneintraege
        {
            get;
            set;
        }

        /// <summary>
        /// Läde alle Objekte in den FahrplanauskunftSpeicher
        /// </summary>
        public void Laden()
        {
            LadeHaltestellen();
            LadeLinien();
            LadeStreckenabschnitte();
            LadeHaltestellenfahrplaneintraege();
        }

        /// <summary>
        /// Methode für das Laden der Streckenabschnitte aus dem Order
        /// </summary>
        internal void LadeStreckenabschnitte()
        {
            string file = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", OrdnerPfad, "\\streckenabschnitte.json");

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Streckenabschnitte-Datei nicht gefunden", "streckenabschnitte.json");
            }

            Streckenabschnitte = JsonConvert.DeserializeObject<List<Streckenabschnitt>>(File.ReadAllText(file));
        }

        /// <summary>
        /// Methode für das Laden von Linien aus dem Ordner
        /// </summary>
        internal void LadeLinien()
        {
            string file = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", OrdnerPfad, "\\linien.json");

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Linien-Datei nicht gefunden", "linien.json");
            }

            Linien = JsonConvert.DeserializeObject<List<Linie>>(File.ReadAllText(file));
        }

        /// <summary>
        /// Methode für das Laden von Haltestellen
        /// </summary>
        internal void LadeHaltestellen()
        {
            string file = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", OrdnerPfad, "\\haltestellen.json");

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Haltestellen-Datei nicht gefunden", "haltestellen.json");
            }

            Haltestellen = JsonConvert.DeserializeObject<List<Haltestelle>>(File.ReadAllText(file));
        }

        /// <summary>
        /// Methode für das Laden von Haltestellenfahrplaneinträgen
        /// </summary>
        internal void LadeHaltestellenfahrplaneintraege()
        {
            string file = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", OrdnerPfad, "\\haltestellenfahrplaneintraege.json");

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Haltestellenfahrplaneinträge-Datei nicht gefunden", "haltestellenfahrplaneintraege.json");
            }

            Haltestellenfahrplaneintraege = JsonConvert.DeserializeObject<List<HaltestelleFahrplanEintrag>>(File.ReadAllText(file));
        }
    }
}
