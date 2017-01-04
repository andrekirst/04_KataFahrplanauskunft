using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    public class FahrplanauskunftSpeicher
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public FahrplanauskunftSpeicher()
        {
        }

        /// <summary>
        /// Konstruktor mit dem Ordner-Pfad, in dem sich die Fahrplanauskunfts-Dateien befinden
        /// </summary>
        /// <param name="ordnerPfad">Der Pfad, in dem sich die Fahrplanauskunfts-Dateien befinden</param>
        public FahrplanauskunftSpeicher(string ordnerPfad)
        {
            OrdnerPfad = ordnerPfad;
        }

        public void Laden()
        {
            LadeHaltestellen();
        }

        private void LadeHaltestellen()
        {
            string file = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", OrdnerPfad, "\\haltestellen.json");

            if(!File.Exists(file))
            {
                throw new FileNotFoundException("Haltestellen-Datei nicht gefunden", "haltestellen.json");
            }

            Haltestellen = JsonConvert.DeserializeObject<List<Haltestelle>>(File.ReadAllText(file));
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
    }
}
