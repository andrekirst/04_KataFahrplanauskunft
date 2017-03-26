using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    public class Streckenabschnitt
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Streckenabschnitt()
        {
        }

        /// <summary>
        /// Konstruktor mit der Angabe von Dauer, der Start- und Ziel-Haltestelle und den Linien
        /// </summary>
        /// <param name="dauer">Die Dauer, wie lange es von der Start-Haltestelle zur Ziel-Haltestelle dauert</param>
        /// <param name="startHaltestelle">Die Start-Haltestelle</param>
        /// <param name="zielHaltestelle">Die Ziel-Haltestelle</param>
        /// <param name="linien">Die Linien, die auf diesem Streckenabschnitt fahren</param>
        public Streckenabschnitt(int dauer, Haltestelle startHaltestelle, Haltestelle zielHaltestelle, List<Linie> linien)
        {
            Dauer = dauer;
            StartHaltestelle = startHaltestelle;
            ZielHaltestelle = zielHaltestelle;
            Linien = linien;
        }

        /// <summary>
        /// Die Dauer, wie lange es von der Start-Haltestelle zur Ziel-Haltestelle dauert
        /// </summary>
        public int Dauer
        {
            get;
            set;
        }

        /// <summary>
        /// Die Linien, die auf diesem Streckenabschnitt fahren
        /// </summary>
        public List<Linie> Linien
        {
            get;
            set;
        }

        /// <summary>
        /// Die Start-Haltestelle
        /// </summary>
        public Haltestelle StartHaltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die Ziel-Haltestelle
        /// </summary>
        public Haltestelle ZielHaltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Vergleicht den Streckenabschnitt mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Streckenabschnitt other = obj as Streckenabschnitt;
            if (other == null)
            {
                return false;
            }

            return
                Dauer == other.Dauer &&
                StartHaltestelle.Equals(other.StartHaltestelle) &&
                ZielHaltestelle.Equals(other.ZielHaltestelle);
        }
    }
}
