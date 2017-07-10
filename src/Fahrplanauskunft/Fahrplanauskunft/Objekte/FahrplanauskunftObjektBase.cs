﻿// <copyright file="FahrplanauskunftObjektBase.cs" company="github.com/andrekirst/04_KataFahrplanauskunft">
// Copyright (c) github.com/andrekirst/04_KataFahrplanauskunft. All rights reserved.
// </copyright>

using Fahrplanauskunft.Funktionen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(string.IsNullOrEmpty(value))
                {
                    id = Guid.NewGuid().ToString();
                }
                else
                {
                    id = value;
                }
            }
        }

        /// <summary>
        /// Gibt den Hashwert anhand des Attributes <see cref="ID"/> zurück
        /// </summary>
        /// <returns>Der Hashwert</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Vergleicht die Instanz mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as FahrplanauskunftObjektBase);
        }

        /// <summary>
        /// Vergleicht die aktuelle Instanz mit einer anderen Instanz vom Typ <see cref="FahrplanauskunftObjektBase"/>
        /// </summary>
        /// <param name="other">Die andere Instanz vom Typ <see cref="FahrplanauskunftObjektBase"/></param>
        /// <returns>Gibt true zurück, wenn die <see cref="ID"/> der jeweiligen Instanzen gleich sind</returns>
        public bool Equals(FahrplanauskunftObjektBase other)
        {
            return EqualsHelper.EqualBase<FahrplanauskunftObjektBase>(
                other,
                () =>
                {
                    return this.ID == other.ID;
                });
        }
    }
}
