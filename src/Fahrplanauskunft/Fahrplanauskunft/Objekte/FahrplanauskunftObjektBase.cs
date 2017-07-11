// <copyright file="FahrplanauskunftObjektBase.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Abstrakte Basisklasse für die Fahrplanauskunft-Objekte
    /// </summary>
    public abstract class FahrplanauskunftObjektBase
    {
        /// <summary>
        /// Privates Feld für die ID des Objektes
        /// </summary>
        private string id;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        protected FahrplanauskunftObjektBase()
        {
            ID = null;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="id">Die ID des Objektes</param>
        protected FahrplanauskunftObjektBase(string id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Die ID des Objektes
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = string.IsNullOrEmpty(value) ? Guid.NewGuid().ToString() : value;
            }
        }

        /// <summary>
        /// Vergleicht die Instanz mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            FahrplanauskunftObjektBase other = obj as FahrplanauskunftObjektBase;
            return EqualsHelper.EqualBase<FahrplanauskunftObjektBase>(other, () => ID == other.ID);
        }

        /// <summary>
        /// Gibt den Hashwert anhand des Attributes <see cref="ID"/> zurück
        /// </summary>
        /// <returns>Der Hashwert</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
