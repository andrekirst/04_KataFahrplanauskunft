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
        public object Haltestelle
        {
            get;
            set;
        }

        /// <summary>
        /// Die Uhrzeit, wann abgefahren wird
        /// </summary>
        public object Linie
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
    }
}
