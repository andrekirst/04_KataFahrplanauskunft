using Fahrplanauskunft.Funktionen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Ein Umstiegspunkt ist eine Haltestelle mit mindensten 2 verschiedenen Linien
    /// </summary>
    public class Umstiegspunkt
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Umstiegspunkt()
        {
        }
        /// <summary>
        /// Standardkonstruktor mit einer Haltestelle
        /// </summary>
        /// <param name="haltestelle">ein Haltestelleobjekt</param>
        public Umstiegspunkt(Haltestelle haltestelle)
        {
            Haltestelle = haltestelle;
            Name = haltestelle.Name;
        }

        /// <summary>
        /// Gibt die Haltestelle zurück
        /// </summary>
        public Haltestelle Haltestelle
        {
            get; set;
        }

        /// <summary>
        /// Name des Umstiegspunkt
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Vergleicht die Haltestelle mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return EqualsHelper.EqualBase<Umstiegspunkt>(obj, (other) =>
            {
                return Name == other.Name && Haltestelle.Equals(other.Haltestelle);
            });
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Gibt die überschriebene ToString-Methode zurück. Bsp.: "Name: H4"
        /// </summary>
        /// <returns>Bsp.: "Name: H4"</returns>
        public override string ToString()
        {
            return String.Format("Name: {0}", Name);
        }
    }
}
