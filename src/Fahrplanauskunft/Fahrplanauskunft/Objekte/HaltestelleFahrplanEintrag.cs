using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplanauskunft.Objekte
{
    /// <summary>
    /// Ein HaltestelleFahrplanEintrag beinhaltet die Information, wann, wo und mit welche Linie abfährt
    /// </summary>
    public class HaltestelleFahrplanEintrag
    {
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public HaltestelleFahrplanEintrag()
        {
        }

        /// <summary>
        /// Konstruktor, um die Haltestelle, Uhrzeit und die Linie zu setzen
        /// </summary>
        /// <param name="haltestelle">Eine Haltestelle</param>
        /// <param name="uhrzeit">Die Uhrzeit, wann abgefahren wird</param>
        /// <param name="linie">Die Linie, die an der Haltestelle los fährt</param>
        public HaltestelleFahrplanEintrag(Haltestelle haltestelle, int uhrzeit, Linie linie)
        {
            Haltestelle = haltestelle;
            Uhrzeit = uhrzeit;
            Linie = linie;
        }

        /// <summary>
        /// Gibt die Haltestelle zurück, welche die Linie abfährt
        /// </summary>
        public Haltestelle Haltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die Linie
        /// </summary>
        public Linie Linie
        {
            get;
            set;
        }

        /// <summary>
        /// Die Linie, die an der Haltestelle fährt
        /// </summary>
        public int Uhrzeit
        {
            get;
            set;
        }

        /// <summary>
        /// Vergleicht den Haltestellenfahrplaneintrag mit einem anderen Objekt
        /// </summary>
        /// <param name="obj">Das andere Objekt, mit dem verglichen werden soll</param>
        /// <returns>Gibt true zurück, wenn sie gleich sind, andernfalls false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            HaltestelleFahrplanEintrag other = obj as HaltestelleFahrplanEintrag;
            return Uhrzeit == other.Uhrzeit &&
                Linie.Equals(other.Linie) &&
                Haltestelle.Equals(other.Haltestelle);
        }
    }
}
