// <copyright file="Verbindungsanfrage.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// eine Verbidungsanfrage ist eine Anfrage an das System mit der Start- und Ziel-Haltestelle, so wie der gewünschten Abfahrtszeit
    /// </summary>
    public class Verbindungsanfrage
    {
        /// <summary>
        /// Konstruktor mit Start- und Ziel-Haltestelle, sowie der gewünschten Abfahrtszeit
        /// </summary>
        /// <param name="startHaltestelle">Die Start-Haltestelle, bei der man beginnen möchte</param>
        /// <param name="zielHaltestelle">Die Ziel-Haltestelle, zu der man transportiert werden möchte</param>
        /// <param name="wunschAbfahrtszeit">Die gewünschte Abfahrtszeit</param>
        public Verbindungsanfrage(Haltestelle startHaltestelle, Haltestelle zielHaltestelle, int wunschAbfahrtszeit)
        {
            StartHaltestelle = startHaltestelle;
            ZielHaltestelle = zielHaltestelle;
            WunschAbfahrtszeit = wunschAbfahrtszeit;
        }

        /// <summary>
        /// Die Start-Haltestelle, bei der man beginnen möchte
        /// </summary>
        public Haltestelle StartHaltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die gewünschte Abfahrtszeit
        /// </summary>
        public int WunschAbfahrtszeit
        {
            get;
            set;
        }

        /// <summary>
        /// Die Ziel-Haltestelle, zu der man transportiert werden möchte
        /// </summary>
        public Haltestelle ZielHaltestelle
        {
            get;
            set;
        }
    }
}
