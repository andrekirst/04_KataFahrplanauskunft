using Fahrplanauskunft.Funktionen;
using System;
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
        /// <param name="name">Der Name der Linie (für Hin- und Gegenrichtung)</param>
        /// <param name="ident">Der Identifizierer der Linie (nur eine Richtung)</param>
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

        /// <summary>
        /// Vergleicht die Linie mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            return EqualsHelper.EqualBase<Linie>(obj, (other) =>
            {
                return this.Name == other.Name && this.Ident == other.Ident;
            });
        }

        /// <summary>
        /// Gibt den HashCode zurück
        /// </summary>
        /// <returns>Der HashCode</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() * 2 + Ident.GetHashCode();
        }

        /// <summary>
        /// Gleichheitsoperator für Linie
        /// </summary>
        /// <param name="a">Wert vom Typ Linie für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Linie für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Linien gleich sind</returns>
        public static bool operator ==(Linie a, Linie b)
        {
            return EqualsOperatorHelper.EqualsOperatorBase<Linie>(a, b);
        }

        /// <summary>
        /// Ungleichheitsoperator für Linie
        /// </summary>
        /// <param name="a">Wert vom Typ Linie für den linken Vergleich</param>
        /// <param name="b">Wert vom Typ Linie für den rechten Vergleich</param>
        /// <returns>Gibt true zurück, wenn die Linien ungleich sind</returns>
        public static bool operator !=(Linie a, Linie b)
        {
            return !(a == b);
        }
    }
}