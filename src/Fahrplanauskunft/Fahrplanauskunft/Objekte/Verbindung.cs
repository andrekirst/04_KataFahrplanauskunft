/*
 Copyright: André Kirst
 Datei: Verbindung.cs
*/
using Fahrplanauskunft.Funktionen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    public class Verbindung
    {
        public Verbindung(int abfahrtszeit, int ankunftszeit, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, Dictionary<int, Einzelverbindung> einzelverbindungen)
        {
            Abfahrtszeit = abfahrtszeit;
            Ankunftszeit = ankunftszeit;
            StartHaltestelle = startHaltestelle;
            ZielHaltestelle = zielHaltestelle;
            Einzelverbindungen = einzelverbindungen;
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

        public int AnzahlUmstiege
        {
            get
            {
                return Einzelverbindungen.Count - 1;
            }
        }

        public Dictionary<int, Einzelverbindung> Einzelverbindungen
        {
            get;
            set;
        }

        public Haltestelle StartHaltestelle
        {
            get;
            set;
        }

        public Haltestelle ZielHaltestelle
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format(
                "{0} {1} -> {2} {3} - Umstiege: {4}",
                StartHaltestelle.Name,
                Funktionen.ZeitKonverter.ZuUhrzeitText(Abfahrtszeit),
                ZielHaltestelle.Name,
                Funktionen.ZeitKonverter.ZuUhrzeitText(Ankunftszeit),
                AnzahlUmstiege);
        }

        public bool Equals(Verbindung other)
        {
            return EqualsHelper.EqualBase<Verbindung>(
                other,
                () =>
                {
                    return
                        this.Abfahrtszeit == other.Abfahrtszeit &&
                        this.Ankunftszeit == other.Ankunftszeit &&
                        this.StartHaltestelle == other.StartHaltestelle &&
                        this.ZielHaltestelle == other.ZielHaltestelle &&
                        this.Einzelverbindungen.SequenceEqual(other.Einzelverbindungen);
                });
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Verbindung);
        }
    }
}
