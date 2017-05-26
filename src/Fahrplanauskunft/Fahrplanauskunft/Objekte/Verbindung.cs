/*
 Copyright: André Kirst
 Datei: Verbindung.cs
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    public class Verbindung
    {
        private int ankunftszeit;
        private Dictionary<int, Einzelverbindung> einzelerverbindungen;
        private Haltestelle startHaltestelle;
        private Haltestelle zielHaltestelle;

        public Verbindung(int abfahrtszeit, int ankunftszeit, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, Dictionary<int, Einzelverbindung> einzelerverbindungen)
        {
            Abfahrtszeit = abfahrtszeit;
            Ankunftszeit = ankunftszeit;
            this.startHaltestelle = startHaltestelle;
            this.zielHaltestelle = zielHaltestelle;
            this.einzelerverbindungen = einzelerverbindungen;
        }

        public int Abfahrtszeit
        {
            get;
            set;
        }
        public int Ankunftszeit
        {
            get;
            set;
        }
    }
}
