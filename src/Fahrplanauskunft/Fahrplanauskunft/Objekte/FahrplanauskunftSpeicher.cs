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
        private const string LinienDateiName = "linien.json";
        private const string HaltestellenDateiName = "haltestellen.json";
        private const string StreckenabschnitteDateiName = "streckenabschnitte.json";
        private const string HaltestellenfahrplaneintraegeDateiName = "haltestellenfahrplaneintraege.json";

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
        /// Speichert alle Objekte aus dem FahrplanauskunftSpeicher in den Ordner
        /// </summary>
        public void Speichern()
        {
            SpeicherHaltestellen();
            SpeicherLinien();
            SpeicherStreckenabschnitte();
            SpeicherHaltestellenfahrplaneintraege();
        }

        /// <summary>
        /// Lädt alle Objekte in den FahrplanauskunftSpeicher
        /// </summary>
        public void Laden()
        {
            LadeHaltestellen();
            LadeLinien();
            LadeStreckenabschnitte();
            LadeHaltestellenfahrplaneintraege();
        }

        /// <summary>
        /// Speichert das Objekt Linie aus dem FahrplanauskunftSpeicher in den Ordner
        /// </summary>
        internal void SpeicherLinien()
        {
            string file = string.Concat(OrdnerPfad, @"\", LinienDateiName);

            File.WriteAllText(file, JsonConvert.SerializeObject(Linien));
        }

        /// <summary>
        /// Speichert das Objekt Haltestelle aus dem FahrplanauskunftSpeicher in den Ordner
        /// </summary>
        internal void SpeicherHaltestellen()
        {
            string file = string.Concat(OrdnerPfad, @"\", HaltestellenDateiName);

            File.WriteAllText(file, JsonConvert.SerializeObject(Haltestellen));
        }

        /// <summary>
        /// Speichert das Objekt Haltestellenfahrplaneintraege aus dem FahrplanauskunftSpeicher in den Ordner
        /// </summary>
        internal void SpeicherHaltestellenfahrplaneintraege()
        {
            string file = string.Concat(OrdnerPfad, @"\", HaltestellenfahrplaneintraegeDateiName);

            File.WriteAllText(file, JsonConvert.SerializeObject(Haltestellenfahrplaneintraege));
        }

        /// <summary>
        /// Speichert das Objekt Streckenabschnitt aus dem FahrplanauskunftSpeicher in den Ordner
        /// </summary>
        internal void SpeicherStreckenabschnitte()
        {
            string file = string.Concat(OrdnerPfad, @"\", StreckenabschnitteDateiName);

            File.WriteAllText(file, JsonConvert.SerializeObject(Streckenabschnitte));
        }

        /// <summary>
        /// Methode für das Laden der Streckenabschnitte aus dem Order
        /// </summary>
        internal void LadeStreckenabschnitte()
        {
            string file = string.Concat(OrdnerPfad, @"\", StreckenabschnitteDateiName);

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Streckenabschnitte-Datei nicht gefunden", StreckenabschnitteDateiName);
            }

            Streckenabschnitte = JsonConvert.DeserializeObject<List<Streckenabschnitt>>(File.ReadAllText(file));
        }

        /// <summary>
        /// Methode für das Laden von Linien aus dem Ordner
        /// </summary>
        internal void LadeLinien()
        {
            string file = string.Concat(OrdnerPfad, @"\", LinienDateiName);

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Linien-Datei nicht gefunden", LinienDateiName);
            }

            Linien = JsonConvert.DeserializeObject<List<Linie>>(File.ReadAllText(file));
        }

        /// <summary>
        /// Methode für das Laden von Haltestellen
        /// </summary>
        internal void LadeHaltestellen()
        {
            string file = string.Concat(OrdnerPfad, @"\", HaltestellenDateiName);

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Haltestellen-Datei nicht gefunden", HaltestellenDateiName);
            }

            Haltestellen = JsonConvert.DeserializeObject<List<Haltestelle>>(File.ReadAllText(file));
        }

        /// <summary>
        /// Methode für das Laden von Haltestellenfahrplaneinträgen
        /// </summary>
        internal void LadeHaltestellenfahrplaneintraege()
        {
            string file = string.Concat(OrdnerPfad, @"\", HaltestellenfahrplaneintraegeDateiName);

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Haltestellenfahrplaneinträge-Datei nicht gefunden", HaltestellenfahrplaneintraegeDateiName);
            }

            Haltestellenfahrplaneintraege = JsonConvert.DeserializeObject<List<HaltestelleFahrplanEintrag>>(File.ReadAllText(file));
        }
    }
}
