// <copyright file="Verbindung.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Fahrplanauskunft.Funktionen;

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

        public VerbindungsauskunftErgebnisTyp VerbindungsauskunftErgebnisTyp
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{StartHaltestelle.Name} {Funktionen.ZeitKonverter.ZuUhrzeitText(Abfahrtszeit)} -> {(ZielHaltestelle == null ? "<Unbekannte Ziel-Haltestelle>" : ZielHaltestelle.Name)} {Funktionen.ZeitKonverter.ZuUhrzeitText(Ankunftszeit)} - Umstiege: {AnzahlUmstiege}";
        }

        public bool Equals(Verbindung other)
        {
            return EqualsHelper.EqualBase<Verbindung>(
                other,
                () =>
                {
                    return
                        Abfahrtszeit == other.Abfahrtszeit &&
                        Ankunftszeit == other.Ankunftszeit &&
                        StartHaltestelle == other.StartHaltestelle &&
                        ZielHaltestelle == other.ZielHaltestelle &&
                        Einzelverbindungen.SequenceEqual(other.Einzelverbindungen) &&
                        VerbindungsauskunftErgebnisTyp == other.VerbindungsauskunftErgebnisTyp;
                });
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Verbindung);
        }
    }
}
