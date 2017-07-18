// <copyright file="Einzelverbindung.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    public class Einzelverbindung
    {
        public Einzelverbindung(int abfahrtszeit, int ankunftszeit, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, Linie linie)
        {
            Abfahrtszeit = abfahrtszeit;
            Ankunftszeit = ankunftszeit;
            StartHaltestelle = startHaltestelle;
            ZielHaltestelle = zielHaltestelle;
            Linie = linie;
        }

        public int Abfahrtszeit { get; set; }

        public int Ankunftszeit { get; set; }

        public Haltestelle StartHaltestelle { get; set; }

        public Haltestelle ZielHaltestelle { get; set; }

        public Linie Linie { get; set; }

        public bool Equals(Einzelverbindung other)
        {
            return EqualsHelper.EqualBase<Einzelverbindung>(
                other,
                () =>
                {
                    return
                        Abfahrtszeit == other.Abfahrtszeit &&
                        Ankunftszeit == other.Ankunftszeit &&
                        StartHaltestelle == other.StartHaltestelle &&
                        ZielHaltestelle == other.ZielHaltestelle &&
                        Linie == other.Linie;
                });
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Einzelverbindung);
        }

        public override string ToString()
        {
            return $"{Linie.Nummer} : {StartHaltestelle.Name} {Funktionen.ZeitKonverter.ZuUhrzeitText(Abfahrtszeit)} -> {ZielHaltestelle.Name} {Funktionen.ZeitKonverter.ZuUhrzeitText(Ankunftszeit)}";
        }
    }
}
