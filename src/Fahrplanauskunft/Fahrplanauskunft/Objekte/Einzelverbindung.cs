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
                        this.Abfahrtszeit == other.Abfahrtszeit &&
                        this.Ankunftszeit == other.Ankunftszeit &&
                        this.StartHaltestelle == other.StartHaltestelle &&
                        this.ZielHaltestelle == other.ZielHaltestelle &&
                        this.Linie == other.Linie;
                });
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Einzelverbindung);
        }

        public override string ToString()
        {
            return string.Format(
                "{0} : {1} {2} -> {3} {4}",
                Linie.Name,
                StartHaltestelle.Name,
                Funktionen.ZeitKonverter.ZuUhrzeitText(Abfahrtszeit),
                ZielHaltestelle.Name,
                Funktionen.ZeitKonverter.ZuUhrzeitText(Ankunftszeit));
        }
    }
}
