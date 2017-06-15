// <copyright file="InteraktorSucheLinie.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplanauskunft.Objekte;

namespace Fahrplanauskunft.UI.WindowsForms.Editor.Objekte.Linie
{
    /// <summary>
    /// Interaktorklasse für die Suche nach Linien
    /// </summary>
    public class InteraktorSucheLinie
    {
        /// <summary>
        /// Suche nach einer Linie anhand eines Suchtextes
        /// </summary>
        /// <param name="suchtext">Der Wert, nachdem gesucht werden soll</param>
        /// <param name="linien">Die Liste von Linien</param>
        /// <returns>Gibt die gefilterte Liste von Linien zurück, die anhand des suchtext-Parameters gefiltert wurde</returns>
        public List<Fahrplanauskunft.Objekte.Linie> Suche_Linie(string suchtext, List<Fahrplanauskunft.Objekte.Linie> linien)
        {
            if(suchtext == null)
            {
                return linien;
            }

            suchtext = suchtext.ToLower();

            return linien.Where(l => l.Name.ToLower().Contains(suchtext) || l.Ident.ToLower().Contains(suchtext)).ToList();
        }
    }
}
