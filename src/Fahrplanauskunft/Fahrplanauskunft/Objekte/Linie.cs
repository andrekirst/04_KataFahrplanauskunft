﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Eine Linie ist eine Sammlung von Haltestellen, die das jeweilige Transportsystem, wie eine Linie, abfährt.
    /// </summary>
    public class Linie
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Linie()
        {
        }

        /// <summary>
        /// Konstruktor für die Angabe von Name und Ident
        /// </summary>
        /// <param name="name">Der Name der Linie</param>
        /// <param name="ident">Der Identifizierer der Linie</param>
        public Linie(string name, string ident)
        {
            this.Name = name;
            this.Ident = ident;
        }

        /// <summary>
        /// Gibt den Ident der Linie zurück, oder setzt ihn.
        /// </summary>
        public string Ident { get; set; }

        /// <summary>
        /// Gibt den Namen der Linie zurück, oder setzt ihn.
        /// </summary>
        public string Name { get; set; }
    }
}