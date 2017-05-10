using System;
using Fahrplanauskunft.Funktionen;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Ein Umstiegspunkt ist eine Haltestelle mit mindensten 2 verschiedenen Linien
    /// </summary>
    public class Umstiegspunkt : IEquatable<Umstiegspunkt>
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
        /// <param name="haltestelle">Ein Haltestelleobjekt</param>
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
        /// Gleichheitsoperator für Umstiegspunkt
        /// </summary>
        /// <param name="a">Wert vom Typ Umstiegspunkt für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Umstiegspunkt für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Umstiegspunkte gleich sind</returns>
        public static bool operator ==(Umstiegspunkt a, Umstiegspunkt b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase<Umstiegspunkt>(a, b);
        }

        /// <summary>
        /// Ungleichheitsoperator für Umstiegspunkt
        /// </summary>
        /// <param name="a">Wert vom Typ Umstiegspunkt für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Umstiegspunkt für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Umstiegspunkte ungleich sind</returns>
        public static bool operator !=(Umstiegspunkt a, Umstiegspunkt b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Vergleicht die Haltestelle mit einem anderen Umstiegspunkt
        /// </summary>
        /// <param name="other">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public bool Equals(Umstiegspunkt other)
        {
            return EqualsHelper.EqualBase<Umstiegspunkt>(
                other,
                () =>
                {
                    return Name == other.Name && Haltestelle == other.Haltestelle;
                });
        }

        /// <summary>
        /// Vergleicht die Haltestelle mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Umstiegspunkt);
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
            return string.Format("Name: {0}", Name);
        }
    }
}
